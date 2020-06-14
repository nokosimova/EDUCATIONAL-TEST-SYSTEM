using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestSystem.Models;
using TestSystem.Db;
using TestSystem.Controllers;


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
        public IActionResult Index(int TeacherId)
        {  
            if (data.Teachers.Find(TeacherId) != null) 
                return View(data.Teachers.Find(TeacherId));
            return RedirectToAction("Error", new{error = "Пользователь не найден"});
        }
        [HttpGet]
        public IActionResult CreateTest(int TeacherId)
        {

            if (TeacherId > 0)
            {
            CourseFacultySubject model = new
                CourseFacultySubject{
                    Courses = data.Courses,
                    Faculties = data.Faculties,
                    test = new Test{IdTeacher = TeacherId}
                };
               return View(model);
            }
            return RedirectToAction("Error", new{error = "Id не передалось"});
        }
        
        public IActionResult ChooseSubj(int TeacherId, int CourseId, int FacultyId)
        {        
            CourseFacultySubject newmodel = new
                CourseFacultySubject{
                    Subjects = data.Subjects.Where(i=> i.IdFaculty==FacultyId && i.IdCourse==CourseId),
                    test = new Test{
                        IdTeacher = TeacherId
                    }
                };
            return View(newmodel);
        }
     
        [HttpPost]
        public IActionResult ChooseSubj(Test test)
        {
            if (ModelState.IsValid)
            {
                data.Tests.Add(test);
                data.SaveChanges();
                return RedirectToAction("Error", new{error = "Тест добавлен"}); 
            }
            return RedirectToAction("Error", new{error = "Что-то пошло не так"});
        }
        public IActionResult TestList()
        {
            return View();
        }
        public string Error(string error)
        {
            return $"ERROR MESSAGE:{error} ";
        }
    }
}