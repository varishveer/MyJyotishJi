using ModelAccessLayer.Models;
using ModelAccessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Abstraction
{
    public interface IJyotishServices
    {
        public List<AppointmentModel> Appointment(string JyotishEmail);
        public List<AppointmentModel> UpcomingAppointment(string JyotishEmail);
        public string AddAppointment(AppointmentViewModel appointment);
        public List<TeamMemberModel> TeamMember(int JyotishId);
        public string AddTeamMember(TeamMemberViewModel teamMember, string Path);
        public bool CreateAPooja(PoojaRecordModel model);
        
    }
}
