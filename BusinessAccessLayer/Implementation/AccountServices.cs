using BusinessAccessLayer.Abstraction;
using DataAccessLayer.DbServices;

using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
using ModelAccessLayer.Models;
using ModelAccessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BusinessAccessLayer.Implementation
{
    public class AccountServices:IAccountServices
    {
        private readonly ApplicationContext _context;
        public AccountServices(ApplicationContext context)
        {
            _context = context;
        }


        public bool SignUpJyotish(PendingJyotishViewModel jyotishView )
        {
            var IsEmailValid = _context.JyotishRecords.Where(x => x.Email == jyotishView.Email).FirstOrDefault();
            var IsEmailValidPending = _context.PendingJyotishRecords.Where(x => x.Email == jyotishView.Email).FirstOrDefault();
            var IsMobileValid = _context.JyotishRecords.Where(x => x.Mobile == jyotishView.Mobile).FirstOrDefault();
            var IsMobileValidPending = _context.PendingJyotishRecords.Where(x => x.Mobile == jyotishView.Mobile).FirstOrDefault();
            if (IsEmailValid != null || IsMobileValid != null || IsMobileValidPending != null || IsEmailValidPending != null)
            { return false; }

           


            var CountryName = _context.Countries.Where(x => x.Id == jyotishView.Country).FirstOrDefault();
            var StateName = _context.States.Where(x => x.Id == jyotishView.State).FirstOrDefault();
            var CityName = _context.Cities.Where(x => x.Id == jyotishView.City).FirstOrDefault();
            PendingJyotishModel jyotish = new PendingJyotishModel() 
            { 
                Name = jyotishView.Name,
                Mobile = jyotishView.Mobile,
                Email = jyotishView.Email,
                Gender = jyotishView.Gender,
                Language= jyotishView.Language,
                Expertise = jyotishView.Expertise,
                Country = CountryName.Name,
                State = StateName.Name,
                City = CityName.Name,
                Password = Guid.NewGuid().ToString("N").Substring(0, 8),


                Role = "Pending Jyotish",
                Status = "Pending",

            };


            _context.PendingJyotishRecords.Add(jyotish);
            var result = _context.SaveChanges();
            if (result > 0) 
            {
                var message = "Dear Jyotish ," +
                    "/n Your account has been successfully created and your Credential are below , \n Email : " + jyotish.Email + "\n Password: " + jyotish.Password;
                var subject = "MyJyotishG Account Credential";
                SendEmail(message,jyotish.Email , subject);
                return true;
            }
            return false;
        }
      

        public string SignInJyotish(LoginModel jyotishLogin)
        {
            var Record =_context.JyotishRecords.Where(x => x.Email == jyotishLogin.Email).FirstOrDefault();
            if (Record != null)
            {
                if (Record.Password == jyotishLogin.Password)
                {
                    return "Login Successful";
                }
                else
                {
                    return "Incorrect Password";
                }
            }
            else
            { return "Invalid Email"; }
           
        }

        public bool SignUpAdmin(AdminModel admin)
        {

            var IsEmailValid = _context.AdminRecords.Where(x => x.Email == admin.Email).FirstOrDefault();
           
            if (IsEmailValid != null )
            { return false; }
            AdminModel _admin = new AdminModel() 
            { 
                Name = admin.Name,
                Email = admin.Email,
                Password = admin.Password,
                Role = "Admin",
            };
            _context.AdminRecords.Add(_admin);
            _context.SaveChanges();
            return true;
        }
        public string SignInAdmin(string email, string password) 
        {
            var _admin = _context.AdminRecords.Where(x => x.Email == email).FirstOrDefault();
            if (_admin != null) 
            {
                if (_admin.Password == password)
                {
                    return "Login Successful";
                }
                else
                {
                    return "Incorrect Password";
                }
            }
            else
            { return "Invalid Email"; }
        }

        public bool SendEmail(string MessageBody, string Mail, string Subjectbody)
        {
            try
            {
                // Sender's email address and app-specific password
                string senderEmail = "variveersingh123@gmail.com";
                string senderPassword = "htjp emoj tahk qqaj"; // Ensure this is an app-specific password if 2FA is enabled

                // Recipient's email address
                string recipientEmail = Mail;

                // SMTP server details
                string smtpServer = "smtp.gmail.com";
                int smtpPort = 587; // Use port 587 for TLS

                // Create and configure the SMTP client
                using (SmtpClient client = new SmtpClient(smtpServer, smtpPort))
                {
                    client.EnableSsl = true; // Ensure SSL/TLS is enabled
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(senderEmail, senderPassword);

                    // Create the email message
                    MailMessage message = new MailMessage(senderEmail, recipientEmail)
                    {
                        Subject = Subjectbody,
                        Body = MessageBody,
                    };

                    // Send the email
                    client.Send(message);

                    // If no exception is thrown, email was sent successfully
                    Console.WriteLine("Email sent successfully.");
                    return true;
                }
            }
            catch (SmtpException smtpEx)
            {
                // Handle specific SMTP errors
                Console.WriteLine($"SMTP error: {smtpEx.StatusCode} - {smtpEx.Message}");
            }
            catch (Exception ex)
            {
                // Handle other general errors
                Console.WriteLine($"Failed to send email. Error message: {ex.Message}");
            }

            // If we reach here, it means the email sending failed
            return false;
        }

        public string SignInPendingJyotish(string email, string password)
        {
            var _pJyotish = _context.PendingJyotishRecords.Where(x => x.Email == email).FirstOrDefault();
            if (_pJyotish != null)
            {
                if (_pJyotish.Password == password)
                {
                    return "Login Successful";
                }
                else
                {
                    return "Incorrect Password";
                }
            }
            else
            { return "Invalid Email"; }
        }

        public async Task<string> PJUserName(string Email)
        {
            var model = await _context.PendingJyotishRecords.Where(x => x.Email == Email).FirstOrDefaultAsync();
            if (model == null) { return null; }
            else { return model.Name; }
            
        }

    }
}
