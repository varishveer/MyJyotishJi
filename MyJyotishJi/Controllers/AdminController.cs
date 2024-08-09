using BusinessAccessLayer.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ModelAccessLayer.Models;

namespace MyJyotishJiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminServices _admin;
        public AdminController(IAdminServices admin)
        {
            _admin = admin;
        }
        [HttpGet("Jyotish")]
        public IActionResult AllJyotishRecord()
        {
            var Records = _admin.GetAllJyotish();
            return Ok(Records);
        }
        [HttpGet("PendingJyotish")]
        public IActionResult AllPendingJyotishRecord()
        {
            var Records = _admin.GetAllPendingJyotish();
            return Ok(Records);
        }
        [HttpGet("User")]
        public IActionResult AllUser()
        {
            var Records = _admin.GetAllUser();
            return Ok(Records);
        }
        [HttpGet("TeamMember")]
        public IActionResult AllTeamMember()
        {
            var Records = _admin.GetAllTeamMember();
            return Ok(Records);
        }
        [HttpGet("Appointment")]
        public IActionResult AllAppointment()
        {
            var Records = _admin.GetAllAppointment();
            return Ok(Records);
        }
        [HttpPut("ApproveJyotish")]
        public IActionResult ApproveJyotish(int Id)
        {
            var Records = _admin.ApproveJyotish(Id);
            return Ok(Records);
        }
        [HttpPut("RejectJyotish")]
        public IActionResult RejectJyotish(int Id)
        {
            var Records = _admin.RejectJyotish(Id);
            return Ok(Records);
        }

      
    }
}
