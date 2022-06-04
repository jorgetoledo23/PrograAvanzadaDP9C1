using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using WebApp.Models;
using WebApp.ViewModel;

namespace WebApp.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly AppDbContext _context;
        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GestionUsuarios()
        {
            return View(_context.Usuarios.ToList());
        }


        [HttpGet]
        public IActionResult CrearUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearUser(CrearUserViewModel Uvm)
        {
            if (ModelState.IsValid) { 
                Usuario U = new Usuario();
                U.Name = Uvm.Name;
                U.Email = Uvm.Email;
                U.Username = Uvm.Username;
                U.Rol = Uvm.Rol;

                CreatePasswordHash(Uvm.Password, out byte[] passwordHash, out byte[] passwordSalt); 
                U.PasswordHash = passwordHash;
                U.PasswordSalt = passwordSalt;
            
                _context.Usuarios.Add(U);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(GestionUsuarios));
            }
            else
            {
                return View(Uvm);
            }
        }



        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
