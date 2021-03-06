using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TestSystem.Models
{
    public class CourseFacultySubject
    {
        public IEnumerable<Course> Courses{get; set;}
        public IEnumerable<Faculty> Faculties{get; set;}
        public IEnumerable<Subject> Subjects{get; set;}
        public IEnumerable<Test> Tests{get; set;}
        public Student student{get; set;}
        public Subject subject{get; set;}
        public Teacher teacher{get; set;}
        public Test test{get; set;}

    }
}