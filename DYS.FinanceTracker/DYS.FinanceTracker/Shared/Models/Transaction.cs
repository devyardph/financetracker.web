using DYS.FinanceTracker.Shared.Data;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace DYS.FinanceTracker.Shared.Models
{
    [Table("transactions")]
    public class Transaction : BaseModel, IHasId
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; } 
        [Column("user_id")]
        public Guid? UserId { get; set; }
        [Column("amount")]
        public decimal? Amount { get; set; }
        [Column("category")]
        public string Category { get; set; }

        // "income" or "expense"
        [Column("type")]
        public string Type { get; set; }
        [Column("description")]
        public string Description { get; set; } 
        [Column("date")]
        public DateTime? Date { get; set; } = DateTime.UtcNow;

        // "none", "daily", "weekly", "monthly", "yearly"
        [Column("recurrence")]
        public string Recurrence { get; set; } = "none";
        [Column("recurrence_count")]
        public int? RecurrenceCount { get; set; } 

        // Groups related recurring entries together
        [Column("recurrence_group_id")]
        public Guid? RecurrenceGroupId { get; set; }

        // Marks when this version of the recurring transaction starts
        [Column("effective_date")]
        public DateTime? EffectiveDate { get; set; } = DateTime.UtcNow;
        [Column("end_date")]
        public DateTime? EndDate { get; set; } 

    }
}
