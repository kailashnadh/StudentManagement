﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Controllers
{
    public class AccountController:Controller
    {
        public IActionResult Register()
        {
            return View(); 
        }
    }
}
