using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HayvanBarinagi.Models;

namespace HayvanBarinagi.Controllers
{
    public class HayvansController : Controller
    {
        private readonly HayvanBarinagiContext _context;

        public HayvansController(HayvanBarinagiContext context)
        {
            _context = context;
        }

        // GET: Hayvans
        public async Task<IActionResult> Index()
        {
              return _context.Hayvans != null ? 
                          View(await _context.Hayvans.ToListAsync()) :
                          Problem("Entity set 'HayvanBarinagiContext.Hayvans'  is null.");
        }

        // GET: Hayvans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hayvans == null)
            {
                return NotFound();
            }

            var hayvan = await _context.Hayvans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hayvan == null)
            {
                return NotFound();
            }

            return View(hayvan);
        }

        // GET: Hayvans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hayvans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tur,Ad,ResimUrl,Aciklama,Sahiplendirildi")] Hayvan hayvan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hayvan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hayvan);
        }

        // GET: Hayvans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hayvans == null)
            {
                return NotFound();
            }

            var hayvan = await _context.Hayvans.FindAsync(id);
            if (hayvan == null)
            {
                return NotFound();
            }
            return View(hayvan);
        }

        // POST: Hayvans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tur,Ad,ResimUrl,Aciklama,Sahiplendirildi")] Hayvan hayvan)
        {
            if (id != hayvan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hayvan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HayvanExists(hayvan.Id))
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
            return View(hayvan);
        }

        // GET: Hayvans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hayvans == null)
            {
                return NotFound();
            }

            var hayvan = await _context.Hayvans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hayvan == null)
            {
                return NotFound();
            }

            return View(hayvan);
        }

        // POST: Hayvans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hayvans == null)
            {
                return Problem("Entity set 'HayvanBarinagiContext.Hayvans'  is null.");
            }
            var hayvan = await _context.Hayvans.FindAsync(id);
            if (hayvan != null)
            {
                _context.Hayvans.Remove(hayvan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HayvanExists(int id)
        {
          return (_context.Hayvans?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
