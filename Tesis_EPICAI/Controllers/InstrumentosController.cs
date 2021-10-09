using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tesis_EPICAI.Models;

namespace Tesis_EPICAI.Controllers
{
    public class InstrumentosController : Controller
    {
        private readonly AppContext _context;

        public InstrumentosController(AppContext context)
        {
            _context = context;
        }

        // GET: Instrumentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Instrumentos.ToListAsync());
        }

        // GET: Instrumentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrumentos = await _context.Instrumentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instrumentos == null)
            {
                return NotFound();
            }

            return View(instrumentos);
        }

        // GET: Instrumentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instrumentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Costo")] Instrumentos instrumentos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instrumentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instrumentos);
        }

        // GET: Instrumentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrumentos = await _context.Instrumentos.FindAsync(id);
            if (instrumentos == null)
            {
                return NotFound();
            }
            return View(instrumentos);
        }

        // POST: Instrumentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Costo")] Instrumentos instrumentos)
        {
            if (id != instrumentos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instrumentos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstrumentosExists(instrumentos.Id))
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
            return View(instrumentos);
        }

        // GET: Instrumentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrumentos = await _context.Instrumentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instrumentos == null)
            {
                return NotFound();
            }

            return View(instrumentos);
        }

        // POST: Instrumentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instrumentos = await _context.Instrumentos.FindAsync(id);
            _context.Instrumentos.Remove(instrumentos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstrumentosExists(int id)
        {
            return _context.Instrumentos.Any(e => e.Id == id);
        }
    }
}
