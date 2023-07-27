using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HayvanBarinagi.Models;

namespace HayvanBarinagi.Controllers
{
    public class SahiplendirmeBasvurulariController : Controller
    {
        private readonly HayvanBarinagiContext _context;

        public SahiplendirmeBasvurulariController(HayvanBarinagiContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var basvurular = await _context.SahiplendirmeBasvurulari.Include(b => b.Hayvan).ToListAsync();
            return View(basvurular);
        }

        public IActionResult Create(int hayvanId)
        {
            ViewBag.HayvanId = hayvanId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SahiplendirmeBasvurulari basvuru)
        {
            if (ModelState.IsValid)
            {
                _context.Add(basvuru);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(basvuru);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basvuru = await _context.SahiplendirmeBasvurulari.FindAsync(id);
            if (basvuru == null)
            {
                return NotFound();
            }
            return View(basvuru);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SahiplendirmeBasvurulari basvuru)
        {
            if (id != basvuru.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(basvuru);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BasvuruExists(basvuru.Id))
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
            return View(basvuru);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basvuru = await _context.SahiplendirmeBasvurulari
                .Include(b => b.Hayvan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (basvuru == null)
            {
                return NotFound();
            }

            return View(basvuru);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var basvuru = await _context.SahiplendirmeBasvurulari.FindAsync(id);
            _context.SahiplendirmeBasvurulari.Remove(basvuru);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BasvuruExists(int id)
        {
            return _context.SahiplendirmeBasvurulari.Any(e => e.Id == id);
        }
    }
}
