using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ece_Berker_Project.Models
{
    public class YorumluoUser : IdentityUser
    {
        
        public string UserCode { get; set; }

        public DateTime BirthDay { get; set; }
        public string City { get; set; }
        public string Bio { get; set; }
        public string PhotoPath { get; set; }
        public virtual List<ProfileImage> ProfileImages { get; set; }
        public virtual List<Yorum> Yorums { get; set; }
        public List<UserLikes> LikedYorum { get; set; }

        public List<Follow> Followers { get; set; }
        public List<Follow> Follows { get; set; }

        [NotMapped]
        public bool IsFollowed { get; set; }


    }
}
