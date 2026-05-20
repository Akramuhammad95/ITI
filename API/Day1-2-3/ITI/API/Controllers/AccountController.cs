using Core.DTOs.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            // ================= CHECK USER =================

            // Replace this with DB check later
            if (loginDto.Username != "admin" || loginDto.Password != "123")
            {
                return Unauthorized("Invalid Username Or Password");
            }

            // ================= CLAIMS =================

            var userClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, "1"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("Username", loginDto.Username),
                new Claim(ClaimTypes.Role, "Admin")
            };

            // ================= SECRET KEY =================

            var key =
                "ZiadAkramMuhammadKamelMuhammadIbrahim_A_to_Z_Academy_Secret_Key";

            var secretKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            var signingCredentials =
                new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            // ================= TOKEN =================

            var token = new JwtSecurityToken(
                claims: userClaims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: signingCredentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();

            var jwt = tokenHandler.WriteToken(token);

            // ================= RESPONSE =================

            return Ok(new
            {
                Token = jwt,
                Expiration = token.ValidTo,
                Username = loginDto.Username
            });
        }
    }
}