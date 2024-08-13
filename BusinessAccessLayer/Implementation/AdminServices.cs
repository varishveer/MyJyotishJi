using BusinessAccessLayer.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DbServices;
using ModelAccessLayer.Models;

namespace BusinessAccessLayer.Implementation
{
    public class AdminServices:IAdminServices
    {
        private readonly ApplicationContext _context;
        public AdminServices(ApplicationContext context)
        {
            _context = context;
        }

        public List<JyotishModel> GetAllJyotish()
        {
            var Records = _context.JyotishRecords.ToList();
            return Records;
        }

        public List<PendingJyotishModel> GetAllPendingJyotish()
        {
            var Records = _context.PendingJyotishRecords.ToList();
            return Records;
        }
        public List<UserModel> GetAllUser()
        {
            var Records = _context.Users.ToList();
            return Records;
        }
        public List<TeamMemberModel> GetAllTeamMember()
        {
            var Records = _context.TeamMemberRecords.ToList();
            return Records;
        }

        public List<AppointmentModel> GetAllAppointment()
        {
            var Records = _context.AppointmentRecords.ToList();
            return Records;
        }
        public bool ApproveJyotish(int JyotishId )
        {
            var Jyotish = _context.PendingJyotishRecords.Where(x => x.Id == JyotishId).FirstOrDefault();
            if (Jyotish == null)
            { return false; }
            Jyotish.Status = "Approved";
            JyotishModel model = new JyotishModel()
            { 
                Name = Jyotish.Name,
                DateOfBirth = Jyotish.DateOfBirth,
                Gender = Jyotish.Gender,
                Language = Jyotish.Language,
                Expertise = Jyotish.Expertise,
                Email = Jyotish.Email,
                Mobile = Jyotish.Mobile,
                ProfileImageUrl = Jyotish.ProfileImageUrl,
            };
            _context.PendingJyotishRecords.Update(Jyotish);
            _context.JyotishRecords.Add(model);
            var result = _context.SaveChanges();
            if (result > 0)
            { return true; }
            else { return false; }
            
        }

        public bool RejectJyotish(int JyotishId)
        {
            var Jyotish = _context.PendingJyotishRecords.Where(x => x.Id == JyotishId).FirstOrDefault();
            if (Jyotish == null)
            { return false; }
            _context.PendingJyotishRecords.Remove(Jyotish);
            _context.SaveChanges();
            return true;
        }
    }
}
