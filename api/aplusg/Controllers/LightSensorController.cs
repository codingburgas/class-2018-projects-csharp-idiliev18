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
			return (ls is not null) ? ls : NotFound(new { message = "Sensor not found" });

		}

		// POST api/<LightSensorController>
		[HttpPost("Create")]
		public async Task<ActionResult> PostLightSensor([FromBody] LightSensor lightSensor)
		{
			_context.LightSensors.Add(lightSensor);
			await _context.SaveChangesAsync();

			return CreatedAtAction("PostLightSensor", new { id = lightSensor.Id }, lightSensor);
		}

		// PUT: api/LightSensor/5
		[HttpPut("{id}")]
		public async Task<ActionResult> UpdateLightSensor(int id, LightSensor lightSensor)
		{
			if (id != lightSensor.Id)
			{
				return BadRequest(new { message = "Invalid light sensor" });
			}

			_context.Entry(lightSensor).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!_context.LightSensors.Any(ls => id == ls.Id))
				{
					return NotFound(new { message = "Light sensor not found" });
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// DELETE api/<LightSensorController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var lightSensor = await _context.LightSensors.FindAsync(id);
			if (lightSensor == null)
			{
				return NotFound(new { message = "Light sensor not found" });
			}

			_context.LightSensors.Remove(lightSensor);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}
