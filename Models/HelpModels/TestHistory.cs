using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TestSystem.Models
{
    public class TestHistory{   
        public Test test{get; set;}
        public Student student {get; set;}
        public int result{get; set;}    
    }

}