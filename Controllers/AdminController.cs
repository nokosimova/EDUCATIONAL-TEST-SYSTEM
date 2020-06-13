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
            return View(admin);
        }

        public IActionResult StudentList()
        {            
            return View(data.Students.ToList());
        }
        public IActionResult TeacherList()
        {
            return View(data.Teachers.ToList());
        }
        public IActionResult FacultyList()
        {
            return View(data.Faculties.ToList());
        }
        public IActionResult SubjectLIst()
        {
            return View(data.Subjects.ToList());
        }
        [HttpGet]
        public IActionResult DeleteTeacher(int id)
        {
            Teacher teacher = data.Teachers.FirstOrDefault(i => i.TeacherId == id); 
            data.Teachers.Remove(teacher);
            data.SaveChanges();
            return RedirectToAction("TeacherList", data.Teachers.ToList());            
        }
      //  [HttpGet]
        public IActionResult ChangeTeacher(int Id)
        {
            Teacher teacher = data.Teachers.Find(Id);
            if (teacher != null)
                return PartialView("ChangeTeacher",teacher);
            return RedirectToAction("TeacherList", data.Teachers.ToList());             
        }
        [HttpPost]
        public IActionResult ChangeTeacher(Teacher teacher)
        {
            if (data.Teachers.Find(teacher.TeacherId) != null)
            {            
                data.Teachers.Find(teacher.TeacherId).TeacherFirstName = teacher.TeacherFirstName;
                data.Teachers.Find(teacher.TeacherId).TeacherSecondName = teacher.TeacherSecondName;
                data.Teachers.Find(teacher.TeacherId).TeacherMiddleName = teacher.TeacherMiddleName;
                data.SaveChanges();
            }
            return RedirectToAction("TeacherList", data.Teachers.ToList());
        }



    }
}