using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoQusApi.Models;
using FoQusApi.Models.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoQusApi.Controllers
{
    [Route("api/FoQus")]
    [ApiController]
    public class FoQusController : ControllerBase
    {
        private readonly FoQusContext _context;

        public FoQusController(FoQusContext context)
        {
            _context = context;

            //if (_context.FoQusItems.Count() == 0)
            //{
            //    // Create a new FoQusItem if collection is empty,
            //    // which means you can't delete all FoQusItems.
            //    _context.FoQusItems.Add(new FoQusItem { Name = "Item1" });
            //    _context.SaveChanges();
            //}
        }

        // GET: api/FoQus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoQusItem>>> GetFoQusItems()
        {
            return await _context.FoQusItems.ToListAsync();
        }

        // GET: api/FoQus/69
        [HttpGet("{id}")]
        public async Task<ActionResult<FoQusItem>> GetFoQusItem(long id)
        {
            var foQusItem = await _context.FoQusItems.FindAsync(id);

            if (foQusItem == null)
            {
                return NotFound();
            }

            return foQusItem;
        }

        // POST: api/FoQus
        [HttpPost]
        public async Task<ActionResult<FoQusItem>> PostFoQusItem(FoQusItem item)
        {
            _context.FoQusItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFoQusItem), new { id = item.Id }, item);
        }

        // PUT: api/FoQus/69
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoQusItem(long id, FoQusItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/FoQus/69
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoQusItem(long id)
        {
            var foQusItem = await _context.FoQusItems.FindAsync(id);

            if (foQusItem == null)
            {
                return NotFound();
            }

            _context.FoQusItems.Remove(foQusItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}