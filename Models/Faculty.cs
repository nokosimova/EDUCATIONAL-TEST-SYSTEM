using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TestSystem.Models
{
    public class Faculty
    {
        public int FacultyId{get; set;}
        [Required(ErrorMessage = "Пожалуйста введите название факультета!")]
        public string FacultyName{get; set;}
        public virtual ICollection<Student> Students{get; set;}
        public virtual ICollection<Subject> Subjects{get; set;}    
    }

}