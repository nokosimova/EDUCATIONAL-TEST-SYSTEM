using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TestSystem.Models
{
    public class TestEditModel
    {
        public List<QuestionWithAns> qaList{get; set;}
        public Test test{get; set;}
        public Question question{get; set;}

    }
}