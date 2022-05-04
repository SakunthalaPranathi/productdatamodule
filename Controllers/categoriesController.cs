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
    public class categoriesController : ControllerBase
    {
        private readonly ProductContext _context;

        public categoriesController(ProductContext context)
        {
            _context = context;
        }

        // GET: api/categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<category>>> Getcategory()
        {
            return await _context.category.ToListAsync();
        }

        // GET: api/categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<category>> Getcategory(int id)
        {
            var category = await _context.category.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcategory(int id, category category)
        {
            if (id != category.id)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!categoryExists(id))
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

        // POST: api/categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<category>> Postcategory(category category)
        {
            _context.category.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcategory", new { id = category.id }, category);
        }

        // DELETE: api/categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecategory(int id)
        {
            var category = await _context.category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.category.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool categoryExists(int id)
        {
            return _context.category.Any(e => e.id == id);
        }
    }
}
