using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DYS.FinanceTracker.Shared.Dtos
{
    public class ErrorResponseDto
    {
        public string Code { get; set; }
        public string Details { get; set; }
        public string Message { get; set; }
    }
}
