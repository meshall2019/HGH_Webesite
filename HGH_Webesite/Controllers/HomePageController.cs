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
    public class HomePageController : Controller
    {
        private readonly HGH_WebesiteContext _context;

        public HomePageController(HGH_WebesiteContext context)
        {
            _context = context;
        }

        // GET: HomePage
        public async Task<IActionResult> Index()
        {
            return View(await _context.HomePage.ToListAsync());
        }

        // GET: HomePage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homePage = await _context.HomePage
                .FirstOrDefaultAsync(m => m.id == id);
            if (homePage == null)
            {
                return NotFound();
            }

            return View(homePage);
        }

        // GET: HomePage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HomePage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,img1,name1,img2,name2,img3,name3,imgtitle,Tilte")] HomePage homePage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(homePage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(homePage);
        }

        // GET: HomePage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homePage = await _context.HomePage.FindAsync(id);
            if (homePage == null)
            {
                return NotFound();
            }
            return View(homePage);
        }

        // POST: HomePage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,img1,name1,img2,name2,img3,name3,imgtitle,Tilte")] HomePage homePage)
        {
            if (id != homePage.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(homePage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomePageExists(homePage.id))
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
            return View(homePage);
        }

        // GET: HomePage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homePage = await _context.HomePage
                .FirstOrDefaultAsync(m => m.id == id);
            if (homePage == null)
            {
                return NotFound();
            }

            return View(homePage);
        }

        // POST: HomePage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var homePage = await _context.HomePage.FindAsync(id);
            _context.HomePage.Remove(homePage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomePageExists(int id)
        {
            return _context.HomePage.Any(e => e.id == id);
        }
    }
}
