using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestSystem.Models;
using TestSystem.Db;
namespace TestSystem.Controllers

{
    
    public class HomeController : Controller
    {         
        DataContext data { get; set; }   

        public HomeController(DataContext context)
        {
            data = context;
        }

        public IActionResult Index()
        {            
            return View();
        }
        public IActionResult HomeEntry()
        {
            return View();
        }
        public IActionResult HomeRegistration()
        {
            return View();
        }
        [HttpPost] 
        public IActionResult HomeEntry(string login, string password)
        {
            if (login == null ||  password == null)
            {
                ModelState.AddModelError("login", "Заполните все поля для ввода");               
                return View();
            }            
            if (data.Admins.FirstOrDefault(i => (i.AdminLogin == login)) != null)
            {
                Admin admin = data.Admins.FirstOrDefault(i =>  (i.AdminLogin == login));
                return RedirectToAction("Index","Admin",admin); 
            }
            if (data.Students.FirstOrDefault(i => (i.StudentLogin == login && i.StudentPassword == password)) != null)
            {                    
                Student student = data.Students.FirstOrDefault(i => (i.StudentLogin == login && i.StudentPassword == password));
                return RedirectToAction("Index","Student", student);
            }
            if (data.Teachers.FirstOrDefault(i => (i.TeacherLogin == login && i.TeacherPassword == password)) != null)
            {
                Teacher teacher = data.Teachers.FirstOrDefault(i => (i.TeacherLogin == login && i.TeacherPassword == password));

                return RedirectToAction("Index","Teacher",new{TeacherId = teacher.TeacherId});
            }                                
            ModelState.AddModelError("login", "Неверный логин или пароль. Попробуйте снова");               
            return View();                         
        } 
    }
}
