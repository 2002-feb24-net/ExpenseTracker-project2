using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpenseService.ServiceeAccess.Models;
using ExpenseService.Domain.Interrfaces;
using ExpenseService.ServiceeAccess;
using ExpenseServiceAPI.ApiModel;

namespace ExpenseServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly ILoanRepository _repo;

        public LoansController(ILoanRepository repo)
        {

            _repo = repo;
        }

        // GET: api/Loan
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ApiModel.Loan>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetLoan()
        {
            var ListOfLoan = await _repo.GetLoanAsync();

            var resource = ListOfLoan.Select(b => new ApiModel.Loan
            {
                Id = b.Id,
                AccumulatedCost = b.AccumulatedCost,
                InterestRate = b.InterestRate,
                MonthlyRate = b.MonthlyRate,
                RetainingCost = b.RetainingCost,
                UserId = b.UserId,
                CurrentUser = ApiMapper.MapUserApi(b.CurrentUser)
            });

            return Ok(resource);
        }

        // GET: api/Loan/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiModel.Loan), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> GetLoan(int id)
        {
            var loan = await _repo.GetLoanByIdAsync(id);
            var resource = ApiMapper.MapLoanApi(loan);

            if (loan == null)
            {
                return NotFound();
            }

            return Ok(resource);
        }

        // PUT: api/Loan/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoan(int id, ExpenseService.ServiceeAccess.Models.Loan loan)
        {
            if (id != loan.Id)
            {
                return BadRequest();
            }

            var newLoan = Mapper.MapLoan(loan);
            _repo.Changed(newLoan);

            try
            {
                await _repo.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await LoanExists(id)))
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

        // POST: api/Loan
        [HttpPost]
        public async Task<ActionResult> PostLoan(ExpenseService.ServiceeAccess.Models.Loan loan)
        {
            var newLoan = Mapper.MapLoan(loan);
            _ = _repo.AddLoanAsync(newLoan);

            await _repo.SaveAsync();

            return CreatedAtAction("GetLoan", new { id = loan.Id }, loan);
        }

        // DELETE: api/Loan/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLoan(int id)
        {
            var resource = await _repo.RemoveLoanAsync(id);

            return Ok(resource);
        }

        private Task<bool> LoanExists(int id)
        {
            return _repo.LoanExsistsAsync(id);
        }
    }
}
