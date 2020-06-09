using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TestSystem.Models
{
    public class AnsQuestion{
        public int AnsQuestionId{get; set;}
        public int IdQuestion{get; set;}

        [Required(ErrorMessage = "Пожалуйста выберите ответ!")]
        public int IdAnswer{get; set;}
        public int IdStudent{get; set;}
        public virtual Question Question {get; set;}
        public virtual Student Student {get; set;}    
        public virtual Answer Answer{get; set;}
    }
}