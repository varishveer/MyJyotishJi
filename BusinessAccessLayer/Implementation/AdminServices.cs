using BusinessAccessLayer.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DbServices;
using ModelAccessLayer.Models;

using ModelAccessLayer.ViewModels;


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
        public bool ApproveJyotish(IdViewModel JyotishId )
        
        {
            var Jyotish = _context.PendingJyotishRecords.Where(x => x.Id == JyotishId.Id).FirstOrDefault();
            if (Jyotish == null)
            { return false; }
            var IsJyotishExist = _context.JyotishRecords.Where(x => x.Mobile == Jyotish.Mobile).Where(x => x.Email == Jyotish.Email).FirstOrDefault();
            if (IsJyotishExist != null)
            {
                return false;
            }
            Jyotish.Status = "Approved";
          
            JyotishModel model = new JyotishModel()
            { 
                Name = Jyotish.Name,
                DateOfBirth = Jyotish.DateOfBirth ,
                Gender = Jyotish.Gender,
                Language = Jyotish.Language,
                Expertise = Jyotish.Expertise,
                Email = Jyotish.Email,
                Mobile = Jyotish.Mobile,
                ProfileImageUrl = Jyotish.ProfileImageUrl,
                Role = "Jyotish"
            };
            _context.PendingJyotishRecords.Update(Jyotish);
            _context.SaveChanges();
            _context.JyotishRecords.Add(model);
            var result = _context.SaveChanges();
            if (result > 0)
            { return true; }
            else { return false; }
            
        }

        public bool RejectJyotish(IdViewModel JyotishId)
        {
            var Jyotish = _context.PendingJyotishRecords.Where(x => x.Id == JyotishId.Id).FirstOrDefault();
            if (Jyotish == null)
            { return false; }
            Jyotish.Status = "Rejected";
            _context.PendingJyotishRecords.Update(Jyotish);
            var result = _context.SaveChanges();
            if (result > 0) { return true; }
            else
            {
                return false;
            }
        }

        public bool RemoveJyotish(IdViewModel JyotishId) 
        {
            var Jyotish = _context.PendingJyotishRecords.Where(x => x.Id == JyotishId.Id).FirstOrDefault();
            if (Jyotish == null || Jyotish.Status != "Rejected")
            { return false; }
            _context.PendingJyotishRecords.Remove(Jyotish);
            var result = _context.SaveChanges();
            if (result > 0) { return true; }
            else
            {
                return false;
            }

        }

        public bool AddPooja(PoojaModel _pooja)
        {
            var isPoojaValid = _context.Pooja.Where(x => x.Name == _pooja.Name).FirstOrDefault();
            if (isPoojaValid != null) { return false; }
            _pooja.DateAdded = DateTime.Now;
            _context.Pooja.Add(_pooja);
            var result = _context.SaveChanges();
            if (result > 0)
            { return true; }
            else
            { return false; }
            
        }
        public bool AddExpertise(ExpertiseModel _expertise)
        {
            var isExpertiseValid = _context.ExpertiseRecords.Where(x => x.Name == _expertise.Name).FirstOrDefault();
            if (isExpertiseValid != null) { return false; }
            _expertise.DateAdded = DateTime.Now;
            _context.ExpertiseRecords.Add(_expertise);
            var result = _context.SaveChanges();
            if (result > 0)
            { return true; }
            else
            { return false; }

        }

        public List<PoojaModel> GetAllPooja()
        {
            var records = _context.Pooja.ToList();
            return records;
        }

        public List<ExpertiseModel> GetAllExpertise()
        {
            var records = _context.ExpertiseRecords.ToList();
            return records;
        }

        public AdminModel Profile(string email)
        {
            var record = _context.AdminRecords.Where(x => x.Email == email).FirstOrDefault();
            if (record == null)
            {
                return null;
              
            }
            else
            {
                return record;
            }
        }
        public AdminDashboardViewModal Dashboard()
        {
            int Users = _context.Users.Count();
            int Jyotish = _context.JyotishRecords.Count();
            int Pending = _context.PendingJyotishRecords.Count();
            int Reject = _context.PendingJyotishRecords.Where(x => x.Status == "Rejected").Count();
            AdminDashboardViewModal model = new AdminDashboardViewModal() 
            {
                TotalUsers = Users,
                TotalJyotish = Jyotish,
                RejectedJyotish = Reject,
                PendingJyotish = Pending
            };

            if (model == null)
            {
                return null;
            }
            else
            {
                return model;
            }
        }

        public List<PoojaRecordModel> PoojaRecord()
        {
            var Records = _context.PoojaRecord.ToList();
            return Records;
        }
        public List<ChattingModel> ChattingRecord()
        {
            var Records = _context.ChatingRecords.ToList();
            return Records;
        }
        public List<CallingModel> CallingRecord()
        {
            var Records = _context.CallingRecords.ToList();
            return Records;
        }
        public AppointmentModel AppointmentDetails(int id)
        {
            AppointmentModel Record =  _context.AppointmentRecords.Where(x=>x.Id == id).FirstOrDefault();
            if (Record == null)
            { return null; }
            else { return Record; }
        }

        public bool UpdateAppointment(AppointmentModel model)
        {
           var isDetailsValid = _context.AppointmentRecords.Where(x => x.Id == model.Id).FirstOrDefault();
            if (isDetailsValid == null)
            { return false; }
            _context.AppointmentRecords.Update(model);
            var result = _context.SaveChanges();
            if (result > 0)
            { return true; }
            else
            { return false; }
        }

        public bool AddCountry(ModelAccessLayer.Models.Country _country)
        {
            var isCountryValid = _context.Countries.Where(x => x.Name == _country.Name);
            if (isCountryValid != null)
            { return false; }
            else
            {
                _context.Countries.Add(_country);
                var reuslt = _context.SaveChanges();
                if (reuslt != 0)
                { return true; }
                else
                { return false; }
            }
        }
        public bool AddState(ModelAccessLayer.Models.State _state)
        {
            var isStateValid = _context.States.Where(x => x.Name == _state.Name);
            var isCountryValid = _context.Countries.Where(x => x.Id == _state.CountryId);
            if (isStateValid != null && isCountryValid == null)
            { return false; }
            else
            {
                _context.States.Add(_state);
                var reuslt = _context.SaveChanges();
                if (reuslt != 0)
                { return true; }
                else
                { return false; }
            }
        }

        public bool AddCity(City _city) 
        {

            var isCityValid = _context.Cities.Where(x => x.Name == _city.Name);
            var isStateValid = _context.States.Where(x => x.Id == _city.StateId);
            if (isCityValid != null && isStateValid == null)
            { return false; }
            else
            {
                _context.Cities.Add(_city);
                var reuslt = _context.SaveChanges();
                if (reuslt != 0)
                { return true; }
                else
                { return false; }
            }
        }
    }
}
