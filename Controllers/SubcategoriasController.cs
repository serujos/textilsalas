using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using textilsalas.Data;
using textilsalas.Models;

namespace textilsalas.Controllers
{
    public class SubcategoriasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubcategoriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Subcategorias
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Subcategorias.Include(s => s.Categoria);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Subcategorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subcategoria = await _context.Subcategorias
                .Include(s => s.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subcategoria == null)
            {
                return NotFound();
            }

            return View(subcategoria);
        }

        // GET: Subcategorias/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Id");
            return View();
        }

        // POST: Subcategorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,CategoriaId")] Subcategoria subcategoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subcategoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Id", subcategoria.CategoriaId);
            return View(subcategoria);
        }

        // GET: Subcategorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subcategoria = await _context.Subcategorias.FindAsync(id);
            if (subcategoria == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Id", subcategoria.CategoriaId);
            return View(subcategoria);
        }

        // POST: Subcategorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,CategoriaId")] Subcategoria subcategoria)
        {
            if (id != subcategoria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subcategoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubcategoriaExists(subcategoria.Id))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Id", subcategoria.CategoriaId);
            return View(subcategoria);
        }

        // GET: Subcategorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subcategoria = await _context.Subcategorias
                .Include(s => s.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subcategoria == null)
            {
                return NotFound();
            }

            return View(subcategoria);
        }

        // POST: Subcategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subcategoria = await _context.Subcategorias.FindAsync(id);
            if (subcategoria != null)
            {
                _context.Subcategorias.Remove(subcategoria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubcategoriaExists(int id)
        {
            return _context.Subcategorias.Any(e => e.Id == id);
        }
    }
}
