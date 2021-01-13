using System.Threading.Tasks;
using FinnanceApp.Server.Services.ChartService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinnanceApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChartController : ControllerBase
    {
        private readonly IChartService _chartService;

        public ChartController(IChartService chartService)
        {
            _chartService = chartService;
        }
        [HttpGet("GetSumBillsByMonth")]
        public async Task<IActionResult> GetSumBillsByMonth()
        {
            var response = await _chartService.GetSumBillsByMonth();
            if (!response.isSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("GetSumBillsByPerson")]
        public async Task<IActionResult> GetSumBillsByPerson()
        {
            var response = await _chartService.GetSumByPerson();
            if (!response.isSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("GetSumByShop")]
        public async Task<IActionResult> GetSumByShop()
        {
            var response = await _chartService.GetSumByShop();
            if (!response.isSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}