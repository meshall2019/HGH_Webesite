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
    public class Sections : Controller
    {
        private readonly HGH_WebesiteContext _context;

        public Sections(HGH_WebesiteContext context)
        {
            _context = context;
        }

        // GET: Sections
        public async Task<IActionResult> Index()
        {
            return View(await _context.NonModle.ToListAsync());
        }

        // GET: Sections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nonModle = await _context.NonModle
                .FirstOrDefaultAsync(m => m.id == id);
            if (nonModle == null)
            {
                return NotFound();
            }

            return View(nonModle);
        }

        // GET: Sections/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id")] NonModle nonModle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nonModle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nonModle);
        }

        // GET: Sections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nonModle = await _context.NonModle.FindAsync(id);
            if (nonModle == null)
            {
                return NotFound();
            }
            return View(nonModle);
        }

        // POST: Sections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id")] NonModle nonModle)
        {
            if (id != nonModle.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nonModle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NonModleExists(nonModle.id))
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
            return View(nonModle);
        }

        // GET: Sections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nonModle = await _context.NonModle
                .FirstOrDefaultAsync(m => m.id == id);
            if (nonModle == null)
            {
                return NotFound();
            }

            return View(nonModle);
        }

        // POST: Sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nonModle = await _context.NonModle.FindAsync(id);
            _context.NonModle.Remove(nonModle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NonModleExists(int id)
        {
            return _context.NonModle.Any(e => e.id == id);
        }
    }
}
