
using Blazored.LocalStorage;
using DYS.FinanceTracker.Features.Accounts.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace DYS.FinanceTracker.Shared.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {

        public readonly IConfiguration _configuration;

        public MenuViewModel(NavigationManager navigationManager, IJSRuntime jsRuntime,
            ILocalStorageService localStorageService,
            IConfiguration configuration,
             ISupabaseAuthProvider supabaseAuthProvider)
            : base(navigationManager, jsRuntime, supabaseAuthProvider)
        {
            _navigationManager = navigationManager;
            _configuration = configuration;
        }


        public override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
        }

        public void GoogleSign()
        {
            var googleSignInUrl = $"{_configuration["Google:Login:Url"]}";
            //SessionStorageComponent.NavigateTo(googleSignInUrl, true);
            //SessionStorageComponent.ComponentStateHasChanged();
        }

        //public async Task GoogleLogout() => await SessionStorageComponent.SignoutAsync();
    }
}
