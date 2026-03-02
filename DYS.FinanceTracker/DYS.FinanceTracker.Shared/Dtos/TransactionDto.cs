using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYS.FinanceTracker.Shared.Dtos
{
    public class TransactionDto
    {
        public Guid? Id { get; set; } 
        public Guid? UserId { get; set; }
        public decimal? Amount { get; set; }
        public string Category { get; set; } 

        // "income" or "expense"
        public string Type { get; set; } 
        public string Description { get; set; } 
        public DateTime? Date { get; set; } = DateTime.UtcNow;

        // "none", "daily", "weekly", "monthly", "yearly"
        public string Recurrence { get; set; } = "none";
        public int? RecurrenceCount { get; set; }

        // Groups related recurring entries together
        public Guid? RecurrenceGroupId { get; set; }

        // Marks when this version of the recurring transaction starts
        public DateTime? EffectiveDate { get; set; } = DateTime.UtcNow;
        public DateTime? EndDate { get; set; }
    }
}
