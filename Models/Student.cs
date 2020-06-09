using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TestSystem.Models
{
    public class Student{    
        public int StudentId{get; set;}
        [Required(ErrorMessage = "Пожалуйста введите фалимию!")]
        public string StudentFirstName{get; set;}
        [Required(ErrorMessage = "Пожалуйста введите имя!")]
        public string StudentSecondName{get; set;}
        [Required(ErrorMessage = "Пожалуйста введите отчество!")]
        public string StudentMiddleName{get; set;}
        public int IdCourse{get; set;}
        public int IdFaculty{get; set;}

        public virtual Course Course{get; set;}
        public virtual Faculty Faculty{get; set;}
        public virtual ICollection<AnsQuestion> AnsQuestions{get; set;}
    }

}