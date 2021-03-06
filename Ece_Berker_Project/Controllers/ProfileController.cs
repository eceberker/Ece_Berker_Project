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
        private readonly ILike _likeService;



        public ProfileController(UserManager<YorumluoUser> userManager,
            IApplicationUser userService, 
            ApplicationDbContext context, ILike likeService)
        {

            _context = context;
            _userManager = userManager;
            _userService = userService;
            _likeService = likeService;
        }

        public async Task<IActionResult> Details(string id)
        {
            

            
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            YorumluoUser user = _userService.GetById(id);
            var model = new ProfileViewModel()
            {
               
                User = user,
                
                
            };



            var loggeduser = await  _userManager.GetUserAsync(User);


            var userFollows =  _userService.GetFollows(loggeduser.Id);

            model.FollowerCount = _context.Follows.Where(y => y.FollowedId == user.Id).Count();
            model.FollowedCount = _context.Follows.Where(y => y.FollowerId == user.Id).Count();

            foreach (var users in userFollows)
            {


                if (userFollows.Any(u => u.FollowedId == user.Id))
                {
                    model.User.IsFollowed = true;
                }
                else
                {
                    model.User.IsFollowed = false;
                }

            }


            return View(model);

        }

    }
}