using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestSystem.Models;

namespace TestSystem.Controllers
{
    public class HomeController : Controller
    {        

        public IActionResult Index()
        {            
            return View();
        }
        public IActionResult HomeEntry()
        {
            return View();
        }
        public IActionResult HomeRegistration()
        {
            return View();
        }


    }
}
