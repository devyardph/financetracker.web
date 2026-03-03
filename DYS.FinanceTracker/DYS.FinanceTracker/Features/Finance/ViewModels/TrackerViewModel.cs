using AutoMapper;
using DYS.FinanceTracker.Features.Accounts.Services;
using DYS.FinanceTracker.Features.Finance.Components;
using DYS.FinanceTracker.Shared.Data;
using DYS.FinanceTracker.Shared.Dtos;
using DYS.FinanceTracker.Shared.Extensions;
using DYS.FinanceTracker.Shared.Models;
using DYS.FinanceTracker.Shared.Services;
using DYS.FinanceTracker.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Supabase;
using Supabase.Postgrest;


namespace DYS.FinanceTracker.Features.Finance.ViewModels
{
    public class TrackerViewModel : BaseViewModel
    {

        private readonly ISupabaseService<Transaction> _transactionService;
        private readonly Supabase.Client _supabase;
        public TrackerViewModel(NavigationManager navigationManager,
            IJSRuntime jsRuntime, 
            ISupabaseService<Transaction> transactionService,
            ISupabaseAuthProvider supabaseAuthProvider,
            Supabase.Client supabase)
            : base(navigationManager, jsRuntime, supabaseAuthProvider)
        {
            _transactionService = transactionService;
            _supabase = supabase;
        }


        #region PROPERTIES
        private TransactionDto _transaction = new TransactionDto();
        public TransactionDto Transaction
        {
            get => _transaction;
            set => Set(ref _transaction, value, nameof(Transaction));
        }


        private List<Transaction> _transactions = new List<Transaction>();
        public List<Transaction> Transactions
        {
            get => _transactions;
            set => Set(ref _transactions, value, nameof(Transactions));
        }

        private List<TransactionDto> _filteredTransactions = new List<TransactionDto>();
        public List<TransactionDto> FilteredTransactions
        {
            get => _filteredTransactions;
            set => Set(ref _filteredTransactions, value, nameof(FilteredTransactions));
        }

