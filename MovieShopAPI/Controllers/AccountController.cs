using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AccountController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLoginRequestModel model)
        {
            var user = await _userService.Login(model);
            if (user == null)
            {
                return Unauthorized();
            }

            // return JWT
            return Ok(new { token = GenerateJwt(user) });
        }

        private string GenerateJwt(UserLoginResponseModel user)
        {
            var claims = new List<Claim>
            {
                new Claim( ClaimTypes.NameIdentifier, user.Id.ToString() ),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);
            
            // Create JWT
            
            // get the secret key from appsettings or Azure Key/Vault

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecretKey"]));
            // select the hashing algo

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            
            // get the expiration time
            var expires = DateTime.UtcNow.AddHours(_configuration.GetValue<int>("ExpirationHours"));
            
            // create the JWT token with above claims and credentials and expiration time

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["Issuer"],
                Audience = _configuration["Audience"],
                Subject = identityClaims,
                Expires = expires,
                SigningCredentials = credentials
            };

            var encodedJwt = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(encodedJwt);
            // Store Application Secrets in Azure Key/Vault  
        }

    }
}