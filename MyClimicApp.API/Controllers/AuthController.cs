using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System;
using MyClinicApp.Service.Implementations;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Claims;

namespace MyClimicApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserService userService;

        public AuthController(UserService _userService)
        {
            userService = _userService;
        }

        [HttpPost("/token")]
        public async Task<IActionResult> Token(string login, string password)
        {
            var identity = await userService.GetUserByLogin(login);
            if (identity.Data.Equals(null))
            {
                return BadRequest(new { errorText = "Invalid login." });
            }
            else if (identity.Data.Password != password)
            {
                return BadRequest(new { errorText = "Invalid password." });
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, identity.Data.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, identity.Data.FullName)
            };

            ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);


            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: claimsIdentity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Data.FullName,
            };

            return Ok(response);
        }
    }
}
