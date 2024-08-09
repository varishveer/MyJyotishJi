using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAccessLayer.Models
{
    public class AppointmentModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string ProfileImageUrl {  get; set; }
        public string Email { get; set; }
        public int JyotishId { get; set; }
        public int UserId { get; set; }

    }
}
