using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAccessLayer.ViewModels
{
    public class PendingJyotishViewModel
    {
        
       
        [Required]
        public string Name { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public string Expertise { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Mobile { get; set; }
      
        public string? ProfileImageUrl { get; set; }
        public IFormFile? Image { get; set; }

        

       
    }
}