        private SummaryDto _summary = new SummaryDto();
        public SummaryDto Summary
        {
            get => _summary;
            set => Set(ref _summary, value, nameof(Summary));
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
        public TransactionComponent TransactionComponent { get; set; } = new TransactionComponent();
        #endregion

        public override async Task OnInitializedAsync()
        {
            await GetTransactions();
            await base.OnInitializedAsync();
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
                ("user_id",        Constants.Operator.Equals,           userId),
                ("effective_date", Constants.Operator.LessThanOrEqual,  endDate),
            };

            var allTransactions = await _transactionService.GetAllAsync(filters);
       
            // Filter end_date: include if null OR end_date >= startDate
            _transactions = allTransactions
                .Where(t => (t.EndDate == null || t.EndDate >= startDate))
                .ToList();

            var expanded = new List<Transaction>();

            foreach (var t in _transactions)
            {
                // Non-recurring
                if (t.Recurrence == "one-time")
                {
                    if (t.Date >= startDate && t.Date <= endDate)
                        expanded.Add(t);
                }
                // Yearly recurrence (only once per year)
                else if (t.Recurrence == "yearly")
                {
                    var yearlyDate = new DateTime(startDate.Year, t.EffectiveDate.Value.Month, t.EffectiveDate.Value.Day);

                    if (yearlyDate >= startDate && yearlyDate <= endDate &&
                        (t.EndDate == null || yearlyDate <= t.EndDate))
                    {
                        expanded.Add(new Transaction
                        {
                            Id = t.Id,
                            UserId = t.UserId,
                            Amount = t.Amount,
                            Category = t.Category,
                            Type = t.Type,
                            Description = t.Description,
                            Date = yearlyDate,
                            Recurrence = t.Recurrence,
                            RecurrenceCount = t.RecurrenceCount,
                            RecurrenceGroupId = t.RecurrenceGroupId,
                            EffectiveDate = t.EffectiveDate,
                            EndDate = t.EndDate
                        });
                    }
                }
                // Daily, weekly, monthly expansion
                else
                {
                    var nextDate = t.EffectiveDate > startDate ? t.EffectiveDate : startDate;
                    //continuous transactions
                    if (t.EndDate == null)
                    {
                        // If EndDate is null, only show the transaction once (at EffectiveDate if in range)
                        if (nextDate >= startDate && nextDate <= endDate)
                        {
                            expanded.Add(new Transaction
                            {
                                Id = t.Id,
                                UserId = t.UserId,
                                Amount = t.Amount,
                                Category = t.Category,
                                Type = t.Type,
                                Description = t.Description,
                                Date = nextDate,
                                Recurrence = t.Recurrence,
                                RecurrenceGroupId = t.RecurrenceGroupId,
                                EffectiveDate = t.EffectiveDate,
                                EndDate = t.EndDate
                            });
                        }
                    }
                    else
                    {
                        // If EndDate is set, expand until EndDate
                        while (nextDate <= endDate && nextDate <= t.EndDate)
                        {
                            expanded.Add(new Transaction
                            {
                                Id = t.Id,
                                UserId = t.UserId,
                                Amount = t.Amount,
                                Category = t.Category,
                                Type = t.Type,
                                Description = t.Description,
                                Date = nextDate,
                                Recurrence = t.Recurrence,
                                RecurrenceCount = t.RecurrenceCount,
                                RecurrenceGroupId = t.RecurrenceGroupId,
                                EffectiveDate = t.EffectiveDate,
                                EndDate = t.EndDate
                            });

                            var candidate = DateExtensions.GetNextDate(nextDate.Value, t.Recurrence);
                            if (candidate == null) break;
                            nextDate = candidate;
                        }
                    }
                }
            }

            _transactions = expanded.Where(q => q.Date >= startDate && q.Date <= endDate).ToList();
            _filteredTransactions = _transactions.Select(t =>
  new TransactionDto()
  {
      Id = t.Id,
      UserId = t.UserId,
      Amount = t.Amount,
      Category = t.Category,
      Type = t.Type,
      Description = t.Description,
      Date = t.Date,
      Recurrence = t.Recurrence,
      RecurrenceCount = t.RecurrenceCount,
      RecurrenceGroupId = t.RecurrenceGroupId,
      EffectiveDate = t.EffectiveDate,
      EndDate = t.EndDate
  }
 ).ToList();

            var income = _filteredTransactions.Where(q => q.Type == "income").ToList();
            var expense = _filteredTransactions.Where(q => q.Type == "expense").ToList();

            var totalIncome = income.Sum(q => q.Amount);
            var totalExpense = expense.Sum(q => q.Amount);
            var balance = totalIncome - totalExpense;

            _summary = new SummaryDto() { Balance = balance, 
                Income = totalIncome, 
                IncomeCount = income.Count(),
                Expense = totalExpense,
                ExpenseCount = expense.Count()
            };

            _isLoading = false;
        }


        public void ReloadTransactions(string type) 
        {
            _isLoading = true;
            _type = type;
            var filteredTransactions = !string.IsNullOrEmpty(type) ? 
                                    _transactions.Where(query => query.Type == type).ToList() : 
                                    _transactions.ToList();
            _filteredTransactions = filteredTransactions.Select(t =>
              new TransactionDto()
              {
                  Id = t.Id,
                  UserId = t.UserId,
                  Amount = t.Amount,
                  Category = t.Category,
                  Type = t.Type,
                  Description = t.Description,
                  Date = t.Date,
                  Recurrence = t.Recurrence,
                  RecurrenceCount = t.RecurrenceCount,
                  RecurrenceGroupId = t.RecurrenceGroupId,
                  EffectiveDate = t.EffectiveDate,
                  EndDate = t.EndDate
              }
             ).ToList();

            Console.WriteLine($"Filtered transactions count: {type} {_transactions.Count}");
            _isLoading = false;
        }

        public async Task SubmitTransactionAsync(TransactionDto t)
        {
            _isSaving = true;
            var session = _supabase.Auth.CurrentSession;
            var transaction = new Transaction()
            {
                Id = t.Id ?? Guid.Empty,
                UserId = t.UserId,
                Amount = t.Amount,
                Category = t.Category,
                Type = t.Type,
                Description = t.Description,
                Date = t.Date,
                Recurrence = t.Recurrence,
                RecurrenceCount = t.RecurrenceCount,
                RecurrenceGroupId = t.RecurrenceGroupId,
                EffectiveDate = t.EffectiveDate,
                EndDate = t.EndDate
            };

            transaction.UserId =  new Guid(session?.User?.Id ?? "");
            if(transaction.Id == Guid.Empty)
             await _transactionService.InsertAsync(transaction);
            else
             await _transactionService.UpdateAsync(transaction);

            _isSaving = false;
            await TransactionComponent.CloseTransaction();
            await OnInitializedAsync();
      
        }
        #endregion
    }
}
