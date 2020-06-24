using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ece_Berker_Project.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="Parolayı Onayla")]
        [Compare("Password",ErrorMessage ="Parolalar eşleşmiyor.")]
        public string ConfirmPassword { get; set; }
        
       
       
    }
}
