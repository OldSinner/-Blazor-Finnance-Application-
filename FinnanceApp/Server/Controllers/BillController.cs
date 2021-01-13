using FinnanceApp.Server.Services;
using FinnanceApp.Server.Services.BillService;
using FinnanceApp.Shared.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinnanceApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BillController : ControllerBase
    {
        
        private readonly IBillService _bill;

        public BillController(IBillService bill)
        {
            _bill = bill;
        }
        [HttpPost("AddBill")]
        public async Task<IActionResult> AddBill([FromBody] Bills bill)
        {
            var response = await _bill.AddBill(bill);
            if (!response.isSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);

        }
        [HttpGet("GetBill")]
        public async Task<IActionResult> GetBill()
        {
            var response = await _bill.getBillsList();
            if (!response.isSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("GetBillPages")]
        public async Task<IActionResult> GetBillPages(int page)
        {
            var response = await _bill.getBillsListWithPages(page);
            if (!response.isSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPost("DeleteBill")]
        public async Task<IActionResult> DeleteBill([FromBody] int id)
        {
            var response = await _bill.DeleteBill(id);
            if (!response.isSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
