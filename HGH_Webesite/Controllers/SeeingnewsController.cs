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
    public class SeeingnewsController : Controller
    {
        private readonly HGH_WebesiteContext _context;

        public SeeingnewsController(HGH_WebesiteContext context)
        {
            _context = context;
        }

        // GET: Seeingnews
        public async Task<IActionResult> Index()
        {
            return View(await _context.Seeingnews.ToListAsync());
        }

        // GET: Seeingnews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seeingnews = await _context.Seeingnews
                .FirstOrDefaultAsync(m => m.id == id);
            if (seeingnews == null)
            {
                return NotFound();
            }

            return View(seeingnews);
        }

        // GET: Seeingnews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Seeingnews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,img,title,content")] Seeingnews seeingnews)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seeingnews);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(seeingnews);
        }

        // GET: Seeingnews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seeingnews = await _context.Seeingnews.FindAsync(id);
            if (seeingnews == null)
            {
                return NotFound();
            }
            return View(seeingnews);
        }

        // POST: Seeingnews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,img,title,content")] Seeingnews seeingnews)
        {
            if (id != seeingnews.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seeingnews);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeeingnewsExists(seeingnews.id))
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
            return View(seeingnews);
        }

        // GET: Seeingnews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seeingnews = await _context.Seeingnews
                .FirstOrDefaultAsync(m => m.id == id);
            if (seeingnews == null)
            {
                return NotFound();
            }

            return View(seeingnews);
        }

        // POST: Seeingnews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seeingnews = await _context.Seeingnews.FindAsync(id);
            _context.Seeingnews.Remove(seeingnews);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeeingnewsExists(int id)
        {
            return _context.Seeingnews.Any(e => e.id == id);
        }
    }
}
