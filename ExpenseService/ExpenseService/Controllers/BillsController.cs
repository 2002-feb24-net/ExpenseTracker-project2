﻿using System;
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
    public class BillsController : ControllerBase
    {
        private readonly IBillsRepository _repo;

        public BillsController(IBillsRepository repo)
        {

            _repo = repo;
        }

        // GET: api/Bills
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ApiModel.Bills>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetBills()
        {
            var ListOfBills = await _repo.GetBillsAsync();

            var resource = ListOfBills.Select(b => new ApiModel.Bills
            {
                Id = b.Id,
                PurchaseName = b.PurchaseName,
                Cost = b.Cost,
                BillDate = b.BillDate,
                Location = b.Location,
                Quantity = b.Quantity,
                UserId = b.UserId,
                CurrentUser = ApiMapper.MapUserApi(b.CurrentUser)
            });

            return Ok(resource);
        }

        // GET: api/Bills/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiModel.Bills), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> GetBills(int id)
        {
            var bills = await _repo.GetBillByIdAsync(id);
            var resource = ApiMapper.MapBillsApi(bills);

            if (bills == null)
            {
                return NotFound();
            }

            return Ok(resource);
        }

        // PUT: api/Bills/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBills(int id, ExpenseService.ServiceeAccess.Models.Bills bills)
        {
            if (id != bills.Id)
            {
                return BadRequest();
            }

            var newBill = Mapper.MapBills(bills);
            _repo.Changed(newBill);

            try
            {
                _repo.SaveAsync();
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
        public async Task<ActionResult> PostBills(ExpenseService.ServiceeAccess.Models.Bills bills)
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

        private Task<bool> BillsExists(int id)
        {
            return _repo.BillExsistsAsync(id);
        }
    }
}
