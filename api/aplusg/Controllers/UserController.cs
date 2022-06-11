using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using aplusg.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.IO;
using aplusg.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Ng.Services;
using aplusg.Utilities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aplusg.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly AplusGDbContext _context;

		public UserController(AplusGDbContext context)
		{
			_context = context;
		}
		// GET: api/<UserController>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<User>>> GetUsers()
		{
			return await _context.Users.ToListAsync();
		}

		// GET api/<UserController>/5 
		[HttpGet("{id}")]
		public async Task<ActionResult<User>> Get(int id)
		{
			User user = await _context.Users.FindAsync(id);

			return (user is not null) ? user : NotFound();
		}

		// POST api/<UserController>
		[HttpPost]
		public async Task<ActionResult<User>> PostUser(User user)
		{
			await _context.Users.AddAsync(user);
			await _context.SaveChangesAsync();

			return CreatedAtAction("PostUser", new { id = user.Id }, user);

		}

		// DELETE api/<UserController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}

		[HttpPost("authenticate")]
		public ActionResult Authenticate(AuthRequest user)
		{
			var dbUser = _context.Users.First<User>(u => u.Username == user.Username);

			if (dbUser is null)
			{
				BadRequest(new { status = "Incorrect credentials" });
			}

			string? secret;

			var reader = new StreamReader("tokenconf.txt");
			using (reader)
			{
				secret = reader.ReadLine();
			}



			string token = TokenUtilities.CreateToken(secret, user, dbUser);

			return token is null ? BadRequest(new { status = "Incorrect credentials" }) : Ok(new { 
				status = "success",
				token = token,
				username = dbUser.Username,
				firstname = dbUser.FirstName,
				lastname = dbUser.LastName,
				email = dbUser.Email,
				tokenExpireDate = dbUser.ExpireDate,
				role = _context.UsersRoles.Where(ur => ur.UserId == dbUser.Id)
			});
		}

		//[Authorize]
		//[HttpGet]
		//public ActionResult GetUsersAuth()
		//{
		//	return Ok();
		//}
	}
}
