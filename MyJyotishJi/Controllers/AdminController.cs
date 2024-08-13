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
            return Ok(new { Success = true, data = Records });
        }
        [HttpGet("PendingJyotish")]
        public IActionResult AllPendingJyotishRecord()
        {
            var Records = _admin.GetAllPendingJyotish();
            return Ok(new { Success = true, data = Records });
        }
        [HttpGet("User")]
        public IActionResult AllUser()
        {
            var Records = _admin.GetAllUser();

            return Ok(new { Success = true, data = Records });

        }
        [HttpGet("TeamMember")]
        public IActionResult AllTeamMember()
        {
            var Records = _admin.GetAllTeamMember();
            return Ok(new { Success = true, data = Records });
        }
        [HttpGet("Appointment")]
        public IActionResult AllAppointment()
        {
            List<AppointmentModel> Records = _admin.GetAllAppointment();

            return Ok(new { Success = true, data = Records });
        }

        [HttpPost("ApproveJyotish")]
        public IActionResult ApproveJyotish(int Id)
        {
            var Records = _admin.ApproveJyotish(Id);
            return Ok(new { Success = true, data = Records });
        }
        [HttpPost("RejectJyotish")]
        public IActionResult RejectJyotish(int Id)
        {
            var Records = _admin.RejectJyotish(Id);
            return Ok(new { Success = true, data = Records });
        }

        [HttpPost("AddPooja")]
        public IActionResult AddPooja(PoojaModel pooja)
        {
            var result = _admin.AddPooja(pooja);
            if (result == true)
            {
                return Ok(new { success = true });
            }
            else { return BadRequest(); }
        }

        [HttpPost("AddExpertise")]
        public IActionResult AddExpertise(ExpertiseModel expertise)
        {
            var result = _admin.AddExpertise(expertise);
            if (result == true)
            {
                return Ok(new { success = true });
            }
            else { return BadRequest(); }
        }

        [HttpGet("PoojaList")]
        public IActionResult PoojaList()
        {
            var Records = _admin.GetAllPooja();
            return Ok(new { Success = true, data = Records });

        }
        [HttpGet("ExpertiseList")]
        public IActionResult ExpertiseList()
        {
            var Records = _admin.GetAllExpertise();
            return Ok(new { Success = true, data = Records });

        }

    }
}
