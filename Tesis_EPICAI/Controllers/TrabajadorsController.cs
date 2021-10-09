using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tesis_EPICAI.Models;
using Tesis_EPICAI.ViewsModels;

namespace Tesis_EPICAI.Controllers
{
    public class TrabajadorsController : Controller
    {
        private readonly AppContext _context;

        public TrabajadorsController(AppContext context)
        {
            _context = context;
        }

        // GET: Trabajadors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Trabajador.ToListAsync());
        }

        // GET: Trabajadors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabajador = await _context.Trabajador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trabajador == null)
            {
                return NotFound();
            }

            return View(trabajador);
        }

        // GET: Trabajadors/Create
        public IActionResult Create()
        {
            var list = _context.Cargo.ToList();
            var model = new TrabajadorAdd
            {
                ListItems = new List<SelectListItem>()
            };
            model.ListItems = _context.Cargo.Select(c => new SelectListItem(c.Nombre, c.Nombre)).ToList();

            return View(model);
        }

        // POST: Trabajadors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TrabajadorAdd model)
        {
            if (ModelState.IsValid)
            {
                var idCargo = model.Cargo.Id;

                var trabajador = new Trabajador
                {
                    Nombre = model.Nombre,
                    Ci = model.Ci,
                    Direccion = model.Direccion,
                    NumeroTelefono = model.NumeroTelefono,
                    Cargo = model.Cargo
                };
                _context.Add(trabajador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: Trabajadors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabajador = await _context.Trabajador.FindAsync(id);
            if (trabajador == null)
            {
                return NotFound();
            }

            return View(trabajador);
        }

        // POST: Trabajadors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Ci,NumeroTelefono,Direccion")]
            Trabajador trabajador)
        {
            if (id != trabajador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trabajador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrabajadorExists(trabajador.Id))
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

            return View(trabajador);
        }

        // GET: Trabajadors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabajador = await _context.Trabajador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trabajador == null)
            {
                return NotFound();
            }

            return View(trabajador);
        }

        // POST: Trabajadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trabajador = await _context.Trabajador.FindAsync(id);
            _context.Trabajador.Remove(trabajador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrabajadorExists(int id)
        {
            return _context.Trabajador.Any(e => e.Id == id);
        }
    }
}