using AutoMapper;
using DYS.FinanceTracker.Features.Accounts.Services;
using DYS.FinanceTracker.Shared.Data;
using DYS.FinanceTracker.Shared.Dtos;
using DYS.FinanceTracker.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Reactive;


namespace DYS.FinanceTracker.Features.Accounts.ViewModels
{
   
    public class AccountViewModel: BaseViewModel
    {
        private readonly ISupabaseAuthProvider _supabaseAuthProvider;
        private readonly NavigationManager _navigationManager;
        public AccountViewModel(NavigationManager navigationManager,
          IJSRuntime jsRuntime,
          ISupabaseAuthProvider supabaseAuthProvider,
          Supabase.Client supabase)
          : base(navigationManager, jsRuntime, supabaseAuthProvider)
        {
            _supabaseAuthProvider = supabaseAuthProvider;
            _navigationManager = navigationManager;
        }

        #region PROPERTIES
        private LoginDto _login = new LoginDto();
        public LoginDto Login
        {
            get => _login;
            set => Set(ref _login, value, nameof(Login));
        }

        private RegisterDto _register = new RegisterDto();
        public RegisterDto Register
        {
            get => _register;
            set => Set(ref _register, value, nameof(Register));
        }
        #endregion

        public async Task LoginAsync()
        {
            _isBusy = true;
            _notification = new NotificationDto();
            var output = await _supabaseAuthProvider.LoginAsync(_login.UserNameOrEmailAddress, _login.Password);
            if (output.Success)
            {
                _navigationManager.NavigateTo("/", forceLoad: true);
            }
            else
            { 
                _notification.Success = output.Success;
                _notification.Description = output?.Message ?? "An error occurred during login.";
            }
            _isBusy = false;
        }

        public async Task RegisterAsync()
        {
            _isBusy = true;
            _notification = new NotificationDto();
            if (!_register.Password.Equals(_register.ConfirmPassword))
            {
                _notification.Success = false;
                _notification.Description = "Confirm password did not match.";
                _isBusy = false;
                return;
            }
            var output = await _supabaseAuthProvider.RegisterAsync(_register.UserNameOrEmailAddress, _register.Password);
            if (output.Success)
            {
                _notification.Success = output.Success;
                _notification.Description = output?.Message ?? "";
            }
            else
            {
                _notification.Success = output.Success;
                _notification.Description = output?.Message ?? "An error occurred during login.";
            }
            _register = new RegisterDto();
            _isBusy = false;
        }

    }
}
