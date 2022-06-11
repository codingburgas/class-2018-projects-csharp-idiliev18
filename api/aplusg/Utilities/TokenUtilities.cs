using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aplusg.Data.Models;
using aplusg.Models;
using Ng.Services;

namespace aplusg.Utilities
{
	public static class TokenUtilities
	{
		public static string CreateToken(string secret, AuthRequest reqUser, User dbUser)
		{
			if (!PasswordUtilities.VerifyPassword(Encoding.ASCII.GetBytes(dbUser.Salt), dbUser.PasswordHash, reqUser.Password))
			{
				return null;
			}

			PasswordHashingService phs = new();
			var token = phs.HashPassword(secret + reqUser.Username + reqUser.Password);
			return token;

		}
	}
}
