using api.Models;
using api.Services.Implementations;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FunctionalUnitController : ControllerBase
    {

        private readonly IGenericService<FunctionalUnit, int> _functionalUnitService;

        public FunctionalUnitController(IGenericService<FunctionalUnit, int> functionalUnitService)
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
        public ActionResult<FunctionalUnit> Create([FromBody] FunctionalUnit functionalUnit)
        {
            if(functionalUnit == null)
            {
                return BadRequest();
            }

            _functionalUnitService.Create(functionalUnit);
            return CreatedAtAction(nameof(GetById), new { id = functionalUnit.Id }, functionalUnit);
        }

        [HttpPut("{id}")]
        public ActionResult<FunctionalUnit> Update(int id, [FromBody] FunctionalUnit functionalUnit)
        {
            if (functionalUnit == null)
            {
                return BadRequest();
            }

            try
            {
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
    }
}
