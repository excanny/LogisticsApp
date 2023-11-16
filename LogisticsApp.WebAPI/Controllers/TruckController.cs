using LogisticsApp.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruckController : ControllerBase
    {
        private readonly ITruckService _truckService;

        public TruckController(ITruckService truckService)
        {
            _truckService = truckService;
        }

        [HttpGet("GetAllTrucks")]
        public async Task<IActionResult> GetAllTrucks()
        {
            var response = await _truckService.GetAllTrucks();
            return Ok(response);
        }
    }
}
