using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TestSystem.Models
{
    public class History{   
        public Teacher teacher{get; set;}
        public List<TestHistory> historylist{get; set;}

    }

}