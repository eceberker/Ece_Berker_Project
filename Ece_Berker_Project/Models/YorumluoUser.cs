using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ece_Berker_Project.Models
{
    public class YorumluoUser : IdentityUser
    {
       
        public DateTime BirthDay { get; set; }
        public string City { get; set; }

    }
    public class YorumluoUserRole : IdentityRole<int>
    {
        public bool CanLikeYorum { get; set; }
        public bool CanEnterYorum { get; set; }
        public bool CanAnswerYorum { get; set; }
        public bool CanDeleteYorum { get; set; }

    }
}
