﻿using Microsoft.AspNetCore.Mvc;

namespace ShowroomManagement.Controllers
{
    public class Department : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
