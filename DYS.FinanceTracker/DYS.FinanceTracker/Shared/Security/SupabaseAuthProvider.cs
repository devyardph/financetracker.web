using Blazored.LocalStorage;
using DYS.FinanceTracker.Shared.Dtos;
using Microsoft.AspNetCore.Components.Authorization;
using Supabase.Gotrue;
using Supabase.Gotrue.Exceptions;
using System.Security.Claims;

namespace DYS.FinanceTracker.Shared.Security
{
    public class SupabaseAuthProvider : AuthenticationStateProvider, ISupabaseAuthProvider
    {
        private readonly Supabase.Client _supabase;
        private readonly ILocalStorageService _localStorageService;
        private ClaimsPrincipal _currentUser = new ClaimsPrincipal(new ClaimsIdentity());

        public SupabaseAuthProvider(Supabase.Client supabase, ILocalStorageService localStorageService)
        {
            _supabase = supabase;
            _localStorageService = localStorageService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var session = await _localStorageService.GetItemAsync<Session>("session");

            if (session!=null)
            {

                await _supabase.Auth.SetSession(session.AccessToken ?? string.Empty,
                                                  session.RefreshToken ?? string.Empty,false);

                var expired = session?.Expired();
                if (expired == true)
                { 
                    var refreshedSession = await _supabase.Auth.RefreshSession();
                    if (refreshedSession != null)
                    {
                        await _localStorageService.SetItemAsync<Session>("session", refreshedSession);
                        session = await _localStorageService.GetItemAsync<Session>("session");
                    }
                }

                if (session != null)
                {
                    var identity = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.NameIdentifier, session!.User!.Id ?? string.Empty),
                    new Claim(ClaimTypes.Email, session.User.Email ?? "")
                    }, "supabase");

                    return new AuthenticationState(new ClaimsPrincipal(identity));
                }
                else
                {
                    _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
                }
            }
            else
            {
                _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
            }

            return new AuthenticationState(_currentUser);
        }

        public async Task<BaseOutputDto> LoginAsync(string email, string password)
        {
            var output = new BaseOutputDto();
            try
            {
                var result = await _supabase.Auth.SignIn(email, password);
                await _localStorageService.SetItemAsync<Session>("session", result ?? new Session());
                NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
                output.Success = true;
                output.Message = "Login successful.";
            }
            catch (GotrueException ex)
            {
                Console.WriteLine($"Login failed: {ex.Message}");
                output.Success = false;
                output.Message = $"Login failed: {ex?.Message}";

            }
            catch (Exception ex)
            {
                // unexpected error (network, serialization, etc.)
                Console.WriteLine($"Unexpected error during login: {ex.Message}");
                output.Success = false;
                output.Message = $"Login failed: {ex?.Message}";
            }
            return output;
        }

        public async Task<BaseOutputDto> RegisterAsync(string email, string password)
        {
            var output = new BaseOutputDto();
            try
            {
                var result = await _supabase.Auth.SignUp(email, password);
                if (result?.User == null)
                {
                    output.Success = false;
                    output.Message = "Registration failed.";
                }
                else
                {
                    output.Success = true;
                    output.Message = "Registration successful. Please check your inbox to confirm your account.";
                }
            }
            catch (GotrueException ex)
            {
                Console.WriteLine($"Registration failed: {ex.Message}");
                output.Success = false;
                output.Message = $"Registration failed: {ex?.Message}";

            }
            catch (Exception ex)
            {
                // unexpected error (network, serialization, etc.)
                Console.WriteLine($"Unexpected error during registration: {ex.Message}");
                output.Success = false;
                output.Message = $"Registration failed: {ex?.Message}";
            }
            return output;
        }

        public async Task LogoutAsync()
        {
            await _supabase.Auth.SignOut();
            await _localStorageService.RemoveItemAsync("session");
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

     
        public async Task RefreshSessionAsync()
        {
            var currentSession = _supabase.Auth.CurrentSession;
            if (currentSession != null && currentSession?.Expired() == true)
            {
                var session = await _supabase.Auth.RefreshSession();
                if (session != null)
                {
                    Console.WriteLine($"Session refreshed successfully...");
                    await _localStorageService.SetItemAsync<Session>("session", session ?? new Session());
                }
                else 
                {
                    Console.WriteLine($"Session refresh failed: No session returned.");
                    await LogoutAsync();
                }
            }
            else await LogoutAsync();
        }

        public async Task KeepAliveAsync(CancellationToken token)
        {
            var timer = new PeriodicTimer(TimeSpan.FromMinutes(30));
            while (await timer.WaitForNextTickAsync(token))
                await RefreshSessionAsync();
        }
        public async Task StartKeepAliveLoop()
        {
            var tokenSource = new CancellationTokenSource();
            await KeepAliveAsync(tokenSource.Token);
        }

    }

}
