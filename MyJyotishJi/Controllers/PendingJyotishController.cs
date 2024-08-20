using BusinessAccessLayer.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelAccessLayer.ViewModels;

namespace MyJyotishGApi.Controllers
{
    [Authorize(Policy = "Policy3")]
    [Route("api/[controller]")]
    [ApiController]
    public class PendingJyotishController : ControllerBase
    {
        private readonly IPendingJyotishServices _pendingJyotishServices;
        public PendingJyotishController(IPendingJyotishServices pendingJyotishServices)
        {
            _pendingJyotishServices = pendingJyotishServices;
        }

        [HttpGet("Dashboard")]
        public IActionResult Dashboard() 
        {
            return Ok();
        }
        [HttpGet("Documents")]
        public IActionResult Documents(string Email)
        {
            try {
                var Records = _pendingJyotishServices.Documents(Email);
                if(Records == null)
                { return BadRequest(); }
                else { return Ok(new { data = Records }); }
                
            }
            catch { return BadRequest(); }
            
        }
        [AllowAnonymous]
        [HttpPost("UploadDocument")]
        public async Task<IActionResult> UploadDocument(DocumentViewModel model)
        {
            var success = await _pendingJyotishServices.UploadDocumentAsync(model);

            if (success)
            {
                return Ok(new { Message = "Files and data uploaded successfully." });
            }
            else
            {
                return StatusCode(500, "An error occurred while processing files.");
            }
        }

        [HttpGet("Profile")]
        public async Task<IActionResult> Profile(string Email)
        {
            var result = await _pendingJyotishServices.Profile(Email);
            if(result == null) { return BadRequest(); }
            else { return Ok(new { data = result }); }
        }
    }
}
