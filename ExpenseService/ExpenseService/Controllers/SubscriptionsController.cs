using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpenseService.ServiceeAccess.Models;

namespace ExpenseServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly RevatureDatabaseContext _context;

        public SubscriptionsController(RevatureDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Subscriptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subscriptions>>> GetSubscriptions()
        {
            return await _context.Subscriptions.ToListAsync();
        }

        // GET: api/Subscriptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subscriptions>> GetSubscriptions(int id)
        {
            var subscriptions = await _context.Subscriptions.FindAsync(id);

            if (subscriptions == null)
            {
                return NotFound();
            }

            return subscriptions;
        }

        // PUT: api/Subscriptions/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscriptions(int id, Subscriptions subscriptions)
        {
            if (id != subscriptions.Id)
            {
                return BadRequest();
            }

            _context.Entry(subscriptions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriptionsExists(id))
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

        // POST: api/Subscriptions
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Subscriptions>> PostSubscriptions(Subscriptions subscriptions)
        {
            _context.Subscriptions.Add(subscriptions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubscriptions", new { id = subscriptions.Id }, subscriptions);
        }

        // DELETE: api/Subscriptions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Subscriptions>> DeleteSubscriptions(int id)
        {
            var subscriptions = await _context.Subscriptions.FindAsync(id);
            if (subscriptions == null)
            {
                return NotFound();
            }

            _context.Subscriptions.Remove(subscriptions);
            await _context.SaveChangesAsync();

            return subscriptions;
        }

        private bool SubscriptionsExists(int id)
        {
            return _context.Subscriptions.Any(e => e.Id == id);
        }
    }
}
