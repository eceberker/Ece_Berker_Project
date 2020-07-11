using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ece_Berker_Project.Models
{
    public class Follow
    {
        public string FollowerId { get; set; }
        public YorumluoUser Follower { get; set; }
        public string FollowedId { get; set; }
        public YorumluoUser Followed { get; set; }
    }
}
