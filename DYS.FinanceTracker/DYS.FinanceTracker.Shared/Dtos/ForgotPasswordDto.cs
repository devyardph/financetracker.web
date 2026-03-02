using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DYS.FinanceTracker.Shared.Dtos
{
    public class ForgotPasswordDto
    {
        public string EmailAddress { get; set; }
        public string ClientUrl { get; set; }
    }
}
