using BusinessAccessLayer.Abstraction;
using BusinessAccessLayer.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
        #region Admin
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

        [HttpPost("loginAdmin")]
        public IActionResult LoginAdmin([FromBody] LoginModel login)
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
        #endregion

        #region PJyotish
        [HttpPost("RegisterPJMobile")]
        public IActionResult RegisterPJMobile(string Mobile)
        {
            try {
                var result = _account.PjRegisterAndSendOtp(Mobile);
                if (result) { return Ok(); }
                else { return BadRequest(); }
               
            }
            catch { return BadRequest(); }
             
        }

        [HttpPost("VerifyPJMobile")]
        public IActionResult VerifyPJMobile(string Mobile, int Otp)
        {
            try
            {
                var result = _account.VerifyPJOtp(Mobile,Otp);
                if (result) { return Ok(); }
                else { return BadRequest(); }
            }
            catch { return BadRequest(); }
        }
        [HttpPost("RegisterPendingJyotish")]
        public IActionResult RegisterPendingJyotish(PendingJyotishViewModel jyotishViewModel) 
        {
           /* string? path = _environment.ContentRootPath;*/

            bool Result = _account.SignUpPJyotish(jyotishViewModel);
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
        [HttpPost("LoginPendingJyotish")]
        public IActionResult LoginPendingJyotish(LoginViewModel jyotishLogin)
        {
            string Result = _account.SignInPendingJyotish(jyotishLogin.Mobile, jyotishLogin.Password);
            if (Result == "Login Successful")
            {
                var JyotishName = _account.PJUserName(jyotishLogin.Mobile);
                var UName = JyotishName;
                var token = GenerateJwtToken(jyotishLogin.Mobile, "Scheme3");
                return Ok(new { Token = token, User = jyotishLogin.Mobile, UserName = UName });
            }
            return Unauthorized();

        }
        [HttpGet("ForgotPasswordRequest")]
        public IActionResult PJForgotPasswordOtpRequest(string Email)
        {
            try
            {
                var result = _account.PJForgotPasswordOtpRequest(Email);
                if (result)
                { return Ok(); }
                else
                { return BadRequest(); }
            }
            catch
            { return BadRequest(); }
        }
        [HttpPost("PJForgotPasswordOtpCheck")]
        public IActionResult PJForgotPasswordOtpCheck(ForgotPasswordViewModel model)
        {
            try
            {
                var result = _account.PJForgotPasswordOtpCheck(model.Email, model.Otp);
                if (result)
                { return Ok(); }
                else { return BadRequest(); }
            }
            catch { return BadRequest(); }
        }
        [HttpPost("PjChangePassword")]
        public IActionResult PjChangePassword(ForgotPasswordViewModel model)
        {
            try
            {
                var result = _account.PjSavePassword(model.Email, model.Otp, model.Password);
                if (result)
                { return Ok(); }
                else { return BadRequest(); }
            }
            catch { return BadRequest(); }
        }
        #endregion

        #region Jyotish
        [HttpPost("loginJyotish")]
        public IActionResult LoginJyotish(LoginModel jyotishLogin)
        {
            string Result = _account.SignInJyotish(jyotishLogin);
            if (Result == "Login Successful")
            {
                var name = _account.JyotishUserName(jyotishLogin.Email);
                var token = GenerateJwtToken(jyotishLogin.Email, "Scheme2");
                return Ok(new { Token = token, User = jyotishLogin.Email , UserName = name});
            }
            return Unauthorized();

        }

        
        #endregion

        #region Token
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
        #endregion

        #region User

        [HttpPost("RegisterUserMobile")]
        public IActionResult RegisterUserMobile(string Mobile)
        {
            try
            {
                var result =_account.RegisterUserMobile(Mobile);
                if (result) 
                {
                    var token = GenerateJwtToken(Mobile, "Scheme4");
                    return Ok(new {Token = token}); 
                }
                else { return BadRequest(); }
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Policy = "Policy4")]
        [HttpPost("VerifyUserOtp")]
        public IActionResult VerifyUserOtp(string Mobile , int Otp)
        {
            try
            {
                var result = _account.VerifyUserOtp(Mobile, Otp);
                if (result) { return Ok(); }
                else { return BadRequest(); }
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Policy = "Policy4")]
        [HttpPost("RegisterUserDetails")]
        public IActionResult RegisterUserDetails(UserViewModel _user)
        {
            try
            {
                var result = _account.RegisterUserDetails(_user);
                if (result) { return Ok(); }
                else { return BadRequest(); }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("LoginUser")]
        public IActionResult LoginUser(string Mobile, string Password)
        {
            try
            {
                var result = _account.LoginUser(Mobile, Password);
                if(result == "Successful Login")
                {
                    var token = GenerateJwtToken(Mobile, "Scheme4");
                    return Ok(new { Token = token });
                }
                else
                {
                    return BadRequest(new {result });
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
