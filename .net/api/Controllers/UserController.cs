using api.Models;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGenericService<User, int> _userService;
        public UserController(IGenericService<User, int> userService) { 
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetById(int id)
        {
            try
            {
                var user = _userService.GetById(id);
                return Ok(user);
            } catch(KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<User> Create([FromBody] User user)
        {
            if(user == null) {
                return BadRequest();
            }

            _userService.Create(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public ActionResult<User> Update(int id, [FromBody] User user){
            if(user == null)
            {
                return BadRequest();
            }

            try
            {
                _userService.Update(id, user);
                return NoContent();
            }
            catch(KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id){
            try
            {
                _userService.Delete(id);
                return NoContent();                
            }
            catch(KeyNotFoundException) { 
                return NotFound();
            }
        }
    }
}
