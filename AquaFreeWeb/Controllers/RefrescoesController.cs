using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AquaFreeWeb.Context;
using AquaFreeWeb.Models;

namespace AquaFreeWeb.Controllers
{
    public class RefrescoesController : Controller
    {
        private readonly MiContext _context;

        public RefrescoesController(MiContext context)
        {
            _context = context;
        }

        // GET: Refrescoes
        public async Task<IActionResult> Index()
        {
              return _context.Refrescos != null ? 
                          View(await _context.Refrescos.ToListAsync()) :
                          Problem("Entity set 'MiContext.Refrescos'  is null.");
        }

        // GET: Refrescoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Refrescos == null)
            {
                return NotFound();
            }

            var refresco = await _context.Refrescos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (refresco == null)
            {
                return NotFound();
            }

            return View(refresco);
        }

        // GET: Refrescoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Refrescoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca,Sabor,Unidad,Tamanio")] Refresco refresco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(refresco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(refresco);
        }

        // GET: Refrescoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Refrescos == null)
            {
                return NotFound();
            }

            var refresco = await _context.Refrescos.FindAsync(id);
            if (refresco == null)
            {
                return NotFound();
            }
            return View(refresco);
        }

        // POST: Refrescoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,Sabor,Unidad,Tamanio")] Refresco refresco)
        {
            if (id != refresco.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(refresco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RefrescoExists(refresco.Id))
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
            return View(refresco);
        }

        // GET: Refrescoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Refrescos == null)
            {
                return NotFound();
            }

            var refresco = await _context.Refrescos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (refresco == null)
            {
                return NotFound();
            }

            return View(refresco);
        }

        // POST: Refrescoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Refrescos == null)
            {
                return Problem("Entity set 'MiContext.Refrescos'  is null.");
            }
            var refresco = await _context.Refrescos.FindAsync(id);
            if (refresco != null)
            {
                _context.Refrescos.Remove(refresco);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RefrescoExists(int id)
        {
          return (_context.Refrescos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
