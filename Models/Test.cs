using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TestSystem.Models
{
    public class Test{    
        public int TestId{get; set;}
        [Required(ErrorMessage = "Пожалуйста введите название теста!")]
        public string TestName{get; set;}
        public int IdSubject{get; set;}
        public int IdTeacher{get; set;}
        public virtual Subject Subject{get; set;}
        public virtual Teacher Teacher{get; set;}
        public virtual ICollection<Question> Questions{get; set;}
    }

}