﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        private readonly UserManager<YorumluoUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IApplicationUser _userService;



        public ProfileController(UserManager<YorumluoUser> userManager,
            IApplicationUser userService, 
            ApplicationDbContext context)
        {

            _context = context;
            _userManager = userManager;
            _userService = userService;
        }

        //  public async Task<IActionResult> Index(int username)
        //{

        //  if (username == null)
        //{
        //  return NotFound();
        //}

        //  YorumluoUser user = await userManager.FindByIdAsync(username);

        //    YorumluoUser user = await userManager.GetUserAsync(User);
        //
        //    {
        //  return NotFound();
        //  }

        //return View(user);



        // }


        public IActionResult Details(string id)
        {
            YorumluoUser user = _userService.GetById(id);
            var model = new ProfileViewModel()
            {
                UserId = user.Id,
               UserCode = user.UserCode,
            
            };
            return View(model);

        }

    }
}