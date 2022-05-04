using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using productdatamodule.Models;

namespace productdatamodule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class foodsController : ControllerBase
    {
        private readonly ProductContext _context;

        public foodsController(ProductContext context)
        {
            _context = context;
        }

        // GET: api/foods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<food>>> Getfood()
        {
            return await _context.food.ToListAsync();
        }

        // GET: api/foods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<food>> Getfood(int id)
        {
            var food = await _context.food.FindAsync(id);

            if (food == null)
            {
                return NotFound();
            }

            return food;
        }

        // PUT: api/foods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putfood(int id, food food)
        {
            if (id != food.id)
            {
                return BadRequest();
            }

            _context.Entry(food).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!foodExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/foods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<food>> Postfood(food food)
        {
            _context.food.Add(food);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getfood", new { id = food.id }, food);
        }

        // DELETE: api/foods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletefood(int id)
        {
            var food = await _context.food.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }

            _context.food.Remove(food);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool foodExists(int id)
        {
            return _context.food.Any(e => e.id == id);
        }
    }
}
