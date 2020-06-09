using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TestSystem.Models
{
    public class Answer{    
        public int AnswerId{get; set;}
        [Required(ErrorMessage = "Пожалуйста введите ответ!")]
        public string AnswerText{get; set;}
        public int IdQuestion{get ;set;}
        public bool IsRightAnswer{get; set;}

        public virtual Question Question{get; set;}
        public virtual ICollection<AnsQuestion> AnsQuestions{get; set;}


    
    }

}
