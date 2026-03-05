using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYS.FinanceTracker.Shared.Dtos
{
    public class EmailDto
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public string HTML { get; set; } = string.Empty;
    }
}
