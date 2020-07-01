using Ece_Berker_Project.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ece_Berker_Project.ViewModel
{
    public class ProfileViewModel
    {
        public YorumluoUser User { get; set; }
        public string UserId { get; set; }
        public string UserCode { get; set; }
        public string Bio { get; set; }
        public string City { get; set; }
        public IFormFile ImageFile { get; set; }
        public string PhotoPath { get; set; }
        public Yorum Yorumlar { get; set; }
    }
}
