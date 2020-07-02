using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ece_Berker_Project.Data;
using Ece_Berker_Project.Models;
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
        private readonly IYorum _yorumService;
        
        public SearchController( ApplicationDbContext context, IYorum yorumService)
        {
            
            _context = context;
            _yorumService = yorumService;
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

            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", model.CategoryId);

                SearchViewModel results = new SearchViewModel
                {
                    Results =  _yorumService.Search(model?.SearchText, model?.CategoryId, model?.Username).ToList(),
                };

                return  View(results);

        }

    }
}
