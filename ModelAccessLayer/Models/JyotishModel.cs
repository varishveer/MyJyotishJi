using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAccessLayer.Models
{
    public class JyotishModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Language { get; set; }
        public string Extertise { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string ProfileImageUrl { get; set; }
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
