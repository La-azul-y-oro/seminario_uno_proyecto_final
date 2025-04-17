using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class MovementController : ControllerBase
    {
        private readonly IGenericService<Movement, int> _movementService;

        public MovementController(IGenericService<Movement, int> movementService)
        {
            _movementService = movementService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Movement>> GetAll(){
            var movements = _movementService.GetAll();
            return Ok(movements);
        }

        [HttpGet("{id}")]
        public ActionResult<Movement> GetById (int id){

            try{
                var movement = _movemntService.GetById(id);
                return Ok(movement);
            } catch(KeyNotFoundException){
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<Movement> Create([FromBody] Movement movement){
            if(movement == null){
                return BadRequest();
            }

            _movementService.Create(movement);
            return CreatedAtAction(nameof(GetById), new { id = movement.id}, movement);
        }

        [HttpPut("{id}")]
        public ActionResult<Movement> Update(int id, [FromBody] Movement movement){
            if(movement == null){
                return BadRequest();
            }

            try{
                _movementService.Update(id, movement);
                return NoContent();
            } catch(KeyNotFoundException) {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id){
            try{
                _movementService.Delete(id);
                return NoContent();
            } catch(KeyNotFoundException){
                return NotFound();
            }
        }

    }
}
