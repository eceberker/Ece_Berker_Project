using Ece_Berker_Project.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ece_Berker_Project.ViewComponents
{
    [ViewComponent(Name = "CategoryViewComponent")]
    public partial class CategoryViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext context;
        public CategoryViewComponent(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cats = await context.Categories.ToListAsync();
           
            
                return View(cats);
            

        }
    }
}
