using BusinessAccessLayer.Abstraction;
using DataAccessLayer.DbServices;
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
        public bool SignUpJyotish(JyotishViewModel jyotishView)
        {
            const string DateFormat = "yyyy-MM-dd";
           
            JyotishModel jyotish = new JyotishModel() 
            { 
                Name = jyotishView.Name,
                DateOfBirth = DateOnly.ParseExact(jyotishView.DateOfBirth, DateFormat, null),
                Gender = jyotishView.Gender,
                Language= jyotishView.Language,
                Expertise = jyotishView.Expertise,
                Email = jyotishView.Email,
                Mobile = jyotishView.Mobile,
                ProfileImageUrl = jyotishView.ProfileImageUrl,
                Password = "test"
            };


            _context.JyotishRecords.Add(jyotish);
            _context.SaveChanges();
            return true;
        }

        public string SignInJyotish(JyotishLoginModel jyotishLogin)
        {
            var Record =_context.JyotishRecords.Where(x => x.Email == jyotishLogin.Email).FirstOrDefault();
            if (Record != null)
            {
                if (Record.Password == jyotishLogin.Password)
                {
                    return "Login Successfull";
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
            AdminModel _admin = new AdminModel() 
            { 
                Name = admin.Name,
                Email = admin.Email,
                Password = admin.Password,
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
                    return "Login Successfull";
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
