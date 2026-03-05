using Blazor.IndexedDB;
using DYS.FinanceTracker.Shared.Dtos;
using Microsoft.JSInterop;

namespace DYS.FinanceTracker.Shared.Models
{
    public class TransactionDB: IndexedDb
    {
        public TransactionDB(IJSRuntime jSRuntime, string name, int version)
            : base(jSRuntime, name, version) { }
        public IndexedSet<TransactionDto> Transaction { get; set; }
    }
}
