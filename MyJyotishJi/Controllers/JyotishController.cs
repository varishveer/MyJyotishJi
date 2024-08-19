using BusinessAccessLayer.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ModelAccessLayer.ViewModels;
using System.Net;

namespace MyJyotishGApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Policy2")]
    public class JyotishController : ControllerBase
    {
        private readonly IJyotishServices _jyotish;
        private readonly IWebHostEnvironment _environment;
        public JyotishController( IJyotishServices jyotish, IWebHostEnvironment environment)
        {
            _jyotish = jyotish;
            _environment = environment;
        }
        [HttpGet("Appointment")]
        public IActionResult Appointment(string JyotishEmail) 
        {
            var records = _jyotish.Appointment( JyotishEmail);
            return Ok(records);        
        }
        [HttpGet("UpcomingAppointment")]
        public IActionResult UpcomingAppointment(string JyotishEmail)
        {
            var records = _jyotish.UpcomingAppointment( JyotishEmail);
            return Ok(records);
        }
        [HttpPost("AddAppointment")]
        public IActionResult AddAppointment(AppointmentViewModel appointment)
        {
            var result =_jyotish.AddAppointment(appointment);
            return Ok(result);
        }
        [HttpPost("AddTeamMember")]
        public IActionResult AddTeamMember(TeamMemberViewModel team)
        {
            string? path = _environment.ContentRootPath;
            var records = _jyotish.AddTeamMember(team, path);
            return Ok(records);
        }
        [HttpGet("TeamMember")]
        public IActionResult TeamMember(int JyotishId)
        {
            var records = _jyotish.TeamMember(JyotishId);
            return Ok(records);
        }
        [HttpGet("Country")]
        public IActionResult Country() 
        {
            var Record = _jyotish.CountryList();
            return Ok(new { data = Record });
        }
        [HttpGet("State")]
        public IActionResult State(int Id)
        {
            var Record = _jyotish.StateList(Id);
            return Ok(new { data = Record });
        }
        [HttpGet("City")]
        public IActionResult City(int Id)
        {
            var Record = _jyotish.CityList(Id);
            return Ok(new { data = Record });
        }

        [HttpGet("Expertise")]
        public IActionResult Expertise()
        {
            var Records = _jyotish.ExpertiseList();
            return Ok(new { data = Records });
        }

        
    }
}
