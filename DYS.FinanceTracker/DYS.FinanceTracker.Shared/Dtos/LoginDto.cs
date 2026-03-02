using System.ComponentModel.DataAnnotations;

namespace DYS.FinanceTracker.Shared.Dtos
{
    public class LoginDto
    {
        [Required]
        public string UserNameOrEmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberClient { get; set; } = true;
        public string Tenant { get; set; }
    }
}
