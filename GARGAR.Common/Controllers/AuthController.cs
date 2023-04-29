using Domain.User.Auth;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Shared.DTO;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GARGAR.Common.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "4")]
    public class AuthController : ControllerBase
    {
        private readonly IUserAuthenticationService _auth;
        private readonly IConfiguration _config;
        public AuthController(IUserAuthenticationService authenticationService,IConfiguration configuration)
        {
            _auth = authenticationService;
            _config = configuration;
        }


        [HttpPost("SignUp")]
        public async Task<ActionResult> SignUp([FromBody] SignUpDTO request)
        {
            var DbResponse = await _auth.SignUp(request);
            if (DbResponse == IdentityResult.Success)
            {
                return Ok();
            }
            return Unauthorized();
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult> SignIn([FromBody] LoginDTO request)
        {
            var DbResponse = await _auth.SignIn(request);
            if (DbResponse.SignInResult == Microsoft.AspNetCore.Identity.SignInResult.Success)
            {
                var claimsList = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, DbResponse.User.Id),
                    new Claim(ClaimTypes.Name,DbResponse.User.Firstname),
                    new Claim(ClaimTypes.Email, DbResponse.User.Email),
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                var authSignInkey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["JwtConfig:Key"]));
                var token = new JwtSecurityToken(
                    issuer: _config["JwtConfig:Key"],
                    audience: _config["JwtConfig:Key"],
                    expires: DateTime.UtcNow.AddHours(2),
                    claims: claimsList,
                    signingCredentials: new SigningCredentials(authSignInkey, SecurityAlgorithms.HmacSha256Signature)
                    );
                Response.Headers.Add("Token", new JwtSecurityTokenHandler().WriteToken(token));
                return Ok();
            }
            return Unauthorized();
        }
    }
}
