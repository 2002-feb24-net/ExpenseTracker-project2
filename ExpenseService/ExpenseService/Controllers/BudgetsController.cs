using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpenseService.ServiceeAccess.Models;
using ExpenseService.Domain.Interrfaces;
using ExpenseServiceAPI.ApiModel;
using ExpenseService.ServiceeAccess;

namespace ExpenseServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetsController : ControllerBase
    {
        private readonly IBudgetRepository _repo;

        public BudgetsController(IBudgetRepository repo)
        {

            _repo = repo;
        }

        // GET: api/Bills
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ApiModel.Budgets>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetBudgets()
        {
            var ListOfBudgets = await _repo.GetBudgetsAsync();

            var resource = ListOfBudgets.Select(b => new ApiModel.Budgets
            {
                Id = b.Id,
                ActualCost = b.ActualCost,
                EstimatedCost = b.EstimatedCost,
                UserId = b.UserId,
                User = ApiMapper.MapUserApi(b.CurrentUser)
            });

            return Ok(resource);
        }

        // GET: api/Bills/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiModel.Budgets), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> GetBudgets(int id)
        {
            var budgets = await _repo.GetBudgetByIdAsync(id);
            var resource = ApiMapper.MapBudgets(budgets);

            if (budgets == null)
            {
                return NotFound();
            }

            return Ok(resource);
        }

        // PUT: api/Bills/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBudgets(int id, ExpenseService.ServiceeAccess.Models.Budgets budgets)
        {
            if (id != budgets.Id)
            {
                return BadRequest();
            }

            var newBudgets = Mapper.MapBudgets(budgets);
            _repo.Changed(newBudgets);

            try
            {
                await _repo.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await BudgetsExists(id)))
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
        public async Task<ActionResult> PostBudgets(ExpenseService.ServiceeAccess.Models.Budgets budgets)
        {
            var newBudgets = Mapper.MapBudgets(budgets);
            _ = _repo.AddBudgetAsync(newBudgets);

            await _repo.SaveAsync();

            return CreatedAtAction("GetBudgets", new { id = budgets.Id }, budgets);
        }

        // DELETE: api/Bills/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBudgets(int id)
        {
            var resource = await _repo.RemoveBudgetAsync(id);

            return Ok(resource);
        }

        private Task<bool> BudgetsExists(int id)
        {
            return _repo.BudgetExsistsAsync(id);
        }
    }
}
