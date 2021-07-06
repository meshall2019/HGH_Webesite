 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HGH_Webesite.Data;
using HGH_Webesite.Models;

namespace HGH_Webesite.Controllers
{
    public class NewsPageController : Controller
    {
        private readonly HGH_WebesiteContext _context;

        public NewsPageController(HGH_WebesiteContext context)
        {
            _context = context;
        }

        // GET: NewsPages
        public async Task<IActionResult> Index()
        {
            return View(await _context.NewsPage.ToListAsync());
        }

        // GET: NewsPages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsPage = await _context.NewsPage
                .FirstOrDefaultAsync(m => m.id == id);
            if (newsPage == null)
            {
                return NotFound();
            }

            return View(newsPage);
        }

        // GET: NewsPages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NewsPages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,img1,title")] NewsPage newsPage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newsPage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newsPage);
        }

        // GET: NewsPages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsPage = await _context.NewsPage.FindAsync(id);
            if (newsPage == null)
            {
                return NotFound();
            }
            return View(newsPage);
        }

        // POST: NewsPages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,img1,title")] NewsPage newsPage)
        {
            if (id != newsPage.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newsPage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsPageExists(newsPage.id))
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
            return View(newsPage);
        }

        // GET: NewsPages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsPage = await _context.NewsPage
                .FirstOrDefaultAsync(m => m.id == id);
            if (newsPage == null)
            {
                return NotFound();
            }

            return View(newsPage);
        }

        // POST: NewsPages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newsPage = await _context.NewsPage.FindAsync(id);
            _context.NewsPage.Remove(newsPage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsPageExists(int id)
        {
            return _context.NewsPage.Any(e => e.id == id);
        }
    }
}
