using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ece_Berker_Project.Data;
using Ece_Berker_Project.Data.Migrations;
using Ece_Berker_Project.Models;
using Ece_Berker_Project.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ece_Berker_Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<YorumluoUser> userManager;
        private readonly SignInManager<YorumluoUser> signInManager;
        private readonly ApplicationDbContext _context;
        public AccountController(UserManager<YorumluoUser> userManager,
            SignInManager<YorumluoUser> signInManager,
            ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _context = context;
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
        public IActionResult Manage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Manage(ProfileViewModel model,string Bio)
        {
            var user = await userManager.GetUserAsync(User);

            model.Bio = user.Bio;

            if (ModelState.IsValid)
            {
                _context.Update(Bio);
                await _context.SaveChangesAsync();
                return RedirectToAction("index","yorums");

            }

            return View(model);
        }


    }
}
