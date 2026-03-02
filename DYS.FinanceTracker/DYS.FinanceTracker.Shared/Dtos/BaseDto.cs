using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYS.FinanceTracker.Shared.Dtos
{
    public class BaseDto
    {
        public string Id { get; set; } = string.Empty;
        public bool Options { get; set; } = false;
    }
}
