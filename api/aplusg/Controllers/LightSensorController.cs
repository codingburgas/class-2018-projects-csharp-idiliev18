using aplusg.Data.Models;
using aplusg.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aplusg.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LightSensorController : ControllerBase
	{
		private readonly AplusGDbContext _context;

		public LightSensorController(AplusGDbContext context)
		{
			_context = context;
		}

		// GET: api/<LightSensorController>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<LightSensor>>> GetAll()
		{
			return await _context.LightSensors.ToListAsync();
		}

		// GET api/<LightSensorController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult<LightSensor>> Get(int id)
		{
			var ls = await _context.LightSensors.FindAsync(id);
			return (ls is not null) ? ls : NotFound();

		}

		// POST api/<LightSensorController>
		[HttpPost("Create")]
		public ActionResult Post([FromBody] LightSensor lightSensor)
		{
			return Ok();
		}

		// DELETE api/<LightSensorController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
