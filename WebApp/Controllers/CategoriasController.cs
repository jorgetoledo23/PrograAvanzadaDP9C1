using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly AppDbContext _context;
        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Categorias.ToList());
            //return View(_context.Categorias.Where(c=> c.Enabled == true).ToList());
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Categoria C)
        {
            if (ModelState.IsValid)
            {
                _context.Categorias.Add(C);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(C);
            }
        }

        public async Task<IActionResult> Edit(int CategoriaId)
        {
            var C = _context.Categorias.FirstOrDefault(c => c.Id == CategoriaId);
            if (C == null) return NotFound();
            return View(C);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Categoria C)
        {
            if (ModelState.IsValid)
            {
                _context.Categorias.Update(C);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(C);
            }
        }

        public async Task<IActionResult> Disable(int CategoriaId, bool Enable)
        {
            var C = _context.Categorias.FirstOrDefault(c => c.Id == CategoriaId);
            if (C == null) return NotFound();
            C.Enabled = Enable;
            _context.Categorias.Update(C);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }






    }
}
