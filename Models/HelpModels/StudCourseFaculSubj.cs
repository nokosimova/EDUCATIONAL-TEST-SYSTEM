using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TestSystem.Models
{
    public class StudCourseFaculSubj
    {
        public List<Course> Courses{get; set;}
        public List<Faculty> Faculties{get; set;}
        public List<Subject> Subjects{get; set;}
        public List<Student> Students{get; set;}
        public Subject subject{get; set;}

    }
}