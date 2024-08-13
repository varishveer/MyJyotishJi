using BusinessAccessLayer.Abstraction;
using BusinessAccessLayer.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using ModelAccessLayer.Models;
using ModelAccessLayer.ViewModels;
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


       /* private readonly string _secretKey = "c2VjdXJlc2VjdXJlc2VjdXJlc2VjdXJlc2VjdXJlc2VjdXJlcw=="; // Replace with your key
        private readonly string _issuer = "your-app"; // Placeholder value
        private readonly string _audience = "your-app"; // Placeholder value


        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            // Validate the user credentials (use real validation in a production app)
            string Result = _account.SignInJyotish(loginModel);
            if (Result == "Login Successful")
            {
                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, loginModel.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

                var key = Convert.FromBase64String(_secretKey);
                var creds = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _issuer,
                    audience: _audience,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new { Token = tokenString });
            }

            return Unauthorized();
        }*/

        
        
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

        /* [AllowAnonymous]
         [HttpPost]
         public IActionResult LoginJyotish(LoginModel jyotishLogin)
         {
             var response = Unauthorized();
             string Result = _account.SignInJyotish(jyotishLogin);
             if (Result == "Login Successful")
             {

                 var tokenString = GeneratedJsonWebToken(jyotishLogin);
                 var result = new { Success = true,token = tokenString };
                 return Ok(result);

             }
             else
             {
                 return response;
             }

         }*/
        /*private string GeneratedJsonWebToken(LoginModel jyotishLogin) 
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new  SigningCredentials(securityKey ,SecurityAlgorithms.HmacSha256);
            var claims = new[] {
            new Claim (JwtRegisteredClaimNames.Email, jyotishLogin.Email)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Issuer"],claims,expires:DateTime.Now.AddMinutes(30),signingCredentials:credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }*/

        [HttpPost("loginJyotish")]
        public IActionResult LoginJyotish(LoginModel jyotishLogin)
        {
            string Result = _account.SignInJyotish(jyotishLogin);
            if (Result == "Login Successful")
            {

                var result = new { Success = true };
                return Ok(result);

            }
            else
            {
                return BadRequest(Result);
            }

        }

        [HttpPost("loginAdmin")]
        public IActionResult LoginAdmin(LoginModel login)
        {
            string Result = _account.SignInAdmin(login.Email, login.Password);
            if (Result == "Login Successful")
            {
               /* var tokenString = GeneratedJsonWebToken(login);*/
                var result = new { Success = true };
                return Ok(result);
            }
            else
            {
                return BadRequest(Result);
            }

        }
        
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
