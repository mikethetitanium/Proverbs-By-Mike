using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proverbs_By_Mike.Data;
using Proverbs_By_Mike.Models;

namespace Proverbs_By_Mike.Controllers
{
    public class proverbsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public proverbsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: proverbs
        public async Task<IActionResult> Index()
        {
            return View(await _context.proverb.ToListAsync());
        }

        // GET: proverbs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proverb = await _context.proverb
                .FirstOrDefaultAsync(m => m.id == id);
            if (proverb == null)
            {
                return NotFound();
            }

            return View(proverb);
        }

        // GET: proverbs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: proverbs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,proverbname,proverbdescription")] proverb proverb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proverb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proverb);
        }

        // GET: proverbs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proverb = await _context.proverb.FindAsync(id);
            if (proverb == null)
            {
                return NotFound();
            }
            return View(proverb);
        }

        // POST: proverbs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,proverbname,proverbdescription")] proverb proverb)
        {
            if (id != proverb.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proverb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!proverbExists(proverb.id))
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
            return View(proverb);
        }

        // GET: proverbs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proverb = await _context.proverb
                .FirstOrDefaultAsync(m => m.id == id);
            if (proverb == null)
            {
                return NotFound();
            }

            return View(proverb);
        }

        // POST: proverbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proverb = await _context.proverb.FindAsync(id);
            if (proverb != null)
            {
                _context.proverb.Remove(proverb);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool proverbExists(int id)
        {
            return _context.proverb.Any(e => e.id == id);
        }
    }
}
