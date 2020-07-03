using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ece_Berker_Project.Models
{

    
    public class UserLikes
    {

        public string UserId { get; set; }
        public YorumluoUser LikeUsers { get; set; }
        public int YorumId { get; set; }
        public Yorum LikedYorums { get; set; }
    }

}

