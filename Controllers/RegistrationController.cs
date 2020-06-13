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
    public class RegistrationController: Controller
    {
        DataContext data { get; set; }      

        public RegistrationController(DataContext context)
        {
            data = context;
        }
        public IActionResult Index()
        {            
            return View();
        }
        
        [HttpGet]
        public IActionResult StudentRegistration()
        {
            Student free = new Student{
                StudentFirstName = "   ",
                StudentSecondName = "   ",
                StudentMiddleName = "   "
            };
            CourseFacultySubject model = new
            CourseFacultySubject{
                Courses = data.Courses,
                Faculties = data.Faculties,
                student = free
            };
            return View(model);
        }
        public IActionResult TeacherRegistration()
        {
            Teacher free = new Teacher{
                TeacherFirstName = "   ",
                TeacherSecondName = "   ",
                TeacherMiddleName = "   "
            };
            return View(free);
        }
        [HttpPost]
        public IActionResult StudentRegistration(Student newstudent)
        {
            if (data.Students.FirstOrDefault(i => i.StudentLogin == newstudent.StudentLogin) == null &&
                data.Teachers.FirstOrDefault(i => i.TeacherLogin == newstudent.StudentLogin) == null)     
            {
                data.Students.Add(newstudent);
                data.SaveChanges();       
                return View("Result");
            } else {
            ModelState.AddModelError("StudentLogin", "Пользоваетель с таким логином уже зарегистрирован");
            CourseFacultySubject model = new
            CourseFacultySubject{
                Courses = data.Courses,
                Faculties = data.Faculties,
                student = newstudent
            };
            return View(model); }
        }
        [HttpPost]
        public IActionResult TeacherRegistration(Teacher newteacher)
        {
            if (data.Teachers.FirstOrDefault(i => i.TeacherLogin == newteacher.TeacherLogin) == null &&
                data.Students.FirstOrDefault(i => i.StudentLogin == newteacher.TeacherLogin) == null)
            {
                data.Teachers.Add(newteacher);
                data.SaveChanges();
                return View("Result");
            } else {
                ModelState.AddModelError("TeacherLogin", "Пользователь с таким логином уже зарегистрирован");               
                return View(newteacher);
            }
        }
        public IActionResult Result()
        {
            return View();
        }
    }
}