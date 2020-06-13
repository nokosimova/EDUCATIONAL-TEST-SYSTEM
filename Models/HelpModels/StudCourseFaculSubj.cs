using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TestSystem.Models
{
    public class StudCourseFaculSubj
    {
        public IEnumerable<Course> Courses{get; set;}
        public IEnumerable<Faculty> Faculties{get; set;}
        public IEnumerable<Subject> Subjects{get; set;}
        public IEnumerable<Student> Students{get; set;}

    }
}