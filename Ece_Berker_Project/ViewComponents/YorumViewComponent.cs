using Ece_Berker_Project.Data;
using Ece_Berker_Project.Models;
using Ece_Berker_Project.ViewModel;
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
        private readonly IYorum _yorumService;
        public YorumViewComponent (ApplicationDbContext context, IApplicationUser userService, IYorum yorumService)
        {
            _context = context;
            _userService = userService;
            _yorumService = yorumService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)

        {

                var yors =  _yorumService.Profile(id);

                return View (yors);


        }
    }
}
