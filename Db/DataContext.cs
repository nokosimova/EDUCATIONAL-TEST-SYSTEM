using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestSystem.Models;

namespace OnlineShop.Db
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
    }
}