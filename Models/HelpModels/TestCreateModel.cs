using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TestSystem.Models
{
    public class TestCreateModel
    {
        public IEnumerable<Course> Courses{get; set;}
        public IEnumerable<Faculty> Faculties{get; set;}
        public IEnumerable<Subject> Subjects{get; set;}
        public IEnumerable<Test> Tests{get; set;}
        public Test test{get; set;}
        public Teacher teacher{get; set;}
        public Student student{get; set;}
    }
}