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
        public string Name { get; set; }
        public string Description { get; set; }
        // "credit" or "cash" or "bank" or "investment"
        public string Type { get; set; }
        public string Currency { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
