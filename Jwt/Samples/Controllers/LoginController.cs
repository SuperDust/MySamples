using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Samples.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost("System")]
        public IActionResult System()
        {
            Claim[] claims = new[]
             {
                    new Claim(ClaimTypes.Sid,"1"),
                    new Claim(ClaimTypes.Name, "张三"),
                    new Claim(ClaimTypes.Email,"net*****@163.com"),
                    new Claim(ClaimTypes.Role, "System"),
                };
            //密钥
            SymmetricSecurityKey signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("1234567890123456"));
            SigningCredentials signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
            (
                issuer: "DUST",
                audience: "DUST",
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: signingCredentials
            );
            string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return Ok(token);
        }

        [HttpPost("Admin")]
        public IActionResult Admin()
        {
            Claim[] claims = new[]
             {
                    new Claim(ClaimTypes.Sid,"1"),
                    new Claim(ClaimTypes.Name, "张三"),
                    new Claim(ClaimTypes.Email,"net*****@163.com"),
                    new Claim(ClaimTypes.Role, "System"),
                };
            //密钥
            SymmetricSecurityKey signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("1234567890123456"));
            SigningCredentials signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
            (
                issuer: "DUST",
                audience: "DUST",
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: signingCredentials
            );
            string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return Ok(token);
        }

        [HttpPost("Client")]
        public IActionResult Client()
        {
            Claim[] claims = new[]
             {
                    new Claim(ClaimTypes.Sid,"1"),
                    new Claim(ClaimTypes.Name, "张三"),
                    new Claim(ClaimTypes.Email,"net*****@163.com"),
                    new Claim(ClaimTypes.Role, "System"),
                };
            //密钥
            SymmetricSecurityKey signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("1234567890123456"));
            SigningCredentials signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
            (
                issuer: "DUST",
                audience: "DUST",
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: signingCredentials
            );
            string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return Ok(token);
        }
    }
}