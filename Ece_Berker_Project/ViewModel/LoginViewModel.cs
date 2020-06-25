﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ece_Berker_Project.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "E-Mail:")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Şifre:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}