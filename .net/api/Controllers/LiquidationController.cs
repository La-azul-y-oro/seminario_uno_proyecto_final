using api.Dto;
using api.Models;
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
            var liquidation = _liquidationService.GetByPeriodAndConsortiumId($"{request.Year}-{request.Month:D2}", request.ConsortiumId);
            if (liquidation != null) {
                return Conflict("There is already a liquidation for the indicated period");
            }

            _liquidationService.GenerateLiquidation(request.ConsortiumId, request.Month, request.Year, request.ExpirationDate);

            return Ok();
        }

        [HttpGet("consortium/{id}")]
        public ActionResult<IEnumerable<Liquidation>> GetAllByConsortium(int id)
        {

            try
            {
                var liquidations = _liquidationService.GetAllByConsortiumId(id);
                return Ok(liquidations);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
