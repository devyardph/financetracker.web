using Blazor.IndexedDB;
using DYS.FinanceTracker.Shared.Dtos;
using Microsoft.JSInterop;

namespace DYS.FinanceTracker.Shared.Models
{
    public class FinanceTrackerDB : IndexedDb
    {
        public FinanceTrackerDB(IJSRuntime jSRuntime, string name, int version)
            : base(jSRuntime, name, version) { }
        public IndexedSet<TransactionDto> Transaction { get; set; }
        public IndexedSet<AccountDto> Account { get; set; }
    }
}
