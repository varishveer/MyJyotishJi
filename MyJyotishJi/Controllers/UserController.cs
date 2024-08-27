using BusinessAccessLayer.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelAccessLayer.Models;

namespace MyJyotishGApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserServices _services;
        public UserController(IUserServices services)
        {
            _services = services;
        }

        [HttpGet("HomePageSlider")]
        public IActionResult HomaPageSlider()
        {
            try {
                var record = _services.HomaPageSlider();
                if (record == null) { return BadRequest(); }
                return Ok(new { data = record });
            }
            catch { return BadRequest(); }
        }

        [HttpGet("BAPCategorySlider")]
        public IActionResult BAPCategorySlider()
        {
            try
            {
                var record = _services.PoojaListSlider();
                if (record == null) { return BadRequest(); }
                return Ok(new { data = record });
            }
            catch { return BadRequest(); }
        }
        [HttpGet("PoojaListSlider")]
        public IActionResult PoojaListSlider()
        {
            try
            {
                var record = _services.PoojaListSlider();
                if (record == null) { return BadRequest(); }
                return Ok(new { data = record });
            }
            catch { return BadRequest(); }
        }
    }
}
