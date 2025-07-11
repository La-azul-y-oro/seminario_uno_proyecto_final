using api.Models;
using api.Services.Implementations;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class MovementController : ControllerBase
    {
        private readonly IMovementService _movementService;

        public MovementController(IMovementService movementService)
        {
            _movementService = movementService;
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN,STAFF")]
        public ActionResult<IEnumerable<Movement>> GetAll(){
            var movements = _movementService.GetAll();
            return Ok(movements);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "ADMIN,STAFF")]
        public ActionResult<Movement> GetById (int id){

            try{
                var movement = _movementService.GetById(id);
                return Ok(movement);
            } catch(KeyNotFoundException){
                return NotFound();
            }
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN,STAFF")]
        public ActionResult<Movement> Create([FromBody] Movement movement){
            if(movement == null){
                return BadRequest();
            }

            try
            {
                _movementService.Create(movement);
                return CreatedAtAction(nameof(GetById), new { id = movement.Id }, movement);
            }
            catch (InvalidOperationException e) {
                return Conflict(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN,STAFF")]
        public ActionResult<Movement> Update(int id, [FromBody] Movement movement){
            if(movement == null){
                return BadRequest();
            }

            try{
                _movementService.Update(id, movement);
                return NoContent();
            } catch(KeyNotFoundException) {
                return NotFound();
            } catch (InvalidOperationException e) {
                return Conflict(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN,STAFF")]
        public ActionResult Delete(int id){
            try{
                _movementService.Delete(id);
                return NoContent();
            } catch(KeyNotFoundException){
                return NotFound();
            } catch (InvalidOperationException e)
            {
                return Conflict(e.Message);
            }
        }

    }
}
