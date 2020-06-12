using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestSystem.Models;

namespace TestSystem.Db
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Course> Courses{get; set;}
        public DbSet<Faculty> Faculties{get; set;}
        public DbSet<Teacher> Teachers{get; set;}
        public DbSet<Subject> Subjects{get; set;}
        public DbSet<Student> Students{get; set;}
        public DbSet<Test> Tests{get; set;}
        public DbSet<Question> Questions{get; set;}
        public DbSet<Answer> Answers{get; set;}
        public DbSet<AnsQuestion> AnsQuestions{get; set;}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Course>().HasData(
                new Course{CourseId = 1, CourseName = "1"},
                new Course{CourseId = 2, CourseName = "2"},
                new Course{CourseId = 3, CourseName = "3"},
                new Course{CourseId = 4, CourseName = "4"});
            
            builder.Entity<Faculty>().HasData(
                new Faculty{FacultyId = 1, FacultyName = "ПМиИ"},
                new Faculty{FacultyId = 2, FacultyName = "ГМУ"});   
        }
    }
}