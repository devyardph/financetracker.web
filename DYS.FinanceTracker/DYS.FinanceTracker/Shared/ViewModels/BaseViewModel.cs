using DYS.FinanceTracker.Shared.Dtos;
using DYS.FinanceTracker.Shared.Security;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MvvmBlazor.ViewModel;
using System.Security.Claims;

namespace DYS.FinanceTracker.Shared.ViewModels
{
    public class BaseViewModel : ViewModelBase
    {
        public NavigationManager _navigationManager;
        public IJSRuntime _jsRuntime;
        public readonly ISupabaseAuthProvider _supabaseAuthProvider;
        private readonly SessionHandler _sessionHandler;

        #region PROPERTIES
        public bool _isReadOnly = false;
        public bool IsReadOnly
        {
            get => _isReadOnly;
            set => Set(ref _isReadOnly, value, nameof(IsReadOnly));
        }

        public bool _isBusy = false;
        public bool IsBusy
        {
            get => _isBusy;
            set => Set(ref _isBusy, value, nameof(IsBusy));
        }

        public bool _isSaving = false;
        public bool IsSaving
        {
            get => _isSaving;
            set => Set(ref _isSaving, value, nameof(IsSaving));
        }

        public bool _isLoading = false;
        public bool IsLoading
        {
            get => _isLoading;
            set => Set(ref _isLoading, value, nameof(IsLoading));
        }

        public string _action = "";
        public string Action
        {
            get => _action;
            set => Set(ref _action, value, nameof(Action));
        }



        public NotificationDto _notification = new NotificationDto();
        public NotificationDto Notification
        {
            get => _notification;
            set => Set(ref _notification, value);
        }

        public string _header;
        public string Header
        {
            get => _header;
            set => Set(ref _header, value, nameof(Header));
        }

        public string _subHeader;
        public string SubHeader
        {
            get => _subHeader;
            set => Set(ref _subHeader, value, nameof(SubHeader));
        }

        public List<ErrorDto> _errors = new List<ErrorDto>();
        public List<ErrorDto> Errors
        {
            get => _errors;
            set => Set(ref _errors, value, nameof(Errors));
        }

        public string _name;
        public string Name
        {
            get => _name;
            set => Set(ref _name, value, nameof(Name));
        }

        public ProfileDto _profile = new ProfileDto();
        public ProfileDto Profile
        {
            get => _profile;
            set => Set(ref _profile, value, nameof(Profile));
        }

        public SearchDto _search = new SearchDto();
        public SearchDto Search
        {
            get => _search;
            set => Set(ref _search, value, nameof(Search));
        }
        //public SessionStorageComponent SessionStorageComponent { get; set; } = new SessionStorageComponent();
        #endregion

        public BaseViewModel(NavigationManager navigationManager,
                             IJSRuntime jsRuntime,
                             ISupabaseAuthProvider supabaseAuthProvider,
                             SessionHandler sessionHandler)
        {
            _jsRuntime = jsRuntime;
            _navigationManager = navigationManager;
            _supabaseAuthProvider = supabaseAuthProvider;
            _sessionHandler = sessionHandler;
        }

        public override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                var authState = await _supabaseAuthProvider.GetAuthenticationStateAsync();
                if (authState.User != null)
                {
                    authState.User.Claims.ToList().ForEach(x =>
                    {
                        if (x.Type == ClaimTypes.NameIdentifier)
                        {
                            _profile.Id = x.Value;
                        }
                        else if (x.Type == ClaimTypes.Email)
                        {
                            _profile.Email = x.Value;
                        }
                    });
                }
            }
        }

        public async Task Signout()
        {
            await _supabaseAuthProvider.LogoutAsync();
            _sessionHandler.Stop();
            _navigationManager.NavigateTo("/login", forceLoad:true);
        }
        public void NavigationToPath(string path)
        {
            StateHasChanged();
            _navigationManager.NavigateTo(path);
        }

    }
}
