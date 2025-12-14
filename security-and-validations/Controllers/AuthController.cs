using Microsoft.AspNetCore.Mvc;
using security_and_validations.Data;
using security_and_validations.Models;
using security_and_validations.Services;
using System.Security.Cryptography;
using System.Text;

namespace security_and_validations.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly TokenService _tokenService;

        public AuthController(AppDbContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var hashed = Hash(request.Password);

            var user = _context.Users
                .SingleOrDefault(u => u.Email == request.Email && u.PasswordHash == hashed);

            if (user == null)
                return Unauthorized();

            var token = _tokenService.GenerateToken(user);
            return Ok(new { token });
        }

        private static string Hash(string input)
        {
            using var sha = SHA256.Create();
            return Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(input)));
        }
    }
}
