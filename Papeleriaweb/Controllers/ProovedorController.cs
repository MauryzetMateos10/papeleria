using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Papeleriaweb.Data;
using Papeleriaweb.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Threading.Tasks;
using Rotativa.AspNetCore;
using System.Linq;
using System.Collections.Generic;

namespace Papeleriaweb.Controllers
{
    public class ProovedorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProovedorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Proovedor
        public async Task<IActionResult> Index(string buscar)
        {
            var proovedor = from p in _context.Proovedor select p;

            if (!string.IsNullOrEmpty(buscar))
            {
                proovedor = proovedor.Where(p => p.Nombreproveedor.Contains(buscar) ||
                    p.Direccion.Contains(buscar) ||
                    p.Marca.Contains(buscar) ||
                    p.Tipoproducto.Contains(buscar) ||
                    p.Cantidad.ToString().Contains(buscar) ||
                    p.PrecioUnitario.ToString().Contains(buscar) ||
                    p.PrecioTotal.ToString().Contains(buscar)); 
            }

            return View(await proovedor.ToListAsync());
        }

        // GET: Proovedor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proovedor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> agregarMercancia(Proovedor proovedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proovedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proovedor);
        }

        // GET: Proovedor/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proovedor = _context.Proovedor.Find(id);
            if (proovedor == null)
            {
                return NotFound();
            }
            return View(proovedor);
        }

        // POST: Producto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Proovedor proovedor)
        {
            if (id != proovedor.Id_proveedor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proovedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProovedorExists(proovedor.Id_proveedor))
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
            return View(proovedor);
        }

        // GET: Proovedor/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proovedor = _context.Proovedor
                .FirstOrDefault(m => m.Id_proveedor == id);
            if (proovedor == null)
            {
                return NotFound();
            }

            return View(proovedor);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proovedor = await _context.Proovedor.FindAsync(id);
            _context.Proovedor.Remove(proovedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProovedorExists(int id)
        {
            return _context.Proovedor.Any(e => e.Id_proveedor == id);
        }
    }
}
