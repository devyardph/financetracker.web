using DYS.FinanceTracker.Shared.Services;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace DYS.FinanceTracker.Shared.Models
{
    [Table("accounts")]
    public class Account : BaseModel, IHasId
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; } 
        [Column("user_id")]
        public Guid? UserId { get; set; }
        [Column("amount")]
        public decimal? Amount { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }

        // "credit" or "cash" or "bank" or "investment"
        [Column("type")]
        public string Type { get; set; }

        [Column("currency")]
        public string Currency { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
