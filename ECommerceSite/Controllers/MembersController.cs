﻿using Microsoft.AspNetCore.Mvc;

namespace ECommerceSite.Controllers
{
    public class MembersController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
