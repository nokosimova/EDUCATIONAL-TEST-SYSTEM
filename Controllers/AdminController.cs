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
            Course allCourse = new Course{CourseId = 0, CourseName = "Все"};
            Faculty allFaculty = new Faculty{FacultyId = 0, FacultyName = "Все"};
            List<Course> courses = data.Courses.ToList();
            List<Faculty> faculties = data.Faculties.ToList();
            courses.Insert(0, allCourse);
            faculties.Insert(0, allFaculty);
            StudCourseFaculSubj model = new
            StudCourseFaculSubj{
                Courses = courses,
                Faculties = faculties,
                Students = data.Students.ToList(),
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult StudentList(int Idcourse, int Idfaculty)
        {
            Course allCourse = new Course{CourseId = 0, CourseName = "Все"};
            Faculty allFaculty = new Faculty{FacultyId = 0, FacultyName = "Все"};
            List<Course> courses = data.Courses.ToList();
            List<Faculty> faculties = data.Faculties.ToList();
            courses.Insert(0, allCourse);
            faculties.Insert(0, allFaculty);
            
            StudCourseFaculSubj model = new StudCourseFaculSubj{Courses = courses, Faculties = faculties};
            if (Idcourse == 0)
                model.Students = data.Students.ToList();
            else
                model.Students = data.Students.Where(i => i.IdCourse == Idcourse).ToList();
            if (Idfaculty > 0)
                model.Students = model.Students.Where(i => i.IdFaculty == Idfaculty).ToList();
          
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
        //Методы для работы с данными таблицы факультетов
        public IActionResult FacultyList()
        {
            return View(data.Faculties.ToList());
        }
        public IActionResult DeleteFaculty(int Id)
        {
            if (ModelState.IsValid)
            {     
                
            }
            data.Faculties.Remove(data.Faculties.Find(Id));
            data.SaveChanges();
            return RedirectToAction("FacultyList",data.Faculties.ToList());
        }
        [HttpGet]
        public IActionResult ChangeFaculty(int Id)
        {
            Faculty faculty = data.Faculties.Find(Id);
            if (faculty != null)
                return View(faculty);
            return RedirectToAction("FacultyList",data.Faculties.ToList());
        }
        [HttpPost]
        public IActionResult ChangeFaculty(Faculty faculty)
        {
            if (data.Faculties.Find(faculty.FacultyId) != null)
            {
                data.Faculties.Find(faculty.FacultyId).FacultyName = faculty.FacultyName;
                data.SaveChanges();
            }
            return RedirectToAction("FacultyList",data.Faculties.ToList());
        }
        [HttpGet]
        public IActionResult AddFaculty(string facultyName)
        {            
            if (facultyName == null)
                return RedirectToAction("StudentList", data.Teachers.ToList());
            Faculty newFaculty = new Faculty{FacultyName = facultyName};
            data.Faculties.Add(newFaculty);
            data.SaveChanges();
            return RedirectToAction("FacultyList",data.Faculties.ToList());           
        }
        //Методы для работы с данными таблицы предметов
        
        public IActionResult SubjectList()
        {
            Course allCourse = new Course{CourseId = 0, CourseName = "Все"};
            Faculty allFaculty = new Faculty{FacultyId = 0, FacultyName = "Все"};
            List<Course> courses = data.Courses.ToList();
            List<Faculty> faculties = data.Faculties.ToList();
            courses.Insert(0, allCourse);
            faculties.Insert(0, allFaculty);
            StudCourseFaculSubj model = new StudCourseFaculSubj{
                Courses = courses,
                Faculties = faculties,
                Subjects = data.Subjects.ToList() };  
           return View(model);
        }
        [HttpPost]
        public IActionResult SubjectList(int Idcourse, int Idfaculty)
        {
            Course allCourse = new Course{CourseId = 0, CourseName = "Все"};
            Faculty allFaculty = new Faculty{FacultyId = 0, FacultyName = "Все"};
            List<Course> courses = data.Courses.ToList();
            List<Faculty> faculties = data.Faculties.ToList();
            courses.Insert(0, allCourse);
            faculties.Insert(0, allFaculty);
            
            StudCourseFaculSubj model = new StudCourseFaculSubj{Courses = courses, Faculties = faculties};
            if (Idcourse == 0)
                model.Subjects = data.Subjects.ToList();
            else
                model.Subjects = data.Subjects.Where(i => i.IdCourse == Idcourse).ToList();
            if (Idfaculty > 0)
                model.Subjects = model.Subjects.Where(i => i.IdFaculty == Idfaculty).ToList();
          
            return View(model);
        }
        public IActionResult AddSubject()
        {
            CourseFacultySubject model = new
                CourseFacultySubject{
                    Courses = data.Courses,
                    Faculties = data.Faculties,
                };
                return View(model);            
        }
        [HttpPost]
        public IActionResult AddSubject(Subject subject)
        {
            data.Subjects.Add(subject);
            data.SaveChanges();
            return RedirectToAction("SubjectList",new {Idcourse=subject.IdCourse,Idfaculty = subject.IdFaculty});
        }
        [HttpGet]
        public IActionResult ChangeSubject(int Id)
        {
            Subject subject = data.Subjects.Find(Id);
            if (subject != null)
            {
                CourseFacultySubject model = new
                CourseFacultySubject{
                    Courses = data.Courses,
                    Faculties = data.Faculties,
                    subject = subject                };
                return View(model);
            }
            return RedirectToAction("SubjectList",data.Subjects.ToList());
        }
        [HttpPost]
        public IActionResult ChangeSubject(Subject subject)
        {
            if (data.Subjects.Find(subject.SubjectId) != null)
            {
                data.Subjects.Find(subject.SubjectId).SubjectName = subject.SubjectName;
                data.Subjects.Find(subject.SubjectId).IdCourse = subject.IdCourse;
                data.Subjects.Find(subject.SubjectId).IdFaculty = subject.IdFaculty;
                data.SaveChanges();
            }
            return RedirectToAction("SubjectList",data.Faculties.ToList());
        }
/*        [HttpPost]
        public IActionResult SubjectList(Subject subject)
        {   
            Course allCourse = new Course{CourseId = 0, CourseName = "Все"};
            Faculty allFaculty = new Faculty{FacultyId = 0, FacultyName = "Все"};
            
            if (subject.SubjectName != null) 
            {
                data.Subjects.Add(subject);
                data.SaveChanges();            
            }         
            StudCourseFaculSubj model = new
                StudCourseFaculSubj{
                    Courses = data.Courses.ToList(),
                    Faculties = data.Faculties.ToList(),
                    Subjects = data.Subjects.Where(i => i.IdCourse == subject.IdCourse && i.IdFaculty == subject.IdFaculty).ToList()
                };
            model.Courses.ToList().Insert(0, allCourse);
            model.Faculties.ToList().Insert(0, allFaculty);
            return View(model);          
        }*/
        
        public IActionResult DeleteSubject(int Id)
        {
            Subject subject = data.Subjects.Find(Id);
            data.Subjects.Remove(subject);
            data.SaveChanges();
            subject.SubjectName = null;
            return RedirectToAction("SubjectList",new {Idcourse=subject.IdCourse,Idfaculty = subject.IdFaculty});
        }

    }
}