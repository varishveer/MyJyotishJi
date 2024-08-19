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
        private readonly IConfiguration _configuration;

        public AccountController(IAccountServices account , IWebHostEnvironment environment, IConfiguration configuration)
        {
            _account = account;
            _environment = environment;
            _configuration = configuration;
           
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            // Validate the user credentials (use real validation in a production app)
            string Result = _account.SignInAdmin(login.Email, login.Password);
            if (Result == "Login Successful")
            {
                var token = GenerateJwtToken(login.Email, "Scheme1");

                return Ok(new { Token = token, User = login.Email });
            }

            return Unauthorized();
        }

        [HttpPost("registerJyotish")]
        public IActionResult RegisterJyotish(PendingJyotishViewModel jyotishViewModel) 
        {
           /* string? path = _environment.ContentRootPath;*/

            bool Result = _account.SignUpJyotish(jyotishViewModel);
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
                var token = GenerateJwtToken(jyotishLogin.Email, "Scheme2");
                return Ok(new { Token = token, User = jyotishLogin.Email });
            }
            return Unauthorized();

        }
        [Authorize(Policy = "Policy1")]
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
        [HttpPost("loginPendingJyotish")]
        public IActionResult loginPendingJyotish(LoginModel jyotishLogin)
        {
            string Result = _account.SignInPendingJyotish(jyotishLogin.Email,jyotishLogin.Password);
            if (Result == "Login Successful")
            {
                var Name = _account.PJUserName(jyotishLogin.Email);
                var UName = Name.Result;
                var token = GenerateJwtToken(jyotishLogin.Email, "Scheme3");
                return Ok(new { Token = token, User = jyotishLogin.Email ,UserName = UName });
            }
            return Unauthorized();

        }
        private string GenerateJwtToken(string username, string scheme)
        {
            var key = Encoding.UTF8.GetBytes(_configuration[$"Jwt:{scheme}:Key"]);
            var securityKey = new SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var token = new JwtSecurityToken(
                issuer: _configuration[$"Jwt:{scheme}:Issuer"],
                audience: _configuration[$"Jwt:{scheme}:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
