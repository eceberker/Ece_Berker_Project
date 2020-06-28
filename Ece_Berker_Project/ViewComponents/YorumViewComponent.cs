using Ece_Berker_Project.Data;
using Ece_Berker_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ece_Berker_Project.ViewComponents
{
    [ViewComponent(Name = "YorumViewComponent")]
    public partial class YorumViewComponent : ViewComponent
    {
       
        private readonly ApplicationDbContext _context;
        private readonly IApplicationUser _userService;
        public YorumViewComponent (ApplicationDbContext context, IApplicationUser userService)
        {
            _context = context;
            _userService = userService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            YorumluoUser user = _userService.GetById(id);
            var yors = await _context.Yorums.Where(y=>y.UserName == user.UserCode).Include(y=>y.Category).OrderByDescending(p => p.PostDate).ToListAsync();
            return View(yors);
        }
    }
}
