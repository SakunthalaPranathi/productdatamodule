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
    public class productsoldsController : ControllerBase
    {
        private readonly ProductContext _context;

        public productsoldsController(ProductContext context)
        {
            _context = context;
        }

        // GET: api/productsolds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<productsold>>> Getproductsold()
        {
            return await _context.productsold.ToListAsync();
        }

        // GET: api/productsolds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<productsold>> Getproductsold(int id)
        {
            var productsold = await _context.productsold.FindAsync(id);

            if (productsold == null)
            {
                return NotFound();
            }

            return productsold;
        }

        // PUT: api/productsolds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putproductsold(int id, productsold productsold)
        {
            if (id != productsold.id)
            {
                return BadRequest();
            }

            _context.Entry(productsold).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!productsoldExists(id))
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

        // POST: api/productsolds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<productsold>> Postproductsold(productsold productsold)
        {
            _context.productsold.Add(productsold);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getproductsold", new { id = productsold.id }, productsold);
        }

        // DELETE: api/productsolds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteproductsold(int id)
        {
            var productsold = await _context.productsold.FindAsync(id);
            if (productsold == null)
            {
                return NotFound();
            }

            _context.productsold.Remove(productsold);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool productsoldExists(int id)
        {
            return _context.productsold.Any(e => e.id == id);
        }
    }
}
