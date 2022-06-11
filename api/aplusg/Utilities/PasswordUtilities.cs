using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;

namespace aplusg.Utilities
{
	public static class PasswordUtilities
	{
		public static string GenerateSalt()
		{
			var saltBytes = new byte[100];
			var provider = new RNGCryptoServiceProvider();
			provider.GetNonZeroBytes(saltBytes);
			var salt = Convert.ToBase64String(saltBytes);

			return salt;
		}

		public static string GenerateHash(string password, byte[] saltBytes)
		{
			var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);
			var hashPassword = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

			return hashPassword;
		}

		public static bool VerifyPassword(byte[] dbSalt, string dbHash, string reqPassword)
		{
			return GenerateHash(reqPassword, dbSalt) == dbHash;
		}

		//public static string GenerateHash(string password, byte[] salt)
		//{
		//	string hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
		//	password: password,
		//	salt: salt,
		//	prf: KeyDerivationPrf.HMACSHA256,
		//	iterationCount: 100000,
		//	numBytesRequested: 256 / 8));

		//	return hash;
		//}

		//public static byte[] GenerateSalt()
		//{
		//	byte[] salt = new byte[128 / 8];
		//	using (var rngCsp = new RNGCryptoServiceProvider())
		//	{
		//		rngCsp.GetNonZeroBytes(salt);
		//	}

		//	return salt;
		//}
	}
}
