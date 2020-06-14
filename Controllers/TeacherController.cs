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
    public class TeacherController: Controller
    {
        DataContext data { get; set; }      

        public TeacherController(DataContext context)
        {
            data = context;
        }
        [HttpGet]
        public IActionResult Index(Teacher teacher)
        {            
            return View(teacher);
        }
        public IActionResult CreateTest(int TeacherId)
        {
            return View();
        }
        public IActionResult TestList()
        {
            return View();
        }
    }
}