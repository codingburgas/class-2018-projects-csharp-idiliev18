using aplusg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aplusg.Data.Models
{
	public class AuthResponse
	{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }


        public AuthResponse(User user, string token, DateTime dateTime)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.Username;
            Token = token;
            ExpireDate = dateTime;
        }
    }
}
