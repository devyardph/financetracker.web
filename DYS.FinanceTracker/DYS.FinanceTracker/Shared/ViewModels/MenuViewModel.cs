
using Blazored.LocalStorage;
using DYS.FinanceTracker.Shared.Dtos;
using DYS.FinanceTracker.Shared.Security;
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
             ISupabaseAuthProvider supabaseAuthProvider,
             SessionHandler sessionHandler)
            : base(navigationManager, jsRuntime, supabaseAuthProvider, sessionHandler)
        {
            _navigationManager = navigationManager;
            _configuration = configuration;
        }

        #region PROPERTIES
        public List<MenuDto> _menu = new List<MenuDto>();
        public List<MenuDto> Menu
        {
            get => _menu;
            set => Set(ref _menu, value, nameof(Menu));
        }

        public string _activeMenu = "";
        public string ActiveMenu
        {
            get => _activeMenu;
            set => Set(ref _activeMenu, value, nameof(ActiveMenu));
        }
        #endregion

        public override Task OnInitializedAsync()
        {
            _menu = new List<MenuDto>() {
             new MenuDto(){ Id="home", Title="Home", Icon="bx-home-smile", Path= "/", Active= false },
             new MenuDto(){ Id="accounts", Title="Accounts", Icon="bx-credit-card", Path= "/accounts", Active= false },
             new MenuDto(){ Id="report", Title="Report", Icon="bx-file", Path= "/report", Active= false },
            };
            return base.OnInitializedAsync();
        }

        public void NavigationToPath(string id,string path)
        {
            base.NavigationToPath(path, forceLoad: false);
            _activeMenu = id;
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
