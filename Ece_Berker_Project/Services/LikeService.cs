using Ece_Berker_Project.Data;
using Ece_Berker_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ece_Berker_Project.Services
{
    public class LikeService : ILike
    {

        private readonly ApplicationDbContext _context;

        public LikeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<UserLikes> GetAll()
        {
            return _context.UserLikes;
        }

        public IEnumerable<UserLikes> GetUserLikes(string userId)
        {
            return GetAll().Where(y => y.UserId == userId).OrderByDescending(p => p.LikedYorums.PostDate); 
        }
    }
}
