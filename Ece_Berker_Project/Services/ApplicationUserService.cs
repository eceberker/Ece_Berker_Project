using Ece_Berker_Project.Data;
using Ece_Berker_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ece_Berker_Project.Service
{
    public class ApplicationUserService : IApplicationUser
    {
        private readonly ApplicationDbContext _context;
        
        public ApplicationUserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Follow(Follow follow)
        {
            _context.Follows.Add(follow);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<YorumluoUser> GetAll()
        {
            return _context.Users;
        }
        public YorumluoUser GetById(string id)
        {
            return GetAll().FirstOrDefault(user => user.UserCode == id);
        }

        public IEnumerable<Follow> GetFollows(string id)
        {
            return _context.Follows.Where(y => y.FollowerId == id);
        }

        public async Task Like(UserLikes yorum)
        {

            _context.UserLikes.Add(yorum);
            await _context.SaveChangesAsync();
        }

        public async Task Unfollow(Follow follow)
        {
            _context.Follows.Remove(follow);
            await _context.SaveChangesAsync();
        }

        public async Task Unlike(UserLikes yorum)
        {
            _context.UserLikes.Remove(yorum);
            await _context.SaveChangesAsync();
        }

        public YorumluoUser Update(YorumluoUser updatedUser)
        {
           YorumluoUser user =  GetAll().FirstOrDefault(user => user.Id == updatedUser.Id);
            if (user != null)
            {
                user.Bio = updatedUser.Bio;
            }
            return user;
        }


        

    }
}
