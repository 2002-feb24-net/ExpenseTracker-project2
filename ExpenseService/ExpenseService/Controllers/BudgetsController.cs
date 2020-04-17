using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpenseServiceAPI.Models;

namespace ExpenseServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetsController : ControllerBase
    {
        private readonly RevatureDatabaseContext _context;

        public BudgetsController(RevatureDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Budgets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Budgets>>> GetBudgets()
        {
            return await _context.Budgets.ToListAsync();
        }

        // GET: api/Budgets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Budgets>> GetBudgets(int id)
        {
            var budgets = await _context.Budgets.FindAsync(id);

            if (budgets == null)
            {
                return NotFound();
            }

            return budgets;
        }

        // PUT: api/Budgets/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBudgets(int id, Budgets budgets)
        {
            if (id != budgets.Id)
            {
                return BadRequest();
            }

            _context.Entry(budgets).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BudgetsExists(id))
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

        // POST: api/Budgets
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Budgets>> PostBudgets(Budgets budgets)
        {
            _context.Budgets.Add(budgets);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBudgets", new { id = budgets.Id }, budgets);
        }

        // DELETE: api/Budgets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Budgets>> DeleteBudgets(int id)
        {
            var budgets = await _context.Budgets.FindAsync(id);
            if (budgets == null)
            {
                return NotFound();
            }

            _context.Budgets.Remove(budgets);
            await _context.SaveChangesAsync();

            return budgets;
        }

        private bool BudgetsExists(int id)
        {
            return _context.Budgets.Any(e => e.Id == id);
        }
    }
}
