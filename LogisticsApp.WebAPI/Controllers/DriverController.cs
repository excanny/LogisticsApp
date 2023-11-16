using LogisticsApp.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;

        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpGet("GetAllDrivers")]
        public async Task<IActionResult> GetAllDrivers()
        {
            var response = await _driverService.GetAllDrivers();
            return Ok(response);
        }
    }
}
