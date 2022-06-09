using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using WebApp.Models;
using WebApp.ViewModel;

namespace WebApp.Controllers
{
 [Authorize(Roles = "Administrador")]
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

        [HttpGet]
        public async Task<IActionResult> EditarUsuario(Guid userid)
        {
            var U = _context.Usuarios.FirstOrDefault(u => u.Id.Equals(userid));
            if (U == null) return NotFound();

            EditarUserViewModel Evm = new EditarUserViewModel()
            {
                Email = U.Email,
                Username = U.Username,
                Id = userid,
                Name = U.Name,
                Rol = U.Rol
            };

            return View(Evm);
        }

        [HttpPost]
        public async Task<IActionResult> EditarUsuario(EditarUserViewModel Evm)
        {
            var U = _context.Usuarios.FirstOrDefault(u => u.Id.Equals(Evm.Id));
            if (U == null) return NotFound();

            U.Name = Evm.Name;
            U.Email = Evm.Email;
            U.Username = Evm.Username;
            U.Rol = Evm.Rol;
            CreatePasswordHash(Evm.Password, out byte[] passwordHash, out byte[] passwordSalt);

            U.PasswordSalt = passwordSalt;
            U.PasswordHash = passwordHash;

            _context.Update(U);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(GestionUsuarios));
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
