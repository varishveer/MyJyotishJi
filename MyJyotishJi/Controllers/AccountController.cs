﻿using BusinessAccessLayer.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelAccessLayer.Models;
using ModelAccessLayer.ViewModels;

namespace MyJyotishJiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountServices _account;
        private readonly IWebHostEnvironment _environment;
        public AccountController(IAccountServices account , IWebHostEnvironment environment)
        {
            _account = account;
            _environment = environment;
        }

        [HttpPost("registerJyotish")]
        public IActionResult RegisterJyotish(PendingJyotishViewModel jyotishViewModel) 
        {
            string? path = _environment.ContentRootPath;

            bool Result = _account.SignUpJyotish(jyotishViewModel,path);
            if (Result == true)
            { return Ok(); }
            else
            {
                return BadRequest();
            }
            
        }
        [HttpPost("loginJyotish")]
        public IActionResult LoginJyotish(JyotishLoginModel jyotishLogin)
        {
            string Result = _account.SignInJyotish(jyotishLogin);
            if (Result == "Login Successfull")
            { return Ok(); }
            else
            {
                return BadRequest(Result);
            }

        }

        [HttpPost("loginAdmin")]
        public IActionResult LoginAdmin( string email, string password)
        {
            string Result = _account.SignInAdmin(email, password);
            if (Result == "Login Successfull")
            { return Ok(); }
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
            { return Ok(); }
            else
            {
                return BadRequest();
            }

        }
    }
}
