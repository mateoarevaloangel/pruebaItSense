using BackendPrueba.Models;
using BackendPrueba.Repository.Interface;
using BackendPrueba.Repository.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BackendPrueba.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController: ControllerBase
    {
        private readonly IUserRepository userRepository;
        private IConfiguration _config;

        public AuthController(IUserRepository userRepository, IConfiguration config)
        {
            this.userRepository = userRepository;
            _config = config;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest user)
        {
            var result = userRepository.GetUserByName(user.Name).Result;
            
            if (result.PasswordHash == user.Password)
            {
                var token = GenerateJwtToken(result);
                return Ok(new { token });
            }
            return Unauthorized();
        }

        private string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);
            return token;
        }
    }
}
