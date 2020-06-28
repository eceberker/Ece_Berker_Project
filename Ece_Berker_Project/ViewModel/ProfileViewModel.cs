using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ece_Berker_Project.ViewModel
{
    public class ProfileViewModel
    {
        public string UserId { get; set; }
        public string UserCode { get; set; }
        public string Bio { get; set; }
        public string City { get; set; }
        public List<Models.Yorum> Yorumlar { get; set; }
    }
}
