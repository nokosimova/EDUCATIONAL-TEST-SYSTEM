using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestSystem.Models;
using TestSystem.Db;

namespace Project.Controllers
{
    public class AdminController: Controller
    {
        DataContext data { get; set; }      

        public AdminController(DataContext context)
        {
            data = context;
        }
        [HttpGet]
        public IActionResult Index(Admin admin)
        {            
            return View();
        }
    }
}