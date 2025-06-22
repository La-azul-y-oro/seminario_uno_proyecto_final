using api.Dto;
using api.Services.Implementations;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LiquidationController : ControllerBase
    {
        private readonly ILiquidationService _liquidationService;

        public LiquidationController(ILiquidationService liquidationService)
        {
            _liquidationService = liquidationService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] LiquidationRequestDTO request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            _liquidationService.GenerateLiquidation(request.ConsortiumId, request.Month, request.Year, request.ExpirationDate);

            return Ok();
        }
    }
}
