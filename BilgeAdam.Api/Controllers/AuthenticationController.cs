using BilgeAdam.Common.Configuration;
using BilgeAdam.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BilgeAdam.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly JwtSettings jwtSettings;
        public AuthenticationController(IOptions<Settings> options)
        {
            jwtSettings = options.Value.Jwt;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDTO data)
        {
            if (data.UserName != "can" || data.Password != "111")
            {
                return Unauthorized();
            }
            var claims = new Dictionary<string, object>();
            claims.Add("UserId", 1);
            claims.Add("Culture", "tr-TR");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.Now.AddMinutes(jwtSettings.Expires),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
                                                            SecurityAlgorithms.HmacSha256Signature),
                Claims = claims,
                IssuedAt = DateTime.Now,
                NotBefore = DateTime.Now
            };

            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateToken(tokenDescriptor);
            var jwtToken = handler.WriteToken(token);
            return Ok(jwtToken);
        }
    }
}
