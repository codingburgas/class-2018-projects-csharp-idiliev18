using aplusg.Data.Models;
using aplusg.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace aplusg.Services
{
	public interface IUserService
	{
		AuthResponse Authenticate(AuthRequest model);
		IEnumerable<User> GetAll();
		User GetById(int id);
	}
	public class UserService : IUserService
	{
		private AplusGDbContext _context;
		private List<User> users = new List<User>();
		public AuthResponse Authenticate(AuthRequest model)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<User> GetAll()
		{
			throw new NotImplementedException();
		}

		public User GetById(int id)
		{
			throw new NotImplementedException();
		}
	}
}
