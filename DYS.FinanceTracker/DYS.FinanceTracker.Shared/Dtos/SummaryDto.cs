using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYS.FinanceTracker.Shared.Dtos
{
    public class SummaryDto
    {
        public decimal? Balance { get; set; }
        public decimal? Income { get; set; }
        public int? IncomeCount { get; set; }
        public decimal? Expense { get; set; }
        public int? ExpenseCount { get; set; }
    }
}
