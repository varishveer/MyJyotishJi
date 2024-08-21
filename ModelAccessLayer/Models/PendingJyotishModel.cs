using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAccessLayer.Models
{
    public class PendingJyotishModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
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
        public string Country { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
        public string Password { get; set; }
        [AllowNull]
        public DateTime? DateOfBirth { get; set; }
        [AllowNull]
        public string? ProfileImageUrl { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public DocumentModel DocumentModel { get; set; }
        [AllowNull]
        public string? Otp { get; set; }
    }
}
