using BusinessAccessLayer.Abstraction;
using ModelAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DbServices;

namespace BusinessAccessLayer.Implementation
{
    public class AccountServices:IAccountServices
    {
        private readonly ApplicationContext _context;
        public AccountServices(ApplicationContext context)
        {
            _context = context;
        }

        public bool SignUp(UserTempModel userTemp)
        {
            userTemp.StoredTime = DateTime.Now;
            userTemp.Otp = SendEmailOpt(userTemp.Email, userTemp.FirstName);
            _context.UserTemp.Add(userTemp);
            _context.SaveChanges();
            return true;
        }
        public  int SendEmailOpt(string Email, string Name)
        {

            int sixDigitNumber = new Random().Next(100000, 999999);
            // Sender's email address and credentials
            string senderEmail = "varishveer123@gmail.com";
            string senderPassword = "vjcx xhzp oumw xhdh";

            // Recipient's email address
            string recipientEmail = Email;

            // SMTP server address and port number
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587; // Use 587 for TLS or 465 for SSL

            // Create a new SMTP client
            using (SmtpClient client = new SmtpClient(smtpServer, smtpPort))
            {
                client.EnableSsl = true; // Enable SSL/TLS
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);

                // Create a new email message
                MailMessage message = new MailMessage(senderEmail, recipientEmail)
                {
                    Subject = "My Jyotish Ji",
                    Body = "Hello " + Name + ", Your verification code is " + sixDigitNumber + "."
                };
                // Send the email
                client.Send(message);
                return sixDigitNumber;
            }
        }

        public string Verification(UserTempModel userTemp)
        {
            UserTempModel user = _context.UserTemp.Where(x => x.Email == userTemp.Email).FirstOrDefault();
            if (userTemp != null && user != null)
            {
                if (user.Email == userTemp.Email)
                {
                    if (user.Otp == userTemp.Otp)
                    {
                        UserModel userModel = new UserModel()
                        {
                            Email = userTemp.Email,
                            FirstName = userTemp.FirstName
                        };
                        _context.Users.Add(userModel);
                        _context.SaveChanges();
                        return "Success";

                    }
                    else
                    { return "Invalid Otp"; }
                }
                else
                { return "Invalid Email"; }
                
            }
            else 
            { return "Invalid Data"; }
            
        }
    }
}
