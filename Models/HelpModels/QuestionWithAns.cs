using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestSystem.Models;
namespace TestSystem.Models
{
    public class QuestionWithAns
    {
        public Question question{get; set;}
        public Answer corrAns{get; set;}
        public Answer wrgAns1{get; set;}
        public Answer wrgAns2{get; set;}
        public Answer wrgAns3{get; set;}
        public int studAnsId{get; set;}
        public Test test{get; set;}

    }
}