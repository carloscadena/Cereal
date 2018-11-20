﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cereal.Controllers
{
    [Authorize(Policy = "EmailPolicy")]
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
