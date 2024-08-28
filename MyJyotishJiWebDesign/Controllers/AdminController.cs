﻿
using Microsoft.AspNetCore.Mvc;


namespace MyJyotishJiWebDesign.Controllers
{
    public class AdminController : Controller
    {
       
        public IActionResult Login()
        { return View(); }
       
        public IActionResult AdminLogin()
        { return View(); }
        public IActionResult Dashboard() { return View();}
        public IActionResult JyotishList() { return View(); }
        public IActionResult UserList() { return View(); }
        public IActionResult Appointments() { return View(); }
        public IActionResult EditAppointment() { return View(); }
        public IActionResult PoojaCategoryList() { return View(); }
        public IActionResult ExpertiseList() { return View(); }
        public IActionResult AdminProfile() { return View(); }
        public IActionResult EditProfile() { return View(); }
        public IActionResult PendingJyotish() { return View(); }

        public IActionResult AddPoojaCategory() { return View(); }
        public IActionResult AddExpertise() { return View(); }
        public IActionResult JyotishDetails() { return View(); }
        public IActionResult UserDetails() { return View(); }
        public IActionResult EditUpcommingAppointment() { return View(); }
        public IActionResult PoojaRecord() {  return View(); }
        public IActionResult ChattingRecord() { return View(); }
        public IActionResult CallingRecord() { return View(); }
        public IActionResult AppointmentDetail() { return View(); }
        public IActionResult UpdateAppointment() { return View(); }



    }
}
