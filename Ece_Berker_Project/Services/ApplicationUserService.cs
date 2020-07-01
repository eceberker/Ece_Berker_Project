using Ece_Berker_Project.Data;
using Ece_Berker_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Ece_Berker_Project.Service
{
    public class ApplicationUserService : IApplicationUser
    {
        private readonly ApplicationDbContext _context;
        
        public ApplicationUserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<YorumluoUser> GetAll()
        {
            return _context.Users;
        }
        public YorumluoUser GetById(string id)
        {
            return GetAll().FirstOrDefault(user => user.UserCode == id);
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
