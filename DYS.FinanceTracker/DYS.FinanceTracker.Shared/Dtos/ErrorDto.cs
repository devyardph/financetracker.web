using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DYS.FinanceTracker.Shared.Dtos
{
    public class ErrorDto
    {
        public string Field { get; set; }
        public string? ErrorMessage { get; set; }
        public string Style { get; set; }

    }
}
