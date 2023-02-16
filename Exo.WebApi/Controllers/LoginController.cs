using Exo.WebApi.Interface;
using Exo.WebApi.Models;
using Exo.WebApi.Repositories;
using Exo.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Exo.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserRepository _UserRepository;
        

        public LoginController(UserRepository UserRepository) 
        {
            _UserRepository = UserRepository;
        }

        public LoginController(IUserRepository @object)
        {
            Object = @object;
        }

        public IUserRepository Object { get; }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                User foundUser = _UserRepository.Login(login.Email, login.Senha); 
                if (foundUser == null)
                { 
                    return Unauthorized(new { msg = "Usuário não autorizado"});
                }
                var myClaims = new[]
                {
                    new Claim (JwtRegisteredClaimNames.Email, foundUser.Email),
                    new Claim (JwtRegisteredClaimNames.Jti, foundUser.Id.ToString()),
                    new Claim (ClaimTypes.Role, foundUser.Tipo)
                };
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("project-key-authentication"));

                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var myToken = new JwtSecurityToken(
                    issuer: "Exo.WebApi",
                    audience: "Exo.WebApi",
                    claims: myClaims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credentials

                    ); ;
                return Ok(
                    new { token = new JwtSecurityTokenHandler().WriteToken(myToken) }
                    );

            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }
    }
    
}
