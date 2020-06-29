using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ece_Berker_Project.Data;
using Ece_Berker_Project.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ece_Berker_Project.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public SearchController( ApplicationDbContext context)
        {
            
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Search()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Search(SearchViewModel model)
        {
            var title = model.SearchText;
            var category = model.CategoryId;

            var yorum = _context.Yorums.AsQueryable().OrderByDescending(p => p.PostDate);

            if (!String.IsNullOrWhiteSpace(model.SearchText))
            {
                yorum = yorum.Where(y=>y.Title.Contains(model.SearchText)).OrderByDescending(p => p.PostDate);
            }
            if (model.CategoryId.HasValue)
            {
                yorum = yorum.Where(y => y.CategoryId == model.CategoryId.Value).OrderByDescending(p => p.PostDate);
            }
            if (!String.IsNullOrEmpty(model.Username))
            {
                yorum = yorum.Where(y => y.UserName.Contains(model.Username)).OrderByDescending(p => p.PostDate);
            }

            
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", model.CategoryId);
            model.Results = await yorum.ToListAsync();
            return View(model);
        }
    }
}
