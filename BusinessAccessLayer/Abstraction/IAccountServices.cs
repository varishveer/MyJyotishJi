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

        public bool SignUpJyotish(PendingJyotishViewModel jyotishView );
        public string SignInJyotish(LoginModel jyotishLogin);
        public bool SignUpAdmin(AdminModel admin);
        public string SignInAdmin(string email , string password);
        public string SignInPendingJyotish(string email, string password);
        public  Task<string> PJUserName(string Email);
        public bool PJForgotPasswordOtpRequest(string Email);
        public bool PJForgotPasswordOtpCheck(string Email, string Otp);
        public bool PjSavePassword(string Email, string Otp, string Password);
        public string JyotishUserName(string Email);
        public bool RegisterUserMobile(string Email);
        public bool VerifyUserOtp(string Mobile, int Otp);
        public bool RegisterUserDetails(UserViewModel _user);

        public string LoginUser(string Mobile, string Password);
    }
}
