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
    public class discountsController : ControllerBase
    {
        private readonly ProductContext _context;

        public discountsController(ProductContext context)
        {
            _context = context;
        }

        // GET: api/discounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<discount>>> Getdiscount()
        {
            return await _context.discount.ToListAsync();
        }

        // GET: api/discounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<discount>> Getdiscount(int id)
        {
            var discount = await _context.discount.FindAsync(id);

            if (discount == null)
            {
                return NotFound();
            }

            return discount;
        }

        // PUT: api/discounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putdiscount(int id, discount discount)
        {
            if (id != discount.id)
            {
                return BadRequest();
            }

            _context.Entry(discount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!discountExists(id))
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

        // POST: api/discounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<discount>> Postdiscount(discount discount)
        {
            _context.discount.Add(discount);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getdiscount", new { id = discount.id }, discount);
        }

        // DELETE: api/discounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletediscount(int id)
        {
            var discount = await _context.discount.FindAsync(id);
            if (discount == null)
            {
                return NotFound();
            }

            _context.discount.Remove(discount);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool discountExists(int id)
        {
            return _context.discount.Any(e => e.id == id);
        }
    }
}
