﻿using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
