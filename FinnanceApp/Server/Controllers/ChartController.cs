using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FinnanceApp.Server.Services;
using FinnanceApp.Server.Services.ChartService;
using FinnanceApp.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
        [HttpGet]
        public async Task<IActionResult> GetMonthChart()
        {
            var response = await _chartService.GetMonthChart();
            if (!response.isSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}