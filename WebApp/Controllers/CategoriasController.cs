using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.ViewModel;

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
            CreateCategoriaViewModel Ccvm = new CreateCategoriaViewModel()
            {
                Categorias = _context.Categorias.ToList()
            };
            return View(Ccvm);
            //return View(_context.Categorias.Where(c=> c.Enabled == true).ToList());
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind(Prefix = "Categoria")] Categoria C)
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

        public async Task<IActionResult> Delete(int CategoriaId)
        {
            var C = await _context.Categorias.FindAsync(CategoriaId);
            if (C == null) return NotFound();
            _context.Categorias.Remove(C);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }





    }
}
