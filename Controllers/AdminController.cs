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
        public IActionResult FacultyList()
        {
            return View(data.Faculties.ToList());
        }
        public IActionResult SubjectLIst()
        {
            return View(data.Subjects.ToList());
        }
        //Методы для работы с данными таблицы преподавателей
        public IActionResult TeacherList()
        {
            return View(data.Teachers.ToList());
        }
        [HttpGet]
        public IActionResult DeleteTeacher(int id)
        {
            Teacher teacher = data.Teachers.FirstOrDefault(i => i.TeacherId == id); 
            data.Teachers.Remove(teacher);
            data.SaveChanges();
            return RedirectToAction("TeacherList", data.Teachers.ToList());            
        }
        public IActionResult ChangeTeacher(int Id)
        {
            Teacher teacher = data.Teachers.Find(Id);
            if (teacher != null)
                return View("ChangeTeacher",teacher);
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
        //Методы для работы с данными таблицы студентов
        public IActionResult StudentList()
        {   
            StudCourseFaculSubj model = new
            StudCourseFaculSubj{
                Courses = data.Courses,
                Students = data.Students,
                Faculties = data.Faculties,
                Subjects = data.Subjects
            };
            return View(model);
        }
        public IActionResult ChangeStudent(int Id)
        {
            Student student = data.Students.Find(Id);
            if (student != null)
            {
                CourseFacultySubject model = new
                CourseFacultySubject{
                    Courses = data.Courses,
                    Faculties = data.Faculties,
                    student = student
                };
                return View(model);
            }
            return RedirectToAction("StudentList", data.Students.ToList());
        }            
        [HttpPost]
        public IActionResult ChangeStudent(Student student)
        {
            if (data.Students.Find(student.StudentId) != null)
            {
                data.Students.Find(student.StudentId).StudentFirstName = student.StudentFirstName;
                data.Students.Find(student.StudentId).StudentSecondName = student.StudentSecondName;
                data.Students.Find(student.StudentId).StudentMiddleName = student.StudentMiddleName;
                data.Students.Find(student.StudentId).IdCourse = student.IdCourse;
                data.Students.Find(student.StudentId).IdFaculty = student.IdFaculty;
                data.SaveChanges();
            }
            return RedirectToAction("StudentList", data.Students.ToList());
        }
        [HttpGet]
        public IActionResult DeleteStudent(int Id)
        {
            Student student = data.Students.Find(Id);
            data.Students.Remove(student);
            data.SaveChanges();
            return RedirectToAction("StudentList", data.Teachers.ToList());            
        }
        //Методы для работы с данными таблицы предметов
        //Методы для работы с данными таблицы факультетов

    }
}