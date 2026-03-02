using DYS.FinanceTracker.Shared.Dtos;
using System;
using System.Collections.Generic;

namespace DYS.FinanceTracker.Shared.Dtos
{
	public class LoginResponse
	{
		public long UserId { get; set; }
		public string Token { get; set; }
		public string EncryptedAccessToken { get; set; }
		public int ExpireInSeconds { get; set; }
		public DateTime ExpirationDate { get; set; }

		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Roles { get; set; }

		public ProfileDto Profile { get; set; } = new ProfileDto();


    }
}
