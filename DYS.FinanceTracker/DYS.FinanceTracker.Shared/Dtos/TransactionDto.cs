using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DYS.FinanceTracker.Shared.Dtos
{
    public class TransactionDto
    {
        [Key]
        public Guid? Id { get; set; } 
        public Guid? UserId { get; set; }
        public Guid? AccountId { get; set; }
        public decimal? Amount { get; set; } = 0;
        public string Category { get; set; } = string.Empty;

        // "income" or "expense"
        public string Type { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? Date { get; set; } = DateTime.UtcNow;

        // "one-time", "daily", "weekly", "monthly", "yearly"
        public string Recurrence { get; set; } = "one-time";
        public int? RecurrenceCount { get; set; } = 0;

        // Groups related recurring entries together
        public Guid? RecurrenceGroupId { get; set; }

        // Marks when this version of the recurring transaction starts
        public DateTime? EffectiveDate { get; set; } = DateTime.UtcNow;
        public DateTime? EndDate { get; set; }
        public DateTime? DateCreated { get; set; } = DateTime.UtcNow;

        // For tracking synchronization status with the server
        //public bool? Sync { get; set; } = true;
        //public string SyncError { get; set; } = string.Empty;
    }
}
