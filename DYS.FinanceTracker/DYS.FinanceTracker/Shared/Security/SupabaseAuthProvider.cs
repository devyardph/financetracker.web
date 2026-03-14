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
            Console.WriteLine($"Session will expire on {session?.ExpiresIn}");
            if (session != null)
            {
                session = await _supabase.Auth.SetSession(session.AccessToken ?? "", session.RefreshToken ?? "");
                Console.WriteLine("Get session from refresh token...");
                await _localStorageService.SetItemAsync<Session>("session", session);
            }
           
            var identity = session != null ? new ClaimsIdentity(new[]{
                    new Claim(ClaimTypes.NameIdentifier, session!.User!.Id ?? string.Empty),
                    new Claim(ClaimTypes.Email, session.User.Email ?? "")
            }, "supabase") : new ClaimsIdentity();
            Console.WriteLine($"Get session {identity.Name}");
            return new AuthenticationState(new ClaimsPrincipal(identity));
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
            }
        }
    }

}
