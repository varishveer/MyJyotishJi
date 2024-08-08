using ModelAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Abstraction
{
    public interface IAccountServices
    {
        public bool SignUp(UserTempModel userTemp);
        public string Verification(UserTempModel userTemp);
    }
}
