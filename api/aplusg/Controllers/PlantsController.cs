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
	public class PlantsController : ControllerBase
	{
		private readonly AplusGDbContext _context;

		public PlantsController(AplusGDbContext context)
		{
			_context = context;
		}

		// GET: api/<PlantsController>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Plant>>> GetPlants()
		{
			return await _context.Plants.ToListAsync();
		}

		// GET api/<PlantsController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Plant>> Get(int id)
		{
			Plant plant = await _context.Plants.FindAsync(id);

			return (plant is not null) ? plant : NotFound();
		}

		// POST api/<PlantsController>
		[HttpPost]
		public async Task<ActionResult<Plant>> PostPlant(Plant plant)
		{
			await _context.Plants.AddAsync(plant);
			await _context.SaveChangesAsync();

			return CreatedAtAction("PostPlant", new { id = plant.Id }, plant);

		}

		// PUT api/<PlantsController>/5
		[HttpPut("{id}")]
		public async Task<ActionResult> UpdatePlant(int id, Plant plant)
		{
			if (id != plant.Id)
			{
				return BadRequest(new { message = "Invalid plant" });
			}

			_context.Entry(plant).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!_context.Plants.Any(p => id == p.Id))
				{
					return NotFound(new { message = "Plant not found" });
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// DELETE api/<PlantsController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var plant = await _context.Plants.FindAsync(id);
			if (plant == null)
			{
				return NotFound(new { message = "Plant not found" });
			}

			_context.Plants.Remove(plant);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}
