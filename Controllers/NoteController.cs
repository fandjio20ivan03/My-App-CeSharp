using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcNote.Models;

namespace MyProject.Controllers
{
    public class NoteController : Controller
    {
        private readonly MvcSchoolContext _context;

        public NoteController(MvcSchoolContext context)
        {
            _context = context;
        }

        // GET: Note
        public async Task<IActionResult> Index()
        {
            var mvcSchoolContext = _context.Note.Include(n => n.Cour_id).Include(n => n.Filiere_id);
            return View(await mvcSchoolContext.ToListAsync());
        }

        // GET: Note/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Note == null)
            {
                return NotFound();
            }

            var note = await _context.Note
                .Include(n => n.Cour_id)
                .Include(n => n.Filiere_id)
                .FirstOrDefaultAsync(m => m.NoteId == id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        // GET: Note/Create
        public IActionResult Create()
        {
            ViewData["CourID"] = new SelectList(_context.Cour, "CourId", "CourId");
            ViewData["FiliereID"] = new SelectList(_context.Filiere, "FiliereId", "FiliereId");
            return View();
        }

        // POST: Note/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NoteId,FiliereID,CourID,Value")] Note note)
        {
            if (ModelState.IsValid)
            {
                _context.Add(note);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourID"] = new SelectList(_context.Cour, "CourId", "CourId", note.CourID);
            ViewData["FiliereID"] = new SelectList(_context.Filiere, "FiliereId", "FiliereId", note.FiliereID);
            return View(note);
        }

        // GET: Note/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Note == null)
            {
                return NotFound();
            }

            var note = await _context.Note.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }
            ViewData["CourID"] = new SelectList(_context.Cour, "CourId", "CourId", note.CourID);
            ViewData["FiliereID"] = new SelectList(_context.Filiere, "FiliereId", "FiliereId", note.FiliereID);
            return View(note);
        }

        // POST: Note/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NoteId,FiliereID,CourID,Value")] Note note)
        {
            if (id != note.NoteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(note);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoteExists(note.NoteId))
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
            ViewData["CourID"] = new SelectList(_context.Cour, "CourId", "CourId", note.CourID);
            ViewData["FiliereID"] = new SelectList(_context.Filiere, "FiliereId", "FiliereId", note.FiliereID);
            return View(note);
        }

        // GET: Note/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Note == null)
            {
                return NotFound();
            }

            var note = await _context.Note
                .Include(n => n.Cour_id)
                .Include(n => n.Filiere_id)
                .FirstOrDefaultAsync(m => m.NoteId == id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        // POST: Note/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Note == null)
            {
                return Problem("Entity set 'MvcSchoolContext.Note'  is null.");
            }
            var note = await _context.Note.FindAsync(id);
            if (note != null)
            {
                _context.Note.Remove(note);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoteExists(int id)
        {
          return (_context.Note?.Any(e => e.NoteId == id)).GetValueOrDefault();
        }
    }
}
