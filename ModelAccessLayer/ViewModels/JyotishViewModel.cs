using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAccessLayer.ViewModels
{
    public class JyotishViewModel
    {
        
        public int Id { get; set; }
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
        [Required]
        public string ProfileImageUrl { get; set; }

        

        public int? Experience { get; set; }
        public string? Pooja { get; set; }
        public string? Password { get; set; }
        public bool? Call { get; set; }
        public int? CallCharges { get; set; }
        public bool? Chat { get; set; }
        public int? ChatCharges { get; set; }
        public string? Address { get; set; }

        public string? TimeTo { get; set; }
        public string? TimeFrom { get; set; }
    }
}
