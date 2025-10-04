using api.Dto;
using api.Mappers;
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
        private readonly MovementMapper _movementMapper;

        public MovementController(IMovementService movementService, MovementMapper movementMapper)
        {
            _movementService = movementService;
            _movementMapper = movementMapper;
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN,STAFF")]
        public ActionResult<IEnumerable<MovementDTO>> GetAll(){
            var movements = _movementService.GetAll();
            var movementsDTO = movements.Select(u => _movementMapper.GetMovementDTO(u)).ToList();
            return Ok(movementsDTO);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "ADMIN,STAFF")]
        public ActionResult<MovementDTO> GetById (int id){

            try{
                var movement = _movementService.GetById(id);
                var movementDTO = _movementMapper.GetMovementDTO(movement);
                return Ok(movementDTO);
            } catch(KeyNotFoundException){
                return NotFound();
            }
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN,STAFF")]
        public ActionResult<MovementDTO> Create([FromBody] MovementDTO movementDTO){
            if(movementDTO == null){
                return BadRequest();
            }

            var movement = _movementMapper.GetMovement(movementDTO);

            try{
                var createdMovement = _movementService.CreateAndReturn(movement);

                return CreatedAtAction(nameof(GetById), new { id = createdMovement.Id}, _movementMapper.GetMovementDTO(createdMovement) );
            }
            catch (InvalidOperationException e) {
                return Conflict(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
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
