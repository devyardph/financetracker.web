using AutoMapper;
using DYS.FinanceTracker.Features.Accounts.Components;
using DYS.FinanceTracker.Features.Finance.Components;
using DYS.FinanceTracker.Shared.Dtos;
using DYS.FinanceTracker.Shared.Extensions;
using DYS.FinanceTracker.Shared.Models;
using DYS.FinanceTracker.Shared.Security;
using DYS.FinanceTracker.Shared.Services;
using DYS.FinanceTracker.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Supabase;
using Supabase.Postgrest;


namespace DYS.FinanceTracker.Features.Accounts.ViewModels
{
    public class AccountsViewModel : BaseViewModel
    {

        private readonly ISupabaseService<Account> _accountService;
        private readonly Supabase.Client _supabase;
        public AccountsViewModel(NavigationManager navigationManager,
            IJSRuntime jsRuntime, 
            ISupabaseService<Account> accountService,
            ISupabaseAuthProvider supabaseAuthProvider,
            Supabase.Client supabase)
            : base(navigationManager, jsRuntime, supabaseAuthProvider)
        {
            _accountService = accountService;
            _supabase = supabase;
        }


        #region PROPERTIES
        private AccountDto _account = new AccountDto();
        public AccountDto Account
        {
            get => _account;
            set => Set(ref _account, value, nameof(Account));
        }


        private List<Account> _accounts = new List<Account>();
        public List<Account> Accounts
        {
            get => _accounts;
            set => Set(ref _accounts, value, nameof(Accounts));
        }

        private List<AccountDto> _filteredAccounts = new List<AccountDto>();
        public List<AccountDto> FilteredAccounts
        {
            get => _filteredAccounts;
            set => Set(ref _filteredAccounts, value, nameof(FilteredAccounts));
        }

        private IQueryable<AccountDto> _filteredAccounts2;
        public IQueryable<AccountDto> FilteredAccounts2
        {
            get => _filteredAccounts2;
            set => Set(ref _filteredAccounts2, value, nameof(FilteredAccounts2));
        }


        private DateTime? _startDate = DateTime.Now.StartOfMonth();
        public DateTime? StartDate
        {
            get => _startDate;
            set => Set(ref _startDate, value, nameof(StartDate));
        }

        private DateTime? _endDate = DateTime.Now.EndOfMonth();
        public DateTime? EndDate
        {
            get => _endDate;
            set => Set(ref _endDate, value, nameof(EndDate));
        }

        private string _type = "";
        public string Type
        {
            get => _type;
            set => Set(ref _type, value, nameof(Type));
        }
        public AccountComponent AccountComponent { get; set; } = new AccountComponent();
        #endregion

        public override async Task OnInitializedAsync()
        {
            await GetTransactions();
            await base.OnInitializedAsync();
        }

        public override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender) await _jsRuntime.InvokeVoidAsync("countUp");
            await base.OnAfterRenderAsync(firstRender);
        }

        #region FUNCTIONS
        public async Task GetTransactions()
        {
            Console.WriteLine("Getting transactions...");
            _isLoading = true;

            var startDate = _startDate ?? DateTime.Now.StartOfMonth();
            var endDate = _endDate ?? startDate.EndOfMonth();

            var session = _supabase.Auth.CurrentSession;
            var userId = !string.IsNullOrEmpty(session?.User?.Id) ? new Guid(session.User.Id) : Guid.Empty;

            var filters = new List<(string, Constants.Operator, object)>
            {
                ("user_id",        Constants.Operator.Equals, userId),
            };

            var allAccounts = await _accountService.GetAllAsync(filters);
            _accounts = allAccounts.OrderByDescending(t => t.Name).ToList();
            _filteredAccounts = _accounts.Select(a => new AccountDto
            {
                Id = a.Id,
                UserId = a.UserId,
                Amount = a.Amount,
                Type = a.Type,
                Name = a.Name,
                Description = a.Description,
                Currency = a.Currency,
            }).ToList();
            _isLoading = false;

            foreach (var account in allAccounts)
            {
                await _jsRuntime.InvokeVoidAsync("countUp2",$"{account.Id}", account.Amount);
            }

            //await _jsRuntime.InvokeVoidAsync("countUp2", "expense-text", _summary.Expense);
            //await _jsRuntime.InvokeVoidAsync("countUp2", "balance-text", balance);
            StateHasChanged();

        }

        public async Task SubmitAccountAsync(AccountDto account)
        {
            _isSaving = true;
            var session = _supabase.Auth.CurrentSession;
            var a = new Account()
            {
                Id = account.Id ?? Guid.Empty,
                UserId = account.UserId,
                Amount = account.Amount,
                Type = account.Type,
                Name = account.Name,
                Description = account.Description,
                Currency = account.Currency,
            };

            a.UserId =  new Guid(session?.User?.Id ?? "");
            if(a.Id == Guid.Empty)
             await _accountService.InsertAsync(a);
            else
             await _accountService.UpdateAsync(a);

            _isSaving = false;
            await AccountComponent.CloseAccount();
            await OnInitializedAsync();
        }
        #endregion
    }
}
