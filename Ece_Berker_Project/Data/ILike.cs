using Ece_Berker_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ece_Berker_Project.Data
{
    public interface ILike
    {
        IEnumerable<UserLikes> GetAll();
        IEnumerable<UserLikes> GetUserLikes(string userId);
    }
}
