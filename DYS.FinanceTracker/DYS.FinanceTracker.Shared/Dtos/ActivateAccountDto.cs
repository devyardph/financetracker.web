using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DYS.FinanceTracker.Shared.Dtos
{
    public class ActivateAccountDto
    {
        public string UserId { get; set; }
        public string Token { get; set; }
    }
}
