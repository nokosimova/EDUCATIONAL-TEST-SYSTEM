using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TestSystem.Models
{
    public class Subject{    
        public int SubjectId{get; set;}
        [Required(ErrorMessage = "Пожалуйста введите название предмета")]
        public string SubjectName{get; set;}
        public int IdCourse{get; set;}
        public int IdFaculty{get; set;}
        public virtual Faculty Faculty{get; set;}
        public virtual Course Course{get; set;}
        public virtual ICollection<Test> Tests{get; set;}        
    }

}