using api.Dto;
using api.Models;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FunctionalUnitController : ControllerBase
    {

        private readonly IFunctionalUnitService _functionalUnitService;

        public FunctionalUnitController(IFunctionalUnitService functionalUnitService)
        {
            _functionalUnitService = functionalUnitService;
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN,STAFF")]

        public ActionResult<IEnumerable<FunctionalUnit>> GetAll()
        {
            var functionalUnits = _functionalUnitService.GetAll();
            return Ok(functionalUnits);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "ADMIN,STAFF")]
        public ActionResult<FunctionalUnit> GetById(int id)
        {
            try
            {
                var functionalUnit = _functionalUnitService.GetById(id);
                return Ok(functionalUnit);
            }
            catch(KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN,STAFF")]
        public ActionResult<FunctionalUnit> Create([FromBody] FunctionalUnitRequest request)
        {
            if(request == null)
            {
                return BadRequest();
            }

            var functionalUnit = new FunctionalUnit
            {
                Name = request.Name,
                Balance = request.Balance,
                Factor = request.Factor,
                ConsortiumId = request.ConsortiumId
            };

            _functionalUnitService.Create(functionalUnit);
            return CreatedAtAction(nameof(GetById), new { id = functionalUnit.Id }, functionalUnit);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN,STAFF")]
        public ActionResult<FunctionalUnit> Update(int id, [FromBody] FunctionalUnitRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            try
            {
                var functionalUnit = new FunctionalUnit
                {
                    Name = request.Name,
                    Balance = request.Balance,
                    Factor = request.Factor,
                    ConsortiumId = request.ConsortiumId
                };

                _functionalUnitService.Update(id, functionalUnit);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN,STAFF")]
        public ActionResult Delete(int id)
        {
            try
            {
                _functionalUnitService.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("consortium/{id}")]
        [Authorize(Roles = "ADMIN,STAFF")]
        public ActionResult<IEnumerable<FunctionalUnit>> FindByConsortiumId(int id)
        {
            try
            {
                var functionalUnit = _functionalUnitService.FindByConsortiumId(id);
                return Ok(functionalUnit);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost("assign-clients")]
        [Authorize(Roles = "ADMIN,STAFF")]
        public ActionResult AssignClients([FromBody] AssignClientsRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            if (request.FunctionalId <= 0)
            {
                return BadRequest();
            }

            if (request.ClientsIds == null)
            {
                return BadRequest();
            }

            _functionalUnitService.UpdateClientsToFunctionalUnit(request.FunctionalId, request.ClientsIds);

            return Ok();
        }


        [HttpGet("client/{id}")]
        [Authorize]
        public ActionResult<List<ClientFunctionalUnit>> GetAllByClientId(int id)
        {
            return Ok(_functionalUnitService.GetByClientId(id));
        }

        [HttpPost("update-units")]
        [Authorize(Roles = "ADMIN,STAFF")]
        public async Task<ActionResult> UpdateUnits([FromBody] FunctionalUnitBatchRequest request)
        {
            try
            {
                await _functionalUnitService.ProcessBatchOperations(request);
                var functionalUnits = _functionalUnitService.FindByConsortiumId(request.ConsortiumId);
                return Ok(functionalUnits);
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
