using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TestSystem.Models
{
    public class TakeTestHelper
    {
        public QuestionWithAns QuestWithAns{get; set;}
        public Test test{get; set;}
        public Student student{get; set;}
        public int QuestionOrder{get; set;}
        public int QuestionAmmount{get; set;}
        public int ResultPoint{get; set;}
    }
}