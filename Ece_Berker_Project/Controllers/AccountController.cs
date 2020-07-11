using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Ece_Berker_Project.Data;
using Ece_Berker_Project.Models;
using Ece_Berker_Project.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Ece_Berker_Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<YorumluoUser> userManager;
        private readonly SignInManager<YorumluoUser> signInManager;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly IApplicationUser _userService;


        public AccountController(UserManager<YorumluoUser> userManager,
            SignInManager<YorumluoUser> signInManager,
            ApplicationDbContext context,
            IWebHostEnvironment hostEnvironment,
            IApplicationUser userService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _context = context;
            this.hostEnvironment = hostEnvironment;
            _userService = userService;

        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Copy data from RegisterViewModel to IdentityUser
                var user = new YorumluoUser
                {
                    UserName = model.Email,
                    UserCode = model.UserCode,
                    City = model.City,
                    Email = model.Email
                };

                // Store user data in AspNetUsers database table
                var result = await userManager.CreateAsync(user, model.Password);

                // If user is successfully created, sign-in the user using
                // SignInManager and redirect to index action of HomeController
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "yorums");
                }

                // If there are any errors, add them to the ModelState object
                // which will be displayed by the validation summary tag helper
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }


         [HttpPost]
         public JsonResult CheckUsernameAvailability (string UserCode)
         {

             var SearchData = _context.YorumluoUsers.Where(x => x.UserCode == UserCode).SingleOrDefault();
             if (SearchData != null)
             {
                 return Json(1);
             }
             else
             {
                 return Json(0);
             }
         }
        



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                

                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                
                 

                if (result.Succeeded)
                {

                    return RedirectToAction("index", "yorums");
                }

                // If there are any errors, add them to the ModelState object
                // which will be displayed by the validation summary tag helper

                    ModelState.AddModelError(string.Empty, "Geçersiz kullanıcı adı ya da şifre.");
                
            }

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Manage(ProfileViewModel model)
        {
           // var user = await userManager.GetUserAsync(User);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Manage(ProfileViewModel model,string Bio)
        {


            if (ModelState.IsValid)
            {

                var user = await userManager.GetUserAsync(User);               
                user.Bio = model.Bio;
               user = _userService.Update(user);

                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Profile", new { @id = user.UserCode });

            }

            return View(model);
        }


        [HttpGet]
       public async Task<IActionResult> UploadImage()
        {
            var user = await userManager.GetUserAsync(User);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(ProfileViewModel model)
        {
            var user = await userManager.GetUserAsync(User);
            if (model.ImageFile != null)
            {
                string uniqueFileName = null;
                string uploadsFolder = Path.Combine(hostEnvironment.WebRootPath, "img");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                model.ImageFile.CopyTo(new FileStream(filePath, FileMode.Create));
                user.PhotoPath = uniqueFileName;


            }
            ProfileImage profileImage = new ProfileImage();

            profileImage.User = user;
            profileImage.FileName = user.PhotoPath;
            _context.ProfileImages.Add(profileImage);
            await _context.SaveChangesAsync();


            return RedirectToAction("Details", "Profile", new { @id = user.UserCode });
        }





        public async Task<IActionResult> Like(Yorum model)
        {

            var user = await userManager.GetUserAsync(User);

            UserLikes like = new UserLikes();

            like.YorumId = model.Id;
            like.UserId = user.Id;


           var SearchData = _context.UserLikes.AsNoTracking().Where(y => y.YorumId == model.Id && y.UserId == user.Id).SingleOrDefault();
            
            if (SearchData != null)
            {
                await _userService.Unlike(like);
               
            }
            else
            {
                await _userService.Like(like);
                
            }

            

            return RedirectToAction("Index","Yorums");

        }

        public async Task<IActionResult> Follow (YorumluoUser followed)
        {
            var user = await userManager.GetUserAsync(User);

            Follow follow = new Follow();
            follow.FollowerId = user.Id;
            follow.FollowedId = followed.Id;

            var check = _context.Follows.AsNoTracking().Where(y => y.FollowerId == follow.FollowerId && y.FollowedId == follow.FollowedId).SingleOrDefault();

            if (check != null)
            {
                await _userService.Unfollow(follow);
            }
            else
            {
                await _userService.Follow(follow);
            }
            

            return RedirectToAction("Index", "Yorums");
        }


    }
}
