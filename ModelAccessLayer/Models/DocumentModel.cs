using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAccessLayer.Models
{
    public class DocumentModel
    {
        [Key]
        public int Id { get; set; }
        public string IdProof { get; set; }
        public string AddressProof { get; set; }
        public string TenthCertificate { get; set; }
        public string TwelveCertificate { get; set; }
        public string ProfessionalCertificate { get; set; }
        public int JyotishId { get; set; }
        public JyotishModel Jyotish { get; set; }
    }
}
