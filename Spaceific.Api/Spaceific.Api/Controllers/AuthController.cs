using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spaceific.Api.Models;
using Spaceific.Api.Services;
using BCrypt.Net;

namespace Spaceific.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDTO dto)
        {
            if (_context.Users.Any(u => u.Username == dto.Username))
                return BadRequest("Username already taken");

            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Username = dto.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = "User",
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(new { message = "Register success" });
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO dto)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == dto.Username);

            if (user == null)
                return Unauthorized("Username not found");

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return Unauthorized("Wrong password");

            return Ok(new
            {
                user.Id,
                user.FirstName,
                user.LastName,
                user.Username,
                user.Role
            });
        }
    }
}
