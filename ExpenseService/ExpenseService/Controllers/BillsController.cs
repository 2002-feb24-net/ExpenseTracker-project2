using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpenseService.ServiceeAccess.Models;
using ExpenseService.Domain.Interrfaces;

namespace ExpenseServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly RevatureDatabaseContext _context;
        private readonly IBillsRepository _repo;

        public BillsController(RevatureDatabaseContext context, IBillsRepository repo)
        {
            _context = context;
            _repo = repo;
        }

        // GET: api/Bills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bills>>> GetBills()
        {
            return await _context.Bills.ToListAsync();
        }

        // GET: api/Bills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bills>> GetBills(int id)
        {
            var bills = await _context.Bills.FindAsync(id);

            if (bills == null)
            {
                return NotFound();
            }

            return bills;
        }

        // PUT: api/Bills/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBills(int id, Bills bills)
        {
            if (id != bills.Id)
            {
                return BadRequest();
            }

            _context.Entry(bills).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillsExists(id))
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

        // POST: api/Bills
        [HttpPost]
        public async Task<ActionResult<Bills>> PostBills(Bills bills)
        {
            _context.Bills.Add(bills);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBills", new { id = bills.Id }, bills);
        }

        // DELETE: api/Bills/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bills>> DeleteBills(int id)
        {
            var bills = await _context.Bills.FindAsync(id);
            if (bills == null)
            {
                return NotFound();
            }

            _context.Bills.Remove(bills);
            await _context.SaveChangesAsync();

            return bills;
        }

        private bool BillsExists(int id)
        {
            return _context.Bills.Any(e => e.Id == id);
        }
    }
}
