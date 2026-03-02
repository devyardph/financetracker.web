using System.ComponentModel.DataAnnotations;

namespace DYS.FinanceTracker.Shared.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string UserNameOrEmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
