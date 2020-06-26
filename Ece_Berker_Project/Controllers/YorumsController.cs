using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ece_Berker_Project.Data;
using Ece_Berker_Project.Models;
using Microsoft.AspNetCore.Identity;

namespace Ece_Berker_Project.Controllers
{
    public class YorumsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<YorumluoUser> _userManager;
        public YorumsController(UserManager<YorumluoUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: Yorums
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Yorums.Include(y => y.Category);
            return View(await applicationDbContext.ToListAsync());
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,UserName,Likes,CategoryId,PostDate")] Yorum yorum)
        {
            Task<YorumluoUser> GetCurrentUserAsync() => _userManager.GetUserAsync(User);

            var user = await GetCurrentUserAsync();

          
            yorum.UserName = user.UserCode;
            yorum.PostDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(yorum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", yorum.CategoryId);
            return View(yorum);
        }

        // GET: Yorums/Edit/5
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
