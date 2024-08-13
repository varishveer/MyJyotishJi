﻿using BusinessAccessLayer.Abstraction;
using DataAccessLayer.DbServices;
using DataAccessLayer.Migrations;
using Microsoft.AspNetCore.Http;
using ModelAccessLayer.Models;
using ModelAccessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Implementation
{
    public class JyotishServices:IJyotishServices
    {
        private readonly ApplicationContext _context;
        public JyotishServices(ApplicationContext context)
        {
            _context = context;
        }
        public List<AppointmentModel> Appointment(string JyotishEmail) 
        {
            var Jyotish = _context.JyotishRecords.Where(x => x.Email == JyotishEmail).FirstOrDefault();
            var Records = _context.AppointmentRecords.Where(x=>x.JyotishId == Jyotish.Id).ToList();
            return Records;
        }
        public List<AppointmentModel> UpcomingAppointment(string JyotishEmail)
        {
            var Jyotish = _context.JyotishRecords.Where(x => x.Email == JyotishEmail).FirstOrDefault();
            DateTime Today =DateTime.Now;
            var Records = _context.AppointmentRecords.Where(e => e.DateTime > Today).Where(x=> x.JyotishId == Jyotish.Id).ToList();
            return Records;
        }
        public string AddAppointment(AppointmentViewModel appointment) 
        {
            var user = _context.Users.Where(x => x.Mobile == appointment.Mobile).FirstOrDefault();
            var Jyotish = _context.JyotishRecords.Where(x => x.Email == appointment.JyotishEmail).FirstOrDefault();
            if (user == null) 
            { return "User not found"; }
            if (Jyotish == null)
            { return "Something Went Wrong"; }


            AppointmentModel newAppointment = new AppointmentModel()
            {
                Mode = appointment.Mode,
                Name = appointment.Name,
                Mobile = appointment.Mobile,
                DateTime = appointment.DateTime,

                Email = appointment.Email,
                JyotishId = Jyotish.Id,
                UserId = user.Id,
                Problem = appointment.Problem,
                Solution = "",
                Status = "Pending",
                Amount = appointment.Amount,
            };

            _context.AppointmentRecords.Add(newAppointment);
            var result  = _context.SaveChanges();
            if (result > 0)
            { return "Appointment booked Successfully"; }
            else { return "Appointment not booked"; }
                   
        }

        public List<TeamMemberModel> TeamMember(int JyotishId)
        {
            var records = _context.TeamMemberRecords.Where(x => x.JyotishId == JyotishId).ToList();
            return records;
        }
        public string AddTeamMember(TeamMemberViewModel teamMember,string path) 
        {
            var IsEmailValid = _context.TeamMemberRecords.Where(x => x.Email == teamMember.Email).FirstOrDefault();
            var IsMobileValid = _context.TeamMemberRecords.Where(x => x.Mobile == teamMember.Mobile).FirstOrDefault();
            if (IsEmailValid != null || IsMobileValid != null)
            { return "Email or Mobile no. Already Exist"; }

            var IsJyotishValid = _context.JyotishRecords.Where(x => x.Email == teamMember.JyotishEmail).FirstOrDefault();
            if (IsJyotishValid == null) 
            { return "Jyotish Not found";}

            Random random = new Random();
            // Generate a random number between 1000000000 and 9999999999
            long randomNumber = (long)(random.NextDouble() * 9000000000) + 1000000000;
            var filePath = "/Assets/Images/TeamMember/" + randomNumber + teamMember.ProfilePicture.FileName;

            var fullPath = path + filePath;
            UploadFile(teamMember.ProfilePicture, fullPath);

            TeamMemberModel model = new TeamMemberModel() 
            {
                Name= teamMember.Name,
                Mobile = teamMember.Mobile,
                ProfilePictureUrl = filePath,
                Email = teamMember.Email,
                Role= "TeamMember",
                JyotishId = IsJyotishValid.Id,
            };
            _context.TeamMemberRecords.Add(model);
             var result = _context.SaveChanges();
            if (result > 0)
            {
                return "Record Saved Successfully";
            }
            else 
            {
                return "Records Not Saved";
            }
        }
        public void UploadFile(IFormFile file, string fullPath)
        {
            FileStream stream = new FileStream(fullPath, FileMode.Create);
            file.CopyTo(stream);
        }
    }
}
