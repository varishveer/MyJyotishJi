using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAccessLayer.Models
{
    public  class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        
        public string? Mobile { get; set; }
        public DateOnly? DoB { get; set; }
        public string? Password { get; set; }
        public string? Gender { get; set; }
        public TimeOnly? TimeOfBirth { get; set; }
        public string? PlaceOfBirth { get; set; }
        public string? CurrentAddress { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public int? Pincode { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string Pending { get; set; }

    }
}
