using System;
using System.Collections.Generic;

namespace DYS.FinanceTracker.Shared.Dtos
{
	public class AccountResponseDto
	{
		public bool CanLogin { get; set; }
		public string Id { get; set; }
		public string Token { get; set; }
	}
}
