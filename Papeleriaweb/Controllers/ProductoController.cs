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
    public class ProductoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Producto
        public async Task<IActionResult> Index(string buscar)
        {
            var producto = from p in _context.Producto select p;

            if (!string.IsNullOrEmpty(buscar))
            {
                producto = producto.Where(p => p.Nombreproducto.Contains(buscar) ||
                    p.Marcaproducto.Contains(buscar) ||
                    p.Descripcionproducto.Contains(buscar) ||
                    p.Precioproducto.ToString().Contains(buscar) ||
                    p.Stockproducto.ToString().Contains(buscar) ||
                    p.Tamañoproducto.Contains(buscar) ||
                    p.Colorproducto.Contains(buscar) ||
                    p.Tipoproducto.Contains(buscar));
            }

            return View(await producto.ToListAsync());
        }

        // GET: Producto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> agregarProducto(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: Producto/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = _context.Producto.Find(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: Producto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Producto producto)
        {
            if (id != producto.Id_producto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.Id_producto))
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
            return View(producto);
        }

        // GET: Producto/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = _context.Producto
                .FirstOrDefault(m => m.Id_producto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = await _context.Producto.FindAsync(id);
            _context.Producto.Remove(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Method to generate PDF
        public ActionResult GeneratePdf()
        {
            var model = GetDataForPdf();
            return new ViewAsPdf("VistaTablaPdf", model)
            {
                FileName = "Lista_de_productos.pdf",
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                CustomSwitches = "--print-media-type"
            };
        }

        private List<Producto> GetDataForPdf()
        {
            var producto = _context.Producto.ToList();
            return producto;
        }

        private bool ProductoExists(int id)
        {
            return _context.Producto.Any(e => e.Id_producto == id);
        }

    }
}

