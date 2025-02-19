using api.Mappers;
using api.Models;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserMapper _userMapper;
        public UserController(IUserService userService, UserMapper userMapper) { 
            _userService = userService;
            _userMapper = userMapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserResponse>> GetAll()
        {
            var users = _userService.GetAll();
            var usersResponse = users.Select(u => _userMapper.GetUserResponse(u)).ToList();
            return Ok(usersResponse);
        }

        [HttpGet("{id}")]
        public ActionResult<UserResponse> GetById(int id)
        {
            try
            {
                var user = _userService.GetById(id);
                return Ok(_userMapper.GetUserResponse(user));
            } catch(KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<UserResponse> Create([FromBody] UserRequest userRequest)
        {
            if(userRequest == null) {
                return BadRequest();
            }
            var user = _userMapper.GetUserEntity(userRequest);
            _userService.Create(user);

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, _userMapper.GetUserResponse(user));
        }

        [HttpPut("{id}")]
        public ActionResult<UserResponse> Update(int id, [FromBody] UserRequest userRequest)
        {
            if(userRequest == null)
            {
                return BadRequest();
            }

            try
            {
                var user = _userMapper.GetUserEntity(userRequest);
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
