using ModelAccessLayer.Models;
using ModelAccessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Abstraction
{
    public interface IAccountServices
    {

        public bool SignUpJyotish(JyotishViewModel jyotishView);
        public string SignInJyotish(JyotishLoginModel jyotishLogin);
        public bool SignUpAdmin(AdminModel admin);
        public string SignInAdmin(string email , string password);
    }
}
