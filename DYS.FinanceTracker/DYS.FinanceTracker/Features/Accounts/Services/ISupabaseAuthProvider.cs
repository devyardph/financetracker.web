using Blazored.LocalStorage;
using DYS.FinanceTracker.Shared.Dtos;
using Microsoft.AspNetCore.Components.Authorization;
using Supabase.Gotrue;
using System.Security.Claims;

namespace DYS.FinanceTracker.Features.Accounts.Services
{
    public interface ISupabaseAuthProvider
    {
        Task<AuthenticationState> GetAuthenticationStateAsync();
        Task<BaseOutputDto> LoginAsync(string email, string password);
        Task<BaseOutputDto> RegisterAsync(string email, string password);
        Task LogoutAsync();
    }
}
