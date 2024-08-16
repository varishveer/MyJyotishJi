using BusinessAccessLayer.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ModelAccessLayer.ViewModels;

namespace MyJyotishGApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
    }
}
