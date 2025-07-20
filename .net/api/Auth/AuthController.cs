using System.Security.Claims;
using api.Context;
using api.Mappers;
using api.Models;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Auth
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;
        private readonly IUserService _userService;
        private readonly ApplicationDbContext _context;
        private readonly UserMapper _userMapper;

        public AuthController(JwtService jwtService, IUserService userService, ApplicationDbContext context, UserMapper userMapper)
        {
            _jwtService = jwtService;
            _userService = userService;
            _context = context;
            _userMapper = userMapper;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRequest userRequest)
        {
            if (userRequest == null)
            {
                return BadRequest();
            }

            if (_context.User.Any(u => u.Email == userRequest.Email))
                return BadRequest("User already exists");

            var user = _userMapper.GetUserEntity(userRequest);

            user.Password = _jwtService.HashPassword(userRequest.Password);

            _context.User.Add(user);
            _context.SaveChanges();

            var userResponse = _userMapper.GetUserResponse(user);

            return Ok(userResponse);
        }

        
        [HttpPost("login")]
        public IActionResult Login(LoginDto loginDto)
        {
            var user = _context.User.SingleOrDefault(u => u.Email == loginDto.Username);
            if (user == null || !_jwtService.VerifyPassword(loginDto.Password, user.Password))
                return Unauthorized("Invalid credentials.");

            var token = _jwtService.GenerateToken(user);
            return Ok(new { token });
        }

        [HttpPost("forgot-password")]
        public IActionResult ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            var user = _userService.GetByEmail(request.Email);
            if (user == null) return Ok();

            var resetToken = Guid.NewGuid().ToString();
            user.ResetPasswordToken = resetToken;
            user.ResetTokenExpiration = DateTime.UtcNow.AddHours(1);
            _userService.Update(user);

            // TODO IMPLEMENTAR UN SERVICIO DE EMAIL
            // _emailService.SendResetPasswordEmail(user.Email, resetToken);

            return Ok();
        }

        [HttpPost("reset-password")]
        public IActionResult ResetPassword([FromBody] ResetPasswordRequest request)
        {
            try {
            var user = _userService.GetByResetToken(request.Token);
            if (user == null || user.ResetTokenExpiration < DateTime.UtcNow)
                return BadRequest("Invalid or expired token.");

            user.Password = _jwtService.HashPassword(request.NewPassword);
            user.ResetPasswordToken = null;
            user.ResetTokenExpiration = null;
            _userService.Update(user);

            return Ok();
            }
            catch (KeyNotFoundException)
            {
                return BadRequest("Invalid or expired token.");
            }
            catch (Exception)
            {
                return Problem();
            }
        }


        [Authorize]
        [HttpPost("change-password")]
        public IActionResult ChangePassword([FromBody] ChangePasswordRequest request)
        {
            var userEmail = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userEmail == null) return Unauthorized();

            var user = _userService.GetByEmail(userEmail);
            if (user == null) return NotFound("User not found.");

            if (!_jwtService.VerifyPassword(request.CurrentPassword, user.Password))
                return BadRequest("Invalid credentials");

            user.Password = _jwtService.HashPassword(request.NewPassword);
            _userService.Update(user);

            return Ok();
        }
    }
}
