using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        public UserController() { }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            //UserService.GetAll()
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetById(int id)
        {
            //UserService.GetById()
            return Ok();
        }

        [HttpPost]
        public ActionResult<User> Create([FromBody] User user)
        {
            if(user == null) {
                return BadRequest();
            }

            //UserService.create
            return CreatedAtAction(nameof(GetById), new { id = user.id }, user);
        }

        [HttpPut]
        public ActionResult<User> Update([FromBody] User user){
            if(user == null)
            {
                return BadRequest();
            }

            // UserService.update
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id){
            //UserService.delete
            return Ok();
        }
    }
}
