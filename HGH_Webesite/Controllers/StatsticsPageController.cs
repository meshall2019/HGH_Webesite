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
    public class StatsticsPageController : Controller
    {
        private readonly HGH_WebesiteContext _context;

        public StatsticsPageController(HGH_WebesiteContext context)
        {
            _context = context;
        }

        // GET: StatsticsPage
        public async Task<IActionResult> Index()
        {
            return View(await _context.StatisticsPage.ToListAsync());
        }

        // GET: StatsticsPage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statsticsPage = await _context.StatisticsPage
                .FirstOrDefaultAsync(m => m.id == id);
            if (statsticsPage == null)
            {
                return NotFound();
            }

            return View(statsticsPage);
        }

        // GET: StatsticsPage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatsticsPage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,ER,OPD,OR,rays,BRITH,LAB")] StatsticsPage statsticsPage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statsticsPage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statsticsPage);
        }

        // GET: StatsticsPage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statsticsPage = await _context.StatisticsPage.FindAsync(id);
            if (statsticsPage == null)
            {
                return NotFound();
            }
            return View(statsticsPage);
        }

        // POST: StatsticsPage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,ER,OPD,OR,rays,BRITH,LAB")] StatsticsPage statsticsPage)
        {
            if (id != statsticsPage.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statsticsPage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatsticsPageExists(statsticsPage.id))
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
            return View(statsticsPage);
        }

        // GET: StatsticsPage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statsticsPage = await _context.StatisticsPage
                .FirstOrDefaultAsync(m => m.id == id);
            if (statsticsPage == null)
            {
                return NotFound();
            }

            return View(statsticsPage);
        }

        // POST: StatsticsPage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statsticsPage = await _context.StatisticsPage.FindAsync(id);
            _context.StatisticsPage.Remove(statsticsPage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatsticsPageExists(int id)
        {
            return _context.StatisticsPage.Any(e => e.id == id);
        }
    }
}
