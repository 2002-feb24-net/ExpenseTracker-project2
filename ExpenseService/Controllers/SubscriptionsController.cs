using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpenseService.DataAccess.Model;
using ExpenseService.Core.Interrfaces;
using ExpenseServiceAPI.ApiModel;
using ExpenseService.DataAccess;

namespace ExpenseServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISubscription _repo;

        public SubscriptionsController(ISubscription repo)
        {

            _repo = repo;
        }

        // GET: api/Subscriptions
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ApiModel.ApiSub>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetSubscriptions()
        {
            var ListOfSubscriptions = await _repo.GetSubscriptionssAsync();

            var resource = ListOfSubscriptions.Select(b => new ApiModel.ApiSub
            {
                Id = b.Id,
                SubscriptionDate = b.SubscriptionDate,
                SubscriptionDueDate = b.SubscriptionDueDate,
                Company = b.Company,
                Notification = b.Notification,
                SubscriptionMonthCost = b.SubscriptionMonthCost,
                SubscriptionName = b.SubscriptionName,
                UserId = b.UserId,
                //User = ApiMapper.MapUserApi(b.User)
            });

            return Ok(resource);
        }

        // GET: api/Subscriptions/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiModel.ApiSub), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> GetSubscriptions(int id)
        {
            var Subscriptions = await _repo.GetSubscriptionsByIdAsync(id);
            var resource = ApiMapper.MapSub(Subscriptions);

            if (Subscriptions == null)
            {
                return NotFound();
            }

            return Ok(resource);
        }
        // GET: api/Subscriptions/userid=5
        [HttpGet("userid={id}")]
        [ProducesResponseType(typeof(ApiModel.ApiSub), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> GetSubscriptionsAsync(int id)
        {
            var Subscriptions = await _repo.GetSubscriptionssAsync(id);

            var resource = Subscriptions.Select(b => new ApiModel.ApiSub
            {
                Id = b.Id,
                SubscriptionDate = b.SubscriptionDate,
                SubscriptionDueDate = b.SubscriptionDueDate,
                Company = b.Company,
                Notification = b.Notification,
                SubscriptionMonthCost = b.SubscriptionMonthCost,
                SubscriptionName = b.SubscriptionName,
                UserId = b.UserId,
                //User = ApiMapper.MapUserApi(b.User)
            });

            return Ok(resource);
        }

        // PUT: api/Subscriptions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscriptions(int id, ExpenseService.DataAccess.Model.Subscriptions Subscriptions)
        {
            if (id != Subscriptions.Id)
            {
                return BadRequest();
            }

            var newSubscriptions = Mapper.MapSub(Subscriptions);
            _repo.Changed(newSubscriptions);

            try
            {
                await _repo.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await SubscriptionsExists(id)))
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
        [HttpPost]
        public async Task<ActionResult> PostSubscriptions(ExpenseService.Core.Model.CoreSubscriptions subscriptions)
        {
            ExpenseService.Core.Model.CoreSubscriptions add = await _repo.AddSubscriptionsAsync(subscriptions);
            var resource = new ApiModel.ApiSub
            {
                Id = add.Id,
                SubscriptionDate = add.SubscriptionDate,
                SubscriptionDueDate = add.SubscriptionDueDate,
                Company = add.Company,
                Notification = add.Notification,
                SubscriptionMonthCost = add.SubscriptionMonthCost,
                SubscriptionName = add.SubscriptionName,
                UserId = add.UserId
            };
            return Ok(resource);
        }

        // DELETE: api/Subscriptions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSubscriptions(int id)
        {
            var resource = await _repo.RemoveSubscriptionsAsync(id);

            return Ok(resource);
        }
        [HttpGet("{id}")]
        private Task<bool> SubscriptionsExists(int id)
        {
            return _repo.SubscriptionsExsistsAsync(id);
        }
    }
}
