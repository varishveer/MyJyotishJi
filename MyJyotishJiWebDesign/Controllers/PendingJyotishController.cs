﻿using Microsoft.AspNetCore.Mvc;

namespace MyJyotishGWeb.Controllers
{
    public class PendingJyotishController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult Register() { return View(); }
        public IActionResult Login() { return View(); }
        public IActionResult Documents() { return View(); }
        public IActionResult UploadDocument() { return View(); }
        public IActionResult Profile() { return View(); }

    }
}
