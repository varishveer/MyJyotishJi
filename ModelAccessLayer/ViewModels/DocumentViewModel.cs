using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAccessLayer.ViewModels
{
    public class DocumentViewModel
    {
        [Key]
        public int Id { get; set; }
        public IFormFile IdProof { get; set; }
        public IFormFile AddressProof { get; set; }
        public IFormFile TenthCertificate { get; set; }
        public IFormFile TwelveCertificate { get; set; }
        public string ProfessionalCertificate { get; set; }
    }
}
