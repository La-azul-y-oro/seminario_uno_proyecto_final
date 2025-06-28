using api.Dto;
using api.Models;
using api.Services.Interfaces;
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
        public ActionResult<IEnumerable<FunctionalUnit>> GetAll()
        {
            var functionalUnits = _functionalUnitService.GetAll();
            return Ok(functionalUnits);
        }

        [HttpGet("{id}")]
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
    }
}
