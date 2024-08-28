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
        #region PJ
        public bool PjRegisterAndSendOtp(string Mobile);
        public bool VerifyPJOtp(string Mobile, int Otp);
        public bool SignUpPJyotish(PendingJyotishViewModel jyotishView );
        public string SignInPendingJyotish(string mobile, string password);
        public string PJUserName(string Mobile);
        public bool PJForgotPasswordOtpRequest(string Email);
        public bool PJForgotPasswordOtpCheck(string Email, int Otp);
        public bool PjSavePassword(string Email, int Otp, string Password);

        #endregion

        #region Admin
        public bool SignUpAdmin(AdminModel admin);
        public string SignInAdmin(string email, string password);
        #endregion

        #region Jyotish
        public string SignInJyotish(LoginModel jyotishLogin);
        public string JyotishUserName(string Email);
        #endregion

        #region User
        public bool RegisterUserMobile(string Email);
        public bool VerifyUserOtp(string Mobile, int Otp);
        public bool RegisterUserDetails(UserViewModel _user);
        public string LoginUser(string Mobile, string Password);
        #endregion

      
    }
}
