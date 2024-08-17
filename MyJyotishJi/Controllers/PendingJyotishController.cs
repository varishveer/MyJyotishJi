using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyJyotishGApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PendingJyotishController : ControllerBase
    {
        [HttpGet("Status")]
        public IActionResult Status() 
        {
            return Ok();
        }
        [HttpGet("Documents")]
        public IActionResult Documents() 
        { 
            return Ok();
        }
        [HttpPost("UploadDocument")]
        public IActionResult UploadDocument() 
        {
            return Ok();
        } 
    }
}
