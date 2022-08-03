using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcFiliere.Models;

namespace MyProject.Controllers
{
    public class FiliereController : Controller
    {
        private readonly MvcSchoolContext _context;
 
        public FiliereController(MvcSchoolContext context)
        {
            _context = context;
        }

        // GET: Filiere
        public async Task<IActionResult> Index()
        {
              return _context.Filiere != null ? 
                          View(await _context.Filiere.ToListAsync()) :
                          Problem("Entity set 'MvcSchoolContext.Filiere'  is null.");
        }

        // GET: Filiere/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Filiere == null)
            {
                return NotFound();
            }

            var filiere = await _context.Filiere
                .FirstOrDefaultAsync(m => m.FiliereId == id);
            if (filiere == null)
            {
                return NotFound();
            }

            return View(filiere);
        }

        // GET: Filiere/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Filiere/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FiliereId,Name,description")] Filiere filiere)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filiere);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filiere);
        }

        // GET: Filiere/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Filiere == null)
            {
                return NotFound();
            }

            var filiere = await _context.Filiere.FindAsync(id);
            if (filiere == null)
            {
                return NotFound();
            }
            return View(filiere);
        }

        // POST: Filiere/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FiliereId,Name,description")] Filiere filiere)
        {
            if (id != filiere.FiliereId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filiere);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FiliereExists(filiere.FiliereId))
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
            return View(filiere);
        }

        // GET: Filiere/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Filiere == null)
            {
                return NotFound();
            }

            var filiere = await _context.Filiere
                .FirstOrDefaultAsync(m => m.FiliereId == id);
            if (filiere == null)
            {
                return NotFound();
            }

            return View(filiere);
        }

        // POST: Filiere/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Filiere == null)
            {
                return Problem("Entity set 'MvcSchoolContext.Filiere'  is null.");
            }
            var filiere = await _context.Filiere.FindAsync(id);
            if (filiere != null)
            {
                _context.Filiere.Remove(filiere);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FiliereExists(int id)
        {
          return (_context.Filiere?.Any(e => e.FiliereId == id)).GetValueOrDefault();
        }
    }
}
