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
    public class HoiVienController : Controller
    {
        private readonly MvcGymContext _context;

        public HoiVienController(MvcGymContext context)
        {
            _context = context;
        }

        // GET: HoiVien
        public async Task<IActionResult> Index()
        {
              return _context.HoiVien != null ? 
                          View(await _context.HoiVien.ToListAsync()) :
                          Problem("Entity set 'MvcGymContext.HoiVien'  is null.");
        }

        // GET: HoiVien/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.HoiVien == null)
            {
                return NotFound();
            }

            var hoiVien = await _context.HoiVien
                .FirstOrDefaultAsync(m => m.HoiVienID == id);
            if (hoiVien == null)
            {
                return NotFound();
            }

            return View(hoiVien);
        }

        // GET: HoiVien/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HoiVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HoiVienID,TenHV,Address,SĐT,EmailHV,GoiTap,Ngaybatdau,Ngayketthuc")] HoiVien hoiVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoiVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hoiVien);
        }

        // GET: HoiVien/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.HoiVien == null)
            {
                return NotFound();
            }

            var hoiVien = await _context.HoiVien.FindAsync(id);
            if (hoiVien == null)
            {
                return NotFound();
            }
            return View(hoiVien);
        }

        // POST: HoiVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("HoiVienID,TenHV,Address,SĐT,EmailHV,GoiTap,Ngaybatdau,Ngayketthuc")] HoiVien hoiVien)
        {
            if (id != hoiVien.HoiVienID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoiVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoiVienExists(hoiVien.HoiVienID))
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
            return View(hoiVien);
        }

        // GET: HoiVien/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.HoiVien == null)
            {
                return NotFound();
            }

            var hoiVien = await _context.HoiVien
                .FirstOrDefaultAsync(m => m.HoiVienID == id);
            if (hoiVien == null)
            {
                return NotFound();
            }

            return View(hoiVien);
        }

        // POST: HoiVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.HoiVien == null)
            {
                return Problem("Entity set 'MvcGymContext.HoiVien'  is null.");
            }
            var hoiVien = await _context.HoiVien.FindAsync(id);
            if (hoiVien != null)
            {
                _context.HoiVien.Remove(hoiVien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoiVienExists(string id)
        {
          return (_context.HoiVien?.Any(e => e.HoiVienID == id)).GetValueOrDefault();
        }
    }
}
