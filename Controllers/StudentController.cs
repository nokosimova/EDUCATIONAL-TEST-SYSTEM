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
    public class StudentController: Controller
    {
        DataContext data { get; set; }      

        public StudentController(DataContext context)
        {
            data = context;
        }
        [HttpGet]
        public IActionResult Index(int? StudentId)
        {          
            if (data.Students.Find(StudentId) != null) 
                return View(data.Students.Find(StudentId));
            return RedirectToAction("Error", new{error = "Пользователь не найден"});
        }
        public IActionResult TestList(int? StudentId)
        {
            Student student = data.Students.Find(StudentId);
            if (student == null) return RedirectToAction("Error", new{error = "Что-то пошло не так"});
            CourseFacultySubject model = new CourseFacultySubject{
                Subjects = data.Subjects.Where(i => i.IdCourse == student.IdCourse 
                                               && i.IdFaculty == student.IdFaculty),
                student = student,
                Tests = data.Tests.Where(i => data.Subjects.Find(i.IdSubject).IdCourse == student.IdCourse
                                              & data.Subjects.Find(i.IdSubject).IdFaculty ==student.IdFaculty)
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult TestList(int? StudentId, int? SubjectId)
        {
            Student student = data.Students.Find(StudentId);
            if (student == null) return RedirectToAction("Error", new{error = "Что-то пошло не так"});
            CourseFacultySubject model = new CourseFacultySubject{
                Subjects = data.Subjects.Where(i => i.IdCourse == student.IdCourse 
                                               && i.IdFaculty == student.IdFaculty),
                student = student,
                Tests = data.Tests.Where(i => i.IdSubject == SubjectId)};
            return View(model);
        }

    }
}