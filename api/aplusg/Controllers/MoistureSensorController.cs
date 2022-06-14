using aplusg.Data.Models;
using aplusg.Models;
using Microsoft.AspNetCore.Http;
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
	public class MoistureSensorController : ControllerBase
	{
		private readonly AplusGDbContext _context;

		public MoistureSensorController(AplusGDbContext context)
		{
			_context = context;
		}

		// GET: api/<LightSensorController>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<MoistureSensor>>> GetAll()
		{
			return await _context.MoistureSensors.ToListAsync();
		}

		// GET api/<LightSensorController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult<MoistureSensor>> Get(int id)
		{
			var ls = await _context.MoistureSensors.FindAsync(id);
			return (ls is not null) ? ls : NotFound(new { message = "Sensor not found" });
		}

		// POST api/<ValuesController>
		[HttpPost("Create")]
		public async Task<ActionResult> PostMoistureSensor([FromBody] MoistureSensor moistureSensor)
		{
			_context.MoistureSensors.Add(moistureSensor);
			await _context.SaveChangesAsync();

			return CreatedAtAction("PostMoistureSensor", new { id = moistureSensor.Id }, moistureSensor);
		}

		// DELETE api/<ValuesController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var moistureSensor = await _context.MoistureSensors.FindAsync(id);
			if (moistureSensor == null)
			{
				return NotFound();
			}

			_context.MoistureSensors.Remove(moistureSensor);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}
