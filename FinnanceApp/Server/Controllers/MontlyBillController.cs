using System.Threading.Tasks;
using FinnanceApp.Server.Services;
using FinnanceApp.Server.Services.MontlyService;
using FinnanceApp.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinnanceApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MontlyBillController : ControllerBase
    {
        private readonly IUtilityService _utility;
        private readonly IMontlyService _montlyBills;

        public MontlyBillController(IUtilityService utility, IMontlyService montlyBills)
        {
            _utility = utility;
            _montlyBills = montlyBills;
        }

        public async Task<IActionResult> AddMontlyBill(MontlyBills bill)
        {
            var response = await _montlyBills.AddMontlyBill(bill);
            if (!response.isSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        public async Task<IActionResult> EditMontlyBill(MontlyBills bill)
        {
            var response = await _montlyBills.EditMontyBill(bill);
            if (!response.isSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        public async Task<IActionResult> DeleteMontlyBill(MontlyBills bill)
        {
            var response = await _montlyBills.DeleteMontlyBill(bill);
            if (!response.isSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}