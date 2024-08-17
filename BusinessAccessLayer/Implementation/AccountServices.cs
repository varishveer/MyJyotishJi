using BusinessAccessLayer.Abstraction;
using DataAccessLayer.DbServices;

using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
using ModelAccessLayer.Models;
using ModelAccessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            /* Random random = new Random();
             // Generate a random number between 1000000000 and 9999999999
             long randomNumber = (long)(random.NextDouble() * 9000000000) + 1000000000;
             var filePath = "/Assets/Images/Jyotish/" + randomNumber + jyotishView.Image.FileName;

             var fullPath = path + filePath;
             UploadFile(jyotishView.Image, fullPath);*/


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
               
               
                Role = "Pending Jyotish",
                Status = "Pending",

            };


            _context.PendingJyotishRecords.Add(jyotish);
            var result = _context.SaveChanges();
            if (result > 0) { return true; }
            return false;
        }
       /* public void UploadFile(IFormFile file, string fullPath)
        {
            FileStream stream = new FileStream(fullPath, FileMode.Create);
            file.CopyTo(stream);
        }*/

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
    }
}
