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
        public virtual ICollection<Test> Tests{get; set;}
    }

}