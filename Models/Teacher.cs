using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestSystem.Models
{
    public class Teacher{    
        public int TeacherId{get; set;}

        [Required(ErrorMessage = "Пожалуйста введите фамилию")]
        public string TeacherFirstName{get; set;}

        [Required(ErrorMessage = "Пожалуйста введите имя")]
        public string TeacherSecondName{get; set;}
        
        [Required(ErrorMessage = "Пожалуйста введите отчество")]
        public string TeacherMiddleName{get; set;}
        
        [Required(ErrorMessage = "Пожалуйста ввелите логин")]
        public string TeacherLogin{get; set;}
        [Required(ErrorMessage = "Пожалуйста введите пароль")]
        public string TeacherPassword{get; set;}
        public virtual ICollection<Test> Tests{get; set;}
    }
}