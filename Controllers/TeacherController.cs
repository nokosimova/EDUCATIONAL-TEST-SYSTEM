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

        //создание нового теста
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
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", new{error = "Что-то пошло не так"});
            }
            if (data.Tests.FirstOrDefault(i => i.TestName == test.TestName) != null)
            {
                ModelState.AddModelError("TestName", "Тест с таким названием уже есть. Выберите другое!");               
                Subject subj = data.Subjects.Find(test.IdSubject);
                CourseFacultySubject newmodel = new
                CourseFacultySubject{
                    Subjects = data.Subjects.Where(i=> i.IdCourse == subj.IdCourse && i.IdFaculty==subj.IdFaculty),
                    test = new Test{
                        IdTeacher = test.IdTeacher
                    }
                };
                return View(newmodel);
            }
            data.Tests.Add(test);
            data.SaveChanges();
            return RedirectToAction("SuccesMessage", new{TeacherId = test.IdTeacher}); 
        }
        public IActionResult SuccesMessage(int TeacherId)
        {
            return View(data.Teachers.Find(TeacherId));
        }
        //редактирование тестов, добавление, изменение, удаление вопросов
        public IActionResult TestList(int TeacherId)
        {
            if (TeacherId != 1) return RedirectToAction("Error", new{error = "NO ID"});
            Course allCourse = new Course{CourseId = 0, CourseName = "Все курсы"};
            Faculty allFaculty = new Faculty{FacultyId = 0, FacultyName = "Все факультеты"};
            List<Course> courses = data.Courses.ToList();
            List<Faculty> faculties = data.Faculties.ToList();
            courses.Insert(0, allCourse);
            faculties.Insert(0, allFaculty);
            
           TestHelperModel model = new TestHelperModel{
                Courses = courses, 
                Faculties = faculties,
                teacher = new Teacher{TeacherId = TeacherId}  };
                model.Subjects = data.Subjects.ToList();
                model.Tests = data.Tests.Where(i => i.IdTeacher == TeacherId)
                                        .OrderBy(i => i.IdSubject).ToList();
                return View(model);
        }
        [HttpPost]
        public IActionResult TestList(int Idcourse, int Idfaculty, int Idteacher)
        {
            if (Idteacher != 1) return RedirectToAction("Error", new{error = "NO ID"});
            Course allCourse = new Course{CourseId = 0, CourseName = "Все курсы"};
            Faculty allFaculty = new Faculty{FacultyId = 0, FacultyName = "Все факультеты"};
            List<Course> courses = data.Courses.ToList();
            List<Faculty> faculties = data.Faculties.ToList();
            courses.Insert(0, allCourse);
            faculties.Insert(0, allFaculty);
            
           TestHelperModel model = new TestHelperModel{
               Courses = courses, 
               Faculties = faculties,
               teacher = new Teacher{TeacherId = Idteacher}  };
            if (Idcourse == 0)
            {
                model.Subjects = data.Subjects.ToList();
                model.Tests = data.Tests.Where(i => i.IdTeacher == Idteacher)
                                        .OrderBy(i => i.IdSubject).ToList();
            }
            else
            {
                model.Subjects = data.Subjects.Where(i => i.IdCourse == Idcourse).ToList();
                model.Tests = data.Tests.Where(i => data.Subjects.Find(i.IdSubject).IdCourse == Idcourse)
                                        .OrderBy(i => i.IdSubject).ToList();
            }
            if (Idfaculty > 0)
            {
                model.Subjects = model.Subjects.Where(i => i.IdFaculty == Idfaculty).ToList();
                model.Tests = model.Tests.Where(i => data.Subjects.Find(i.IdSubject).IdFaculty == Idfaculty)
                                        .OrderBy(i => i.IdSubject).ToList();
            }
            return View(model);
        }
        public string Error(string error)
        {
            return $"ERROR MESSAGE:{error} ";
        }
    }
}