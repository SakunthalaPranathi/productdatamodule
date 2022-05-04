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
    public class salesController : ControllerBase
    {
        private readonly ProductContext _context;

        public salesController(ProductContext context)
        {
            _context = context;
        }

        // GET: api/sales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<sale>>> Getsale()
        {
            return await _context.sale.ToListAsync();
        }

        // GET: api/sales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<sale>> Getsale(int id)
        {
            var sale = await _context.sale.FindAsync(id);

            if (sale == null)
            {
                return NotFound();
            }

            return sale;
        }

        // PUT: api/sales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putsale(int id, sale sale)
        {
            if (id != sale.id)
            {
                return BadRequest();
            }

            _context.Entry(sale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!saleExists(id))
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

        // POST: api/sales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<sale>> Postsale(sale sale)
        {
            _context.sale.Add(sale);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getsale", new { id = sale.id }, sale);
        }

        // DELETE: api/sales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletesale(int id)
        {
            var sale = await _context.sale.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            _context.sale.Remove(sale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool saleExists(int id)
        {
            return _context.sale.Any(e => e.id == id);
        }
    }
}
