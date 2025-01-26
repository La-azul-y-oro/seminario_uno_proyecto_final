using api.Models;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConceptController : ControllerBase
    {
        private readonly IGenericService<Concept, int> _conceptService;

        // Inyección del servicio en el constructor
        public ConceptController(IGenericService<Concept, int> conceptService)
        {
            _conceptService = conceptService;
        }

        // GET: api/concept
        [HttpGet]
        public ActionResult<IEnumerable<Concept>> GetAll()
        {
            var concepts = _conceptService.GetAll();
            return Ok(concepts);
        }

        // GET: api/concept/5
        [HttpGet("{id}")]
        public ActionResult<Concept> GetById(int id)
        {
            try
            {
                var concept = _conceptService.GetById(id);
                return Ok(concept);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: api/concept
        [HttpPost]
        public ActionResult<Concept> Create([FromBody] Concept concept)
        {
            if (concept == null)
            {
                return BadRequest();
            }

            _conceptService.Create(concept);
            return CreatedAtAction(nameof(GetById), new { id = concept.Id }, concept);
        }

        // PUT: api/concept/5
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Concept concept)
        {
            if (concept == null)
            {
                return BadRequest();
            }

            try
            {
                _conceptService.Update(id, concept);
                return NoContent();  // 204 No Content
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/concept/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _conceptService.Delete(id);
                return NoContent();  // 204 No Content
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
