using BusinessAccessLayer.Abstraction;
using BusinessAccessLayer.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using ModelAccessLayer.Models;
using ModelAccessLayer.ViewModels;
using NuGet.Protocol.Plugins;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Xml.Linq;

namespace MyJyotishJiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountServices _account;
        private readonly IWebHostEnvironment _environment;
        private readonly IConfiguration _config;
       
        public AccountController(IAccountServices account , IWebHostEnvironment environment, IConfiguration configuration)
        {
            _account = account;
            _environment = environment;
            _config = configuration;
           
        }


        


        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            // Validate the user credentials (use real validation in a production app)
            string Result = _account.SignInAdmin(login.Email, login.Password);
            if (Result == "Login Successful")
            {
                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, login.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("UserId", login.Email.ToString())
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var signIn = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                   _config["Jwt:Issuer"],
                    _config["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(30),
                    signingCredentials: signIn);

                var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new { Token = tokenValue, User = login.Email });
            }

            return Unauthorized();
        }


        
        [HttpPost("registerJyotish")]
        public IActionResult RegisterJyotish(PendingJyotishViewModel jyotishViewModel) 
        {
            string? path = _environment.ContentRootPath;

            bool Result = _account.SignUpJyotish(jyotishViewModel,path);
            if (Result == true)
            {

                var result = new { Success = true };
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
            
        }

        

        [HttpPost("loginJyotish")]
        public IActionResult LoginJyotish(LoginModel jyotishLogin)
        {
            string Result = _account.SignInJyotish(jyotishLogin);
            if (Result == "Login Successful")
            {
                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, jyotishLogin.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("UserId", jyotishLogin.Email.ToString())
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                   _config["Jwt:Issuer"],
                    _config["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(30),
                    signingCredentials: signIn);

                var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new { Token = tokenValue, User = jyotishLogin.Email });
            }

            return Unauthorized();

        }

      
        [Authorize]
        [HttpPost("registerAdmin")]
        public IActionResult RegisterAdmin(AdminModel admin)
        {

            bool Result = _account.SignUpAdmin(admin);
            if (Result == true)
            {
                var result = new { Success = true };
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
