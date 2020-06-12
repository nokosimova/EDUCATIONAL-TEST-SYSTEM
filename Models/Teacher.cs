using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestSystem.Models
{
    public class Teacher{    
        public int TeacherId{get; set;}

        [Required(ErrorMessage = "Пожалуйста введите фамилию")]
        public int TeacherFirstName{get; set;}

        [Required(ErrorMessage = "Пожалуйста введите имя")]
        public int TeacherSecondName{get; set;}
        
        [Required(ErrorMessage = "Пожалуйста введите отчество")]
        public int TeacherMiddleName{get; set;}
        
        [Required(ErrorMessage = "Пожалуйста ввелите логин")]
        public int TeacherLogin{get; set;}
        [Required(ErrorMessage = "Пожалуйста введите пароль")]
        public int TeacherPassword{get; set;}
        public virtual ICollection<Test> Tests{get; set;}
    }
}