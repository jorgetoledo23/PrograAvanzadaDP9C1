using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ProductosController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public ProductosController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public IActionResult Index()
        {
            //var Productos = _context.Productos.ToList();
            var Productos = _context.Productos.Include(p=>p.Categoria).ToList();
            return View(Productos);
        }


        public async Task<IActionResult> Create()
        {
            ViewData["Categorias"] = new SelectList(_context.Categorias.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Producto P)
        {
            if (ModelState.IsValid)
            {
                if (P.ImagenFile == null) P.ImagenUrl = "no-disponible.png";
                else
                {
                    string wwwRootPath = _environment.WebRootPath; //Ruta del wwwroot
                    string fileName = Path.GetFileNameWithoutExtension(P.ImagenFile.FileName); // foto.jpg => foto
                    string extension = Path.GetExtension(P.ImagenFile.FileName); // foto.jpg => jpg
                    P.ImagenUrl = fileName + DateTime.Now.ToString("ddMMyyyyHHmmss") + extension; //foto16062022131559.jpg 

                    string path = Path.Combine(wwwRootPath + "/img/" + P.ImagenUrl);// wwwroot/img/foto16062022131559.jpg

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await P.ImagenFile.CopyToAsync(fileStream);
                    }
                }
                _context.Add(P);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(P);
        }
    }
}
