using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace TestSystem.Models
{
    public class Course{
        public int CourseId{get; set;}
        public string CourseName{get; set;}
        public virtual ICollection<Student> Students{get; set;}
        public virtual ICollection<Subject> Subjects{get; set;}
    
    }

}