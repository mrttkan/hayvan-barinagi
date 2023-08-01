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
    public class HayvanlarController : Controller
    {
        private readonly HayvanBarinagiContext _context;

        public HayvanlarController(HayvanBarinagiContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
              return _context.Hayvanlar != null ? 
                          View(await _context.Hayvanlar.ToListAsync()) :
                          Problem("Entity set 'HayvanBarinagiContext.Hayvanlar'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hayvanlar == null)
            {
                return NotFound();
            }

            var hayvan = await _context.Hayvanlar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hayvan == null)
            {
                return NotFound();
            }

            return View(hayvan);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tur,Ad,ResimUrl,Aciklama,Sahiplendirildi")] Hayvan hayvan)
        {
            if (ModelState.IsValid)
            {
                hayvan.Sahiplendirildi = false;

                _context.Add(hayvan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hayvan);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hayvanlar == null)
            {
                return NotFound();
            }

            var hayvan = await _context.Hayvanlar.FindAsync(id);
            if (hayvan == null)
            {
                return NotFound();
            }
            return View(hayvan);
        }

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
                    hayvan.Sahiplendirildi = false;

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

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hayvanlar == null)
            {
                return NotFound();
            }

            var hayvan = await _context.Hayvanlar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hayvan == null)
            {
                return NotFound();
            }

            return View(hayvan);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hayvanlar == null)
            {
                return Problem("Entity set 'HayvanBarinagiContext.Hayvanlar'  is null.");
            }
            var hayvan = await _context.Hayvanlar.FindAsync(id);
            if (hayvan != null)
            {
                _context.Hayvanlar.Remove(hayvan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HayvanExists(int id)
        {
          return (_context.Hayvanlar?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
