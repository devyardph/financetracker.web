using Blazor.IndexedDB;
using DYS.FinanceTracker.Shared.Dtos;
using Microsoft.JSInterop;

namespace DYS.FinanceTracker.Shared.Models
{
    public class AccountDB : IndexedDb
    {
        public AccountDB(IJSRuntime jSRuntime, string name, int version)
            : base(jSRuntime, name, version) { }
        public IndexedSet<AccountDto> Account { get; set; }
    }
}
