using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAccessLayer.Models
{
    public class JyotishModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateOnly DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public string Extertise { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string ProfileImageUrl { get; set; }
        [Required]
        public string? Experience { get; set; }
        public string? Pooja { get; set; }
        public string? Password { get; set; }
        public Boolean? Call { get; set; } 
        public string? CallCharges { get; set; }
        public string? Chat { get; set; }
        public string? ChatCharges { get; set; }
        public string? Address { get; set; }

        public TimeOnly? TimeTo { get; set; }
        public TimeOnly? TimeFrom { get; set; }



    }
}
