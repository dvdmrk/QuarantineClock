using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;

namespace web.Controllers
{
    public class QuarantineController : Controller
    {
        private readonly Context _context;

        public QuarantineController(Context context)
        {
            _context = context;
        }

        // GET: Quarantine
        public async Task<IActionResult> Index()
        {
            return View(await _context.Quarantines.ToListAsync());
        }

        // GET: Quarantine/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quarantine = await _context.Quarantines
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quarantine == null)
            {
                return NotFound();
            }

            return View(quarantine);
        }

        // GET: Quarantine/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Quarantine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StartDate,Duration,Country,Id")] Quarantine quarantine)
        {
            if (ModelState.IsValid)
            {
                quarantine.Id = Guid.NewGuid();
                _context.Add(quarantine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quarantine);
        }

        // GET: Quarantine/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quarantine = await _context.Quarantines.FindAsync(id);
            if (quarantine == null)
            {
                return NotFound();
            }
            return View(quarantine);
        }

        // POST: Quarantine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("StartDate,Duration,Country,Id")] Quarantine quarantine)
        {
            if (id != quarantine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quarantine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuarantineExists(quarantine.Id))
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
            return View(quarantine);
        }

        // GET: Quarantine/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quarantine = await _context.Quarantines
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quarantine == null)
            {
                return NotFound();
            }

            return View(quarantine);
        }

        // POST: Quarantine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var quarantine = await _context.Quarantines.FindAsync(id);
            _context.Quarantines.Remove(quarantine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuarantineExists(Guid id)
        {
            return _context.Quarantines.Any(e => e.Id == id);
        }
    }
}
