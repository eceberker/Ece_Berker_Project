using Ece_Berker_Project.Models;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ece_Berker_Project.Data
{
    public interface IApplicationUser
    {
        YorumluoUser GetById(string id);
        IEnumerable<YorumluoUser> GetAll();
        YorumluoUser Update(YorumluoUser updatedUser);

        IEnumerable<Follow> GetFollows(string id);



        Task Like(UserLikes yorum);

        Task Unlike(UserLikes yorum);

        Task Follow(Follow follow);
        Task Unfollow(Follow follow);
      
            
    }
}
