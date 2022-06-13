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
using System.Text;

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

		[HttpPost("Authenticate")]
		public ActionResult Authenticate(AuthRequest user)
		{
			var dbUser = _context.Users.First(u => u.Username == user.Username);

			if (dbUser is null)
			{
				return BadRequest(new { status = "Incorrect credentials" });
			}

			string? secret;

			var reader = new StreamReader("tokenconf.txt");
			using (reader)
			{
				secret = reader.ReadLine();
			}



			string token = TokenUtilities.CreateToken(secret, user, dbUser);

			if(token is not null)
			{
				var u = _context.Users.SingleOrDefault(u => u.Id == dbUser.Id);
				if(u is not null)
				{
					u.Token = token;
					u.ExpireDate = DateTime.Now.AddDays(3);	
					_context.SaveChanges();
				}
			}

			return token is null ? BadRequest(new { status = "Incorrect credentials" }) : Ok(new {
				status = "success",
				//info = new AuthResponse(dbUser, token, DateTime.Today.AddDays(2)),
				role = _context.UsersRoles.Where(ur => ur.UserId == dbUser.Id)
			});
		}

		[HttpGet("Validate/Request")]
		public ActionResult GetMe()
		{
			var HTTPcontext = HttpContext.Request.PathBase;
			string authorization = this.HttpContext.Request.Headers["Authorization"];
			string decAuthToken;
			if (authorization != null && authorization.StartsWith("Bearer"))
			{
				//Extract credentials
				string authToken = authorization.Substring("Bearer ".Length).Trim();
				decAuthToken = authToken;
			}
			else
			{
				//Handle what happens if that isn't the case
				throw new Exception("The authorization header is either empty or isn't Basic.");
			}
			var user = _context.Users.SingleOrDefault(u => u.Token == decAuthToken);
			if(user is null)
			{
				return BadRequest(new { status = "Token invalid" });
			}

			if (user.ExpireDate < DateTime.Now)
			{
				return BadRequest(new { status = "Token invalid" });
			}

			return Ok(new
			{
				status = "success",
				info = new AuthResponse(user, decAuthToken, user.ExpireDate),
				role = _context.UsersRoles.Where(ur => ur.UserId == user.Id)
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
