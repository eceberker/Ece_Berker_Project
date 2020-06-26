using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ece_Berker_Project.Data;
using Ece_Berker_Project.Models;
using Ece_Berker_Project.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Ece_Berker_Project.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<YorumluoUser> userManager;
        private readonly ApplicationDbContext _context;
         
        public ProfileController(UserManager<YorumluoUser> userManager, ApplicationDbContext context)
        {
            _context = context;
        }
        public ProfileController(UserManager<YorumluoUser> userManager)
        {
            this.userManager = userManager;
            
        }
        
       

       
    }
}