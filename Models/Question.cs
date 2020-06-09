using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TestSystem.Models
{
    public class Question{   
        public int QuestionId{get; set;} 
        [Required(ErrorMessage = "Пожалуйста введите вопрос!")]
        public string QuestionText{get; set;}                
        [Required(ErrorMessage = "Пожалуйста введите балл за вопрос!")]
        public int Point{get; set;}
        public int IdTest{get; set;}
        public virtual Test Test{get; set;}
        public virtual ICollection<AnsQuestion> AnsQuestions{get; set;}
        public virtual ICollection<Answer> Answers{get; set;}


    }

}