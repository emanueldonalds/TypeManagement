﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Novia.TypeManagement.Presentation.Web.Controllers
{
    public class TypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}