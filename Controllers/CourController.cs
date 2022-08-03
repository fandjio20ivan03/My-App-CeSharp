using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcCour.Models;

namespace MyProject.Controllers
{
    public class CourController : Controller
    {
        private readonly MvcSchoolContext _context;

        public CourController(MvcSchoolContext context)
        {
            _context = context;
        }

        // GET: Cour
        public async Task<IActionResult> Index()
        {
              return _context.Cour != null ? 
                          View(await _context.Cour.ToListAsync()) :
                          Problem("Entity set 'MvcSchoolContext.Cour'  is null.");
        }

        // GET: Cour/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cour == null)
            {
                return NotFound();
            }

            var cour = await _context.Cour
                .FirstOrDefaultAsync(m => m.FiliereID == id);
            if (cour == null)
            {
                return NotFound();
            }

            return View(cour);
        }

        // GET: Cour/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cour/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourId,Name,description,FiliereID")] Cour cour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cour);
        }

        // GET: Cour/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cour == null)
            {
                return NotFound();
            }

            var cour = await _context.Cour.FindAsync(id);
            if (cour == null)
            {
                return NotFound();
            }
            return View(cour);
        }

        // POST: Cour/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourId,Name,description,FiliereID")] Cour cour)
        {
            if (id != cour.FiliereID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourExists(cour.FiliereID))
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
            return View(cour);
        }

        // GET: Cour/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cour == null)
            {
                return NotFound();
            }

            var cour = await _context.Cour
                .FirstOrDefaultAsync(m => m.FiliereID == id);
            if (cour == null)
            {
                return NotFound();
            }

            return View(cour);
        }

        // POST: Cour/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cour == null)
            {
                return Problem("Entity set 'MvcSchoolContext.Cour'  is null.");
            }
            var cour = await _context.Cour.FindAsync(id);
            if (cour != null)
            {
                _context.Cour.Remove(cour);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourExists(int id)
        {
          return (_context.Cour?.Any(e => e.FiliereID == id)).GetValueOrDefault();
        }
    }
}
