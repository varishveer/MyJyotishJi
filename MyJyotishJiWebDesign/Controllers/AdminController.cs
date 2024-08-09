using BusinessAccessLayer.Abstraction;
using Microsoft.AspNetCore.Mvc;


namespace MyJyotishJiWebDesign.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAccountServices _account;
        public AdminController(IAccountServices account) 
        { 
            _account = account;
        }
        public IActionResult Login()
        { return View(); }
        [HttpPost]
        public IActionResult AdminLogin(string username, string password)
        { 
            var result =_account.SignInAdmin(username, password);
            if (result == "Login Successfull")
            {
                return Json(new { success = true, redirectUrl = Url.Action("Dashboard", "Admin") });
            }

            return Json(new { success = false, errorMessage = "Login failed. Please check your username and password." });
        }
        public IActionResult Dashboard() { return View();}
        public IActionResult JyotishList() { return View(); }
        public IActionResult UserList() { return View(); }
        public IActionResult Appointments() { return View(); }
        public IActionResult EditAppointment() { return View(); }
        public IActionResult PoojaList() { return View(); }
        public IActionResult ExpertiseList() { return View(); }
        public IActionResult AdminProfile() { return View(); }
        public IActionResult EditProfile() { return View(); }
        public IActionResult UpcommingAppointments() { return View(); }

        public IActionResult AddPooja() { return View(); }
        public IActionResult AddExpertise() { return View(); }
        public IActionResult JyotishDetails() { return View(); }
        public IActionResult UserDetails() { return View(); }
        public IActionResult EditUpcommingAppointment() { return View(); }



    }
}
