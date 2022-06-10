using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aplusg.Data.Models;
using Ng.Services;

namespace aplusg.Utilities
{
	public static class TokenUtilities
	{
		public static string CreateToken(string token, AuthRequest user)
		{
			PasswordHashingService phs = new();
			return phs.HashPassword(token + user.Username + user.Password);
		}
	}
}
