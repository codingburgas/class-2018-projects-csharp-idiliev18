﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using aplusg.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Text.Json;
using aplusg.Services;
using aplusg.Data.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aplusg.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly AplusGDbContext _context;
		private readonly IUserService _service;

		public UserController(AplusGDbContext context, UserService service)
		{
			_context = context;
			_service = service;
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
			var result = _service.Authenticate(user);
			return result is null ? BadRequest(new { msg = "Username or password is not correct" }) : Ok(result);
		}

		//[Authorize]
		//[HttpGet]
		//public ActionResult GetUsersAuth()
		//{
		//	return Ok();
		//}
	}
}
