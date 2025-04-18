using BCrypt.Net;
using ECommerceApi.DTOs;
using ECommerceApi.Entities;
using ECommerceApi.Repositories;
using ECommerceApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly JwtService _jwt;

        public AuthController(IUserRepository userRepo, JwtService jwt)
        {
            _userRepo = userRepo;
            _jwt = jwt;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var existingUser = await _userRepo.GetByEmailAsync(dto.Email);
            if (existingUser != null)
                return BadRequest("Bu e-posta zaten kullanılıyor.");

            var user = new User
            {
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = "User"
            };

            await _userRepo.AddUserAsync(user);
            return Ok("Kayıt başarılı");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _userRepo.GetByEmailAsync(dto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return Unauthorized("Geçersiz e-posta veya şifre");

            var token = _jwt.GenerateToken(user);
            return Ok(new { token });
        }
    }
}
