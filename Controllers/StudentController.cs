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
            Subject allSubject = new Subject{SubjectId = 0, SubjectName = "Все предметы"};
            Student studet = data.Students.Find(StudentId);
            List<Subject> subjects = data.Subjects.Where(i => i.IdCourse == studet.IdCourse
                                                         && i.IdFaculty ==studet.IdFaculty).ToList();
            subjects.Insert(0, allSubject);
            if (studet == null) return RedirectToAction("Error", new{error = "Что-то пошло не так"});
            CourseFacultySubject model = new CourseFacultySubject{
                Subjects = subjects,
                student = studet,
                Tests = data.Tests//.Where(i => data.Courses.Find(i.IdSubject).CourseId == studet.IdCourse).ToList()
                                  //            && data.Subjects.Find(i.IdSubject).IdFaculty ==student.IdFaculty)
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
    // методы для прохождения тестов
    public IActionResult StartTestPage(int? TestId, int? StudentId)
    {
        Test test = data.Tests.Find(TestId);
        Student student = data.Students.Find(StudentId);
        if (test == null) 
            return RedirectToAction("Error", new{error = "ТЕСТ не найден!"});
        TakeTestHelper model = new TakeTestHelper{
            student = student,
            test = test,
            QuestionAmmount = data.Questions.Where(i => i.IdTest == test.TestId).Count(),
            ResultPoint = data.Questions.Where(i => i.IdTest == test.TestId).Sum(i => i.Point)
        };
        return View(model);
    }

    }
}