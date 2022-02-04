#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proj_back.Data;
using proj_back.Models;

namespace proj_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharityEventsTablesController : ControllerBase
    {
        private readonly GradprojdataContext _context;

        public CharityEventsTablesController(GradprojdataContext context)
        {
            _context = context;
        }

        // GET: api/CharityEventsTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharityEventsTable>>> GetCharityEventsTables()
        {
            return await _context.CharityEventsTables.ToListAsync();
        }

        // GET: api/CharityEventsTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CharityEventsTable>> GetCharityEventsTable(int id)
        {
            var charityEventsTable = await _context.CharityEventsTables.FindAsync(id);

            if (charityEventsTable == null)
            {
                return NotFound();
            }

            return charityEventsTable;
        }

        // PUT: api/CharityEventsTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharityEventsTable(int id, CharityEventsTable charityEventsTable)
        {
            if (id != charityEventsTable.EventId)
            {
                return BadRequest();
            }

            _context.Entry(charityEventsTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharityEventsTableExists(id))
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

        // POST: api/CharityEventsTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CharityEventsTable>> PostCharityEventsTable(CharityEventsTable charityEventsTable)
        {
            _context.CharityEventsTables.Add(charityEventsTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCharityEventsTable", new { id = charityEventsTable.EventId }, charityEventsTable);
        }

        // DELETE: api/CharityEventsTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharityEventsTable(int id)
        {
            var charityEventsTable = await _context.CharityEventsTables.FindAsync(id);
            if (charityEventsTable == null)
            {
                return NotFound();
            }

            _context.CharityEventsTables.Remove(charityEventsTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharityEventsTableExists(int id)
        {
            return _context.CharityEventsTables.Any(e => e.EventId == id);
        }
    }
}
