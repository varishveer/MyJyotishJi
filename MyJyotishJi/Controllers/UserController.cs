using BusinessAccessLayer.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Host.Mef;
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
        [AllowAnonymous]
        [HttpGet("GetAstroListCallChat")]
        public IActionResult GetAstroListCallChat(string ListName)
        {
            try {
                var record = _services.GetAstroListCallChat(ListName); 
                if (record == null) 
                {
                    return BadRequest();
                }
                else { return Ok(new {data= record}); }
            }
            catch { return BadRequest(); }
        }
        [AllowAnonymous]
        [HttpGet("GetAllPoojaCategory")]
        public IActionResult GetAllPoojaCategory()
        {
            try
            {
                var result = _services.GetAllPoojaCategory();
                if (result == null)
                { return BadRequest(); }
                else { return Ok(new { data = result }); }
            }
            catch { return BadRequest(); }
        }
        [AllowAnonymous]
        [HttpGet("GetPoojaList")]
        public IActionResult GetPoojaList(int Id)
        {
            try
            {
                var result = _services.GetPoojaList(Id);
                if (result == null)
                { return BadRequest(); }
                else { return Ok(new { data = result }); }
            }
            catch { return BadRequest(); }
        }
        [AllowAnonymous]
        [HttpGet("GetPoojaDetail")]
        public IActionResult GetPoojaDetail(int PoojaId)
        {
            try
            {
                var result = _services.GetPoojaDetail(PoojaId);
                if (result == null)
                { return BadRequest(); }
                else { return Ok(new { data = result }); }
            }
            catch { return BadRequest(); }
        }

    }
}
