using ModelAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Abstraction
{
    public interface IAdminServices
    {
        public List<JyotishModel> GetAllJyotish();
        public List<PendingJyotishModel> GetAllPendingJyotish();
        public List<UserModel> GetAllUser();
        public List<TeamMemberModel> GetAllTeamMember();
        public List<AppointmentModel> GetAllAppointment();
        public bool ApproveJyotish(int JyotishId);
        public bool RejectJyotish(int JyotishId);
    }
}
