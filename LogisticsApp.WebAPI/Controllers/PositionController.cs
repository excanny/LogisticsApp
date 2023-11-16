using LogisticsApp.Application.Services.Concretes;
using LogisticsApp.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _postionService;

        public PositionController(IPositionService postionService)
        {
            _postionService = postionService;
        }

        [HttpGet("GetPositions")]
        public async Task<IActionResult> GetPositions()
        {
            var response = await _postionService.GetPositions();
            return Ok(response);
        }

        [HttpGet("GetPosition")]
        public async Task<IActionResult> GetPosition(long assetId, long driverId)
        {
            var response = await _postionService.GetPosition(assetId, driverId);
            return Ok(response);
        }

        [HttpGet("GetDistanceInKm")]
        public async Task<IActionResult> GetDistanceInKm(long assetId, long driverId, double staticLattitude, double staticLongitutude)
        {
            var response = await _postionService.GetDistanceInKm(assetId, driverId, staticLattitude, staticLongitutude);
            return Ok(response);
        }
    }
}
