using api.Models;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsortiumController : ControllerBase
    {
        private readonly IGenericService<Consortium, int> _consortiumService;

        public ConsortiumController(IGenericService<Consortium, int> consortiumService)
        {
            _consortiumService = consortiumService;
        }

        // GET: api/consortium
        [HttpGet]
        public ActionResult<IEnumerable<Consortium>> GetAll()
        {
            var consortiums = _consortiumService.GetAll();
            return Ok(consortiums);
        }

        // GET: api/consortium/5
        [HttpGet("{id}")]
        public ActionResult<Consortium> GetById(int id)
        {
            try
            {
                var consortium = _consortiumService.GetById(id);
                return Ok(consortium);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: api/concept
        [HttpPost]
        public ActionResult<Consortium> Create([FromBody] Consortium consortium)
        {
            if (consortium == null)
            {
                return BadRequest();
            }

            _consortiumService.Create(consortium);
            return CreatedAtAction(nameof(GetById), new { id = consortium.Id }, consortium);
        }

        // PUT: api/consortium/5
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Consortium consortium)
        {
            if (consortium == null)
            {
                return BadRequest();
            }

            try
            {
                _consortiumService.Update(id, consortium);
                return NoContent();  // 204 No Content
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/consortium/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _consortiumService.Delete(id);
                return NoContent();  // 204 No Content
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
