using Blazored.LocalStorage;
using DYS.FinanceTracker.Shared.Dtos;
using DYS.FinanceTracker.Shared.Data;
using DYS.FinanceTracker.Shared.Models;
using DYS.FinanceTracker.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace DYS.FinanceTracker.Features.Test.ViewModels
{
    //public class PaymentsViewModel : BaseViewModel
    //{

    //    private readonly ISupabaseService<Income> _paymentService;
    //    public readonly IConfiguration _configuration;

    //    public PaymentsViewModel(NavigationManager navigationManager, IJSRuntime jsRuntime,
    //        ILocalStorageService localStorageService,
    //        ISupabaseService<Income> paymentService,
    //        IConfiguration configuration,
    //        Supabase.Client client)
    //        : base(navigationManager, jsRuntime, client)
    //    {
    //        _paymentService = paymentService;
    //        _navigationManager = navigationManager;
    //        _configuration = configuration;
    //    }

    //    #region PROPERTIES
    //    private List<PaymentDto> _payments = new List<PaymentDto>();
    //    public List<PaymentDto> Payments
    //    {
    //        get => _payments;
    //        set => Set(ref _payments, value, nameof(Payments));
    //    }
    //    #endregion

    //    #region FUNCTIONS

    //    public override async Task OnAfterRenderAsync(bool firstRender)
    //    {
    //        if (firstRender)
    //        {
    //            await base.OnAfterRenderAsync(firstRender);
    //            await GetPaymentsAsync();
    //        }
    //    }

    //    public async Task GetPaymentsAsync()
    //    {
    //        IsLoading = true;
    //        _search.CurrentPage = 1;
    //        _search.PageSize = 20;
    //        _search.Id = _profile?.Id ?? string.Empty;
    //        var output = await _paymentService.GetAllAsync();
    //    }
    //    #endregion
    //}
}
