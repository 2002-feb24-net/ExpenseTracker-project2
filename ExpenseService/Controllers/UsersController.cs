using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpenseService.DataAccess.Model;
using ExpenseService.Core.Interrfaces;
using ExpenseService.DataAccess;

namespace ExpenseServiceAPI.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IExpensesRepository _repo;

        public UsersController(IExpensesRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Users
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ApiModel.ApiUsers>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAllUsersAsync()
        {
            IEnumerable<ExpenseService.Core.Model.CoreUsers> user = await _repo.GetUsersAsync();

            IEnumerable<ApiModel.ApiUsers> resource = user.Select(u => new ApiModel.ApiUsers
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Password = u.Password,
                Address = u.Address,
                PhoneNumber = u.PhoneNumber,
                Membership = u.Membership
            });

            return Ok(resource);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiModel.ApiUsers), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetUsers(int id)
        {
            ExpenseService.Core.Model.CoreUsers user = await _repo.GetUserAsync(id);
            var resource = new ApiModel.ApiUsers
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                Membership = user.Membership
            };

            if (resource == null)
            {
                return NotFound();
            }
            
            return Ok(resource);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(int id, Users users)
        {
            if (id != users.Id)
            {
                return BadRequest();
            }

            var newUser = Mapper.MapUsers(users);
            _repo.Changed(newUser);

            try
            {
                await _repo.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await UsersExists(id)))
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

        // POST: api/Users
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult> PostUsers(ExpenseService.Core.Model.CoreUsers user)
        {
            ExpenseService.Core.Model.CoreUsers add = await _repo.AddUsersAsync(user);
            var resource = new ApiModel.ApiUsers
            {
                Id = add.Id,
                Name = add.Name,
                Email = add.Email,
                Password = add.Password,
                Address = add.Address,
                PhoneNumber = add.PhoneNumber,
                Membership = add.Membership
            };

            return Ok(resource);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public ActionResult DeleteUsers(int id)
        {
            var resource = _repo.RemoveUserAsync(id);

            return Ok(resource);
        }
        [HttpGet("{id}")]
        private Task<bool> UsersExists(int id)
        {
            return _repo.UserExsistsAsync(id);
        }
    }
}
