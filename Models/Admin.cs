using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestSystem.Models
{
    public class Admin{    
        public int AdminId{get; set;}

        [Required(ErrorMessage = "Пожалуйста ввелите логин")]
        public string AdminLogin{get; set;}

        [Required(ErrorMessage = "Пожалуйста введите пароль")]
        public string AdminPassword{get; set;}
    }
}