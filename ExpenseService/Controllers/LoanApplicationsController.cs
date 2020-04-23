
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpenseService.DataAccess.Model;
using ExpenseService.Core.Interrfaces;
using ExpenseService.DataAccess;
using ExpenseServiceAPI.ApiModel;

namespace ExpenseServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanApplicationsController : ControllerBase
    {
        private readonly IApplication _repo;

        public LoanApplicationsController(IApplication repo)
        {

            _repo = repo;
        }

        // GET: api/LoanApplication
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ApiModel.ApiApplication>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetLoanApplication()
        {
            var ListOfLoanApplication = await _repo.GetLoanApplicationAsync();

            var resource = ListOfLoanApplication.Select(b => new ApiApplication
            {
                Id = b.Id,
                ApprovalDenialComformation = b.ApprovalDenialComformation,
                CreditScore = b.CreditScore,
                EstIncome = b.EstIncome,
                LoanAmount = b.LoanAmount,
                Ssn = b.Ssn,
                UserId = b.UserId,
                //Users = ApiMapper.MapUserApi(b.Users)
            });

            return Ok(resource);
        }

        // GET: api/LoanApplication/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiApplication), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> GetLoanApplication(int id)
        {
            var loan = await _repo.GetLoanApplicationByIdAsync(id);
            var resource = ApiMapper.MapApplication(loan);

            if (resource != null)
            {
                return Ok(resource);
            }

            
            return NotFound();
        }

        // PUT: api/LoanApplication/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoanApplication(int id, LoanApplication loan)
        {
            if (id != loan.Id)
            {
                return BadRequest();
            }

            var newLoanApplication = Mapper.MapApplication(loan);
            _repo.Changed(newLoanApplication);

            try
            {
                await _repo.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await LoanApplicationExists(id)))
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

        // POST: api/LoanApplicationApplication
        [HttpPost]
        public async Task<ActionResult> PostLoanApplicationApplication(LoanApplication loan)
        {
            var newLoanApplication = Mapper.MapApplication(loan);
            _ = _repo.AddLoanApplicationAsync(newLoanApplication);

            await _repo.SaveAsync();

            return CreatedAtAction("GetLoanApplication", new { id = loan.Id }, loan);
        }

        // DELETE: api/LoanApplication/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLoanApplication(int id)
        {
            var resource = await _repo.RemoveLoanApplicationAsync(id);

            return Ok(resource);
        }
        [HttpGet("{id}")]
        private Task<bool> LoanApplicationExists(int id)
        {
            return _repo.LoanApplicationExsistsAsync(id);
        }
    }
}
