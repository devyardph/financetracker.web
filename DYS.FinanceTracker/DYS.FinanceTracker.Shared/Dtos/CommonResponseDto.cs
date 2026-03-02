using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DYS.FinanceTracker.Shared.Dtos
{
    public class CommonResponseDto
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; } = false;
        public List<string> Errors { get; set; } = new List<string>();
    }
}
