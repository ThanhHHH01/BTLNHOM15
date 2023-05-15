using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTLNHOM15.Models;

namespace BTLNHOM15.Controllers
{
    public class GiaGoiController : Controller
    {
        private readonly MvcGymContext _context;

        public GiaGoiController(MvcGymContext context)
        {
            _context = context;
        }

        // GET: GiaGoi
        public async Task<IActionResult> Index()
        {
              return _context.GiaGoi != null ? 
                          View(await _context.GiaGoi.ToListAsync()) :
                          Problem("Entity set 'MvcGymContext.GiaGoi'  is null.");
        }

        // GET: GiaGoi/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.GiaGoi == null)
            {
                return NotFound();
            }

            var giaGoi = await _context.GiaGoi
                .FirstOrDefaultAsync(m => m.MaGiaGoi == id);
            if (giaGoi == null)
            {
                return NotFound();
            }

            return View(giaGoi);
        }

        // GET: GiaGoi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GiaGoi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaGiaGoi,TenGoi")] GiaGoi giaGoi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(giaGoi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(giaGoi);
        }

        // GET: GiaGoi/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.GiaGoi == null)
            {
                return NotFound();
            }

            var giaGoi = await _context.GiaGoi.FindAsync(id);
            if (giaGoi == null)
            {
                return NotFound();
            }
            return View(giaGoi);
        }

        // POST: GiaGoi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaGiaGoi,TenGoi")] GiaGoi giaGoi)
        {
            if (id != giaGoi.MaGiaGoi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giaGoi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiaGoiExists(giaGoi.MaGiaGoi))
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
            return View(giaGoi);
        }

        // GET: GiaGoi/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.GiaGoi == null)
            {
                return NotFound();
            }

            var giaGoi = await _context.GiaGoi
                .FirstOrDefaultAsync(m => m.MaGiaGoi == id);
            if (giaGoi == null)
            {
                return NotFound();
            }

            return View(giaGoi);
        }

        // POST: GiaGoi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.GiaGoi == null)
            {
                return Problem("Entity set 'MvcGymContext.GiaGoi'  is null.");
            }
            var giaGoi = await _context.GiaGoi.FindAsync(id);
            if (giaGoi != null)
            {
                _context.GiaGoi.Remove(giaGoi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiaGoiExists(string id)
        {
          return (_context.GiaGoi?.Any(e => e.MaGiaGoi == id)).GetValueOrDefault();
        }
    }
}
