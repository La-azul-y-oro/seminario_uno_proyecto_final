using api.Dto;
using api.Mappers;
using api.Models;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsortiumController : ControllerBase
    {
        private readonly IConsortiumService _consortiumService;
        private readonly ConsortiumMapper _consortiumMapper;

        public ConsortiumController(IConsortiumService consortiumService, ConsortiumMapper consortiumMapper)
        {
            _consortiumService = consortiumService;
            _consortiumMapper = consortiumMapper;
        }

        // GET: api/consortium
        [HttpGet]
        [Authorize(Roles = "ADMIN,STAFF")]
        public ActionResult<IEnumerable<ConsortiumResponse>> GetAll()
        {
            var consortiums = _consortiumService.FindAll();
            return Ok(consortiums);
        }

        // GET: api/consortium/5
        [HttpGet("{id}")]
        [Authorize(Roles = "ADMIN,STAFF")]
        public ActionResult<ConsortiumResponse> GetById(int id)
        {
            try
            {
                var consortium = _consortiumService.GetById(id);
                var consortiumResponse = _consortiumMapper.GetConsortiumResponse(consortium);

                return Ok(consortiumResponse);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: api/consortium
        [HttpPost]
        [Authorize(Roles = "ADMIN,STAFF")]
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
        [Authorize(Roles = "ADMIN,STAFF")]
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
        [Authorize(Roles = "ADMIN")]
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
