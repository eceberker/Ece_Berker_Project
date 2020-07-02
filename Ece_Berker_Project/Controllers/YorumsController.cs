using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ece_Berker_Project.Data;
using Ece_Berker_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Ece_Berker_Project.ViewModel;
using Ece_Berker_Project.Services;

namespace Ece_Berker_Project.Controllers
{
    public class YorumsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<YorumluoUser> _userManager;
        private readonly IYorum _yorumService;
        public YorumsController(UserManager<YorumluoUser> userManager, 
            ApplicationDbContext context,
            IYorum yorumService)
        {
            _userManager = userManager;
            _context = context;
            _yorumService = yorumService;
        }

        // GET: Yorums
        public async Task<IActionResult> Index()
        {

            var yorum = _yorumService.GetAll();
            return View(yorum);

            /* ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
             var applicationDbContext = _context.Yorums.Include(y => y.Category).Include(u=>u.User).OrderByDescending(p=>p.PostDate);
             return View(await applicationDbContext.ToListAsync());*/
            
        }

        // GET: Yorums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yorum = await _context.Yorums
                .Include(y => y.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yorum == null)
            {
                return NotFound();
            }

            return View(yorum);
        }
        [Authorize]
        // GET: Yorums/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Yorums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,UserName,Likes,CategoryId,PostDate,User")] Yorum yorum)
        {
            Task<YorumluoUser> GetCurrentUserAsync() => _userManager.GetUserAsync(User);
            
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                Yorum yor = new Yorum
                {
                    UserName = user.UserCode,
                    CategoryId = yorum.CategoryId,
                    Title = yorum.Title,
                    PostDate = DateTime.Now,
                    User = user,
                };

                _context.Add(yor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", yorum.CategoryId);
            return View(yorum);
        }

        // GET: Yorums/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yorum = await _context.Yorums.FindAsync(id);
            if (yorum == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", yorum.CategoryId);
            return View(yorum);
        }

        // POST: Yorums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,UserName,Likes,CategoryId,PostDate")] Yorum yorum)
        {
            if (id != yorum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yorum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YorumExists(yorum.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", yorum.CategoryId);
            return View(yorum);
        }

        // GET: Yorums/Delete/5
        [Authorize]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yorum = await _context.Yorums
                .Include(y => y.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yorum == null)
            {
                return NotFound();
            }

            return View(yorum);
        }

        // POST: Yorums/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yorum = await _context.Yorums.FindAsync(id);
            _context.Yorums.Remove(yorum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YorumExists(int id)
        {
            return _context.Yorums.Any(e => e.Id == id);
        }
    }
}
