using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTLNHOM15.Data;
using BTLNHOM15.Models;

namespace BTLNHOM15.Controllers
{
    public class TinhTrangController : Controller
    {
        private readonly MvcGymContext _context;

        public TinhTrangController(MvcGymContext context)
        {
            _context = context;
        }

        // GET: TinhTrang
        public async Task<IActionResult> Index()
        {
            var mvcGymContext = _context.TinhTrang.Include(t => t.ThietBi);
            return View(await mvcGymContext.ToListAsync());
        }

        // GET: TinhTrang/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.TinhTrang == null)
            {
                return NotFound();
            }

            var tinhTrang = await _context.TinhTrang
                .Include(t => t.ThietBi)
                .FirstOrDefaultAsync(m => m.MaTinhTrang == id);
            if (tinhTrang == null)
            {
                return NotFound();
            }

            return View(tinhTrang);
        }

        // GET: TinhTrang/Create
        public IActionResult Create()
        {
            ViewData["MaTB"] = new SelectList(_context.ThietBi, "MaTB", "MaTB");
            return View();
        }

        // POST: TinhTrang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaTinhTrang,MaTB,TinhTrangND")] TinhTrang tinhTrang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tinhTrang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaTB"] = new SelectList(_context.ThietBi, "MaTB", "MaTB", tinhTrang.MaTB);
            return View(tinhTrang);
        }

        // GET: TinhTrang/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.TinhTrang == null)
            {
                return NotFound();
            }

            var tinhTrang = await _context.TinhTrang.FindAsync(id);
            if (tinhTrang == null)
            {
                return NotFound();
            }
            ViewData["MaTB"] = new SelectList(_context.ThietBi, "MaTB", "MaTB", tinhTrang.MaTB);
            return View(tinhTrang);
        }

        // POST: TinhTrang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaTinhTrang,MaTB,TinhTrangND")] TinhTrang tinhTrang)
        {
            if (id != tinhTrang.MaTinhTrang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tinhTrang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TinhTrangExists(tinhTrang.MaTinhTrang))
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
            ViewData["MaTB"] = new SelectList(_context.ThietBi, "MaTB", "MaTB", tinhTrang.MaTB);
            return View(tinhTrang);
        }

        // GET: TinhTrang/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.TinhTrang == null)
            {
                return NotFound();
            }

            var tinhTrang = await _context.TinhTrang
                .Include(t => t.ThietBi)
                .FirstOrDefaultAsync(m => m.MaTinhTrang == id);
            if (tinhTrang == null)
            {
                return NotFound();
            }

            return View(tinhTrang);
        }

        // POST: TinhTrang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.TinhTrang == null)
            {
                return Problem("Entity set 'MvcGymContext.TinhTrang'  is null.");
            }
            var tinhTrang = await _context.TinhTrang.FindAsync(id);
            if (tinhTrang != null)
            {
                _context.TinhTrang.Remove(tinhTrang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TinhTrangExists(string id)
        {
          return (_context.TinhTrang?.Any(e => e.MaTinhTrang == id)).GetValueOrDefault();
        }
    }
}
