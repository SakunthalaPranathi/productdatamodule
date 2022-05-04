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
    public class cartsController : ControllerBase
    {
        private readonly ProductContext _context;

        public cartsController(ProductContext context)
        {
            _context = context;
        }

        // GET: api/carts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cart>>> Getcart()
        {
            return await _context.cart.ToListAsync();
        }

        // GET: api/carts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<cart>> Getcart(int id)
        {
            var cart = await _context.cart.FindAsync(id);

            if (cart == null)
            {
                return NotFound();
            }

            return cart;
        }

        // PUT: api/carts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcart(int id, cart cart)
        {
            if (id != cart.id)
            {
                return BadRequest();
            }

            _context.Entry(cart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cartExists(id))
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

        // POST: api/carts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<cart>> Postcart(cart cart)
        {
            _context.cart.Add(cart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcart", new { id = cart.id }, cart);
        }

        // DELETE: api/carts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecart(int id)
        {
            var cart = await _context.cart.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            _context.cart.Remove(cart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool cartExists(int id)
        {
            return _context.cart.Any(e => e.id == id);
        }
    }
}
