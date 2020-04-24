
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpenseService.Core.Interrfaces;
using ExpenseService.DataAccess;

namespace ExpenseServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly IBillsRepository _repo;

        public BillsController(IBillsRepository repo)
        {

            _repo = repo;
        }

        // GET: api/Bills
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ApiModel.ApiBills>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetBills()
        {
            var ListOfBills = await _repo.GetBillsAsync();
            var resource = ListOfBills.Select(b => new ApiModel.ApiBills
            {
                Id = b.Id,
                PurchaseName = b.PurchaseName,
                Cost = b.Cost,
                BillDate = b.BillDate,
                Location = b.Location,
                Quantity = b.Quantity,
                UserId = b.UserId,
                //CurrentUser = ApiMapper.MapUserApi(b.CurrentUser)
            });

            return Ok(resource);
        }

        // GET: api/Bills/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiModel.ApiBills), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> GetBills(int id)
        {
            ExpenseService.Core.Model.CoreBills bills = await _repo.GetBillByIdAsync(id);
            var resource = new ApiModel.ApiBills
            {
                Id = bills.Id,
                BillDate = bills.BillDate,
                Cost = bills.Cost,
                Location = bills.Location,
                PurchaseName = bills.PurchaseName,
                Quantity = bills.Quantity,
                UserId = bills.UserId
                //CurrentUser = ApiMapper.MapUserApi(bills.CurrentUser)
            };

            if (resource == null)
            {
                return NotFound();
            }

            return Ok(resource);
        }


        [HttpGet("userid={userid}")]
        [ProducesResponseType(typeof(ApiModel.ApiBills), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> GetUserBills(int userid)
        {
            var ListOfBills = await _repo.GetBillsAsync(userid);
            var resource = ListOfBills.Select(b => new ApiModel.ApiBills
            {
                Id = b.Id,
                BillDate = b.BillDate,
                Cost = b.Cost,
                Location = b.Location,
                PurchaseName = b.PurchaseName,
                Quantity = b.Quantity,
                UserId = b.UserId
                //CurrentUser = ApiMapper.MapUserApi(bills.CurrentUser)
            });

            if (resource == null)
            {
                return NotFound();
            }

            return Ok(resource);
        }
        // PUT: api/Bills/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBills(int id, ExpenseService.DataAccess.Model.Bills bills)
        {
            if (id != bills.Id)
            {
                return BadRequest();
            }

            var newBill = Mapper.MapBills(bills);
            _repo.Changed(newBill);

            try
            {
                await _repo.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await BillsExists(id)))
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
        public async Task<ActionResult> PostBills(ExpenseService.DataAccess.Model.Bills bills)
        {
            var newBill = Mapper.MapBills(bills);
            _ = _repo.AddBillAsync(newBill);

            await _repo.SaveAsync();

            return CreatedAtAction("GetBills", new { id = bills.Id }, bills);
        }

        // DELETE: api/Bills/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBills(int id)
        {
            var resource = await _repo.RemoveBillAsync(id);

            return Ok(resource);
        }
        [HttpGet("{id}")]
        private Task<bool> BillsExists(int id)
        {
            return _repo.BillExsistsAsync(id);
        }
    }
}
