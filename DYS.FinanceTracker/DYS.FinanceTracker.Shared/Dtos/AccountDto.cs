using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYS.FinanceTracker.Shared.Dtos
{
    public class AccountDto
    {
        [Key]
        public Guid? Id { get; set; } 
        public Guid? UserId { get; set; }
        public decimal? Amount { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        // "credit" or "cash" or "bank" or "investment"
        public string Type { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
