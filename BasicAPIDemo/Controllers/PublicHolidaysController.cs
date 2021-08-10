using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BasicAPIDemo.Data;
using BasicAPIDemo.Models;

namespace BasicAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicHolidaysController : ControllerBase
    {
        private readonly BasicAPIDemoContext _context;

        public PublicHolidaysController(BasicAPIDemoContext context)
        {
            _context = context;
        }

        // GET: api/PublicHolidays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicHoliday>>> GetPublicHoliday()
        {
            return await _context.PublicHoliday.ToListAsync();
        }

        // GET: api/PublicHolidays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicHoliday>> GetPublicHoliday(string id)
        {
            var publicHoliday = await _context.PublicHoliday.FindAsync(id);

            if (publicHoliday == null)
            {
                return NotFound();
            }

            return publicHoliday;
        }

        // PUT: api/PublicHolidays/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublicHoliday(string id, PublicHoliday publicHoliday)
        {
            if (id != publicHoliday.PublicholidayID)
            {
                return BadRequest();
            }

            _context.Entry(publicHoliday).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicHolidayExists(id))
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

        // POST: api/PublicHolidays
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PublicHoliday>> PostPublicHoliday(PublicHoliday publicHoliday)
        {
            _context.PublicHoliday.Add(publicHoliday);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PublicHolidayExists(publicHoliday.PublicholidayID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPublicHoliday", new { id = publicHoliday.PublicholidayID }, publicHoliday);
        }

        // DELETE: api/PublicHolidays/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicHoliday>> DeletePublicHoliday(string id)
        {
            var publicHoliday = await _context.PublicHoliday.FindAsync(id);
            if (publicHoliday == null)
            {
                return NotFound();
            }

            _context.PublicHoliday.Remove(publicHoliday);
            await _context.SaveChangesAsync();

            return publicHoliday;
        }

        private bool PublicHolidayExists(string id)
        {
            return _context.PublicHoliday.Any(e => e.PublicholidayID == id);
        }
    }
}
