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
    public class LoanApplicationsController : ControllerBase
    {
        private readonly RevatureDatabaseContext _context;

        public LoanApplicationsController(RevatureDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/LoanApplications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanApplication>>> GetLoanApplication()
        {
            return await _context.LoanApplication.ToListAsync();
        }

        // GET: api/LoanApplications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoanApplication>> GetLoanApplication(int id)
        {
            var loanApplication = await _context.LoanApplication.FindAsync(id);

            if (loanApplication == null)
            {
                return NotFound();
            }

            return loanApplication;
        }

        // PUT: api/LoanApplications/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoanApplication(int id, LoanApplication loanApplication)
        {
            if (id != loanApplication.Id)
            {
                return BadRequest();
            }

            _context.Entry(loanApplication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanApplicationExists(id))
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

        // POST: api/LoanApplications
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<LoanApplication>> PostLoanApplication(LoanApplication loanApplication)
        {
            _context.LoanApplication.Add(loanApplication);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoanApplication", new { id = loanApplication.Id }, loanApplication);
        }

        // DELETE: api/LoanApplications/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LoanApplication>> DeleteLoanApplication(int id)
        {
            var loanApplication = await _context.LoanApplication.FindAsync(id);
            if (loanApplication == null)
            {
                return NotFound();
            }

            _context.LoanApplication.Remove(loanApplication);
            await _context.SaveChangesAsync();

            return loanApplication;
        }

        private bool LoanApplicationExists(int id)
        {
            return _context.LoanApplication.Any(e => e.Id == id);
        }
    }
}
