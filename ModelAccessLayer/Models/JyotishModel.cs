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
        public string Expertise { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string ProfileImageUrl { get; set; }
        public string Role { get; set; }
        
        public int? Experience { get; set; }
        public string? Pooja { get; set; }
        public string? Password { get; set; }
        public bool? Call { get; set; } 
        public int? CallCharges { get; set; }
        public bool? Chat { get; set; }
        public int? ChatCharges { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public TimeOnly? TimeTo { get; set; }
        public TimeOnly? TimeFrom { get; set; }


        public ICollection<CallingModel> CallingModelRecord { get; set; } = new List<CallingModel>();
        public ICollection<ChattingModel> ChattingModelRecord { get; set; } = new List<ChattingModel>();
        public ICollection<PoojaRecordModel> PoojaModelRecord { get; set; } = new List<PoojaRecordModel>();
        public DocumentModel DocumentModel { get; set; }
    }

}



