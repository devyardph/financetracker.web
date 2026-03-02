using System.ComponentModel.DataAnnotations;

namespace DYS.FinanceTracker.Shared.Dtos
{
    public class AccountRegistrationDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string BaseUrl { get; set; }
        public bool PolicyAgreement { get; set; }
        public string Tenant { get; set; }
    }
}
