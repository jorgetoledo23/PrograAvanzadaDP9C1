﻿using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using System.Security.Cryptography;
using WebApp.ViewModel;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace WebApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> LoginIn()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> LoginIn(LoginViewModel lvm)
        {
            var Usuarios = _context.Usuarios.ToList();


            Usuario? U = new Usuario();
            if (Usuarios.Count == 0)
            {
                //Crear al SuperUser
                U.Name = "admin";
                U.Email = "admin@dominio.com";
                U.Rol = "Administrador";
                U.Username = "admin";
                CreatePasswordHash("admin", out byte[] passwordHash, out byte[] passworSalt);
                U.PasswordHash = passwordHash;
                U.PasswordSalt = passworSalt;
                _context.Add(U);
                await _context.SaveChangesAsync();
            }


            //Login
            U = null;
            U = _context.Usuarios.FirstOrDefault(u => u.Username == lvm.Username); //admin
            if (U == null)
            {
                ModelState.AddModelError(String.Empty, "Usuario NO Encontrado");
                return View(lvm);
            }
            else
            {
                if (!VerifyPasswordHash(lvm.Password, U.PasswordHash, U.PasswordSalt)) //123456
                {
                    ModelState.AddModelError(String.Empty, "Password Incorrecta");
                    return View(lvm);
                }
                else
                {
                    var claims = new List<Claim>{
                        new Claim(ClaimTypes.NameIdentifier, U.Id.ToString()),
                        new Claim(ClaimTypes.Name, U.Username),
                        new Claim(ClaimTypes.Role , U.Rol) //Administrador
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                            principal,
                            new AuthenticationProperties { IsPersistent = true });
                    return RedirectToAction(nameof(Profile));
                }
            }
        }

        public IActionResult Profile()
        {
            if (User.Identity.IsAuthenticated)
            {
                var Usuario = _context.Usuarios.FirstOrDefault(u => u.Username == User.Identity.Name);
                ProfileViewModel pvm = new ProfileViewModel()
                {
                    Usuario = Usuario
                };

                return View(pvm);
            }
            //return View();
            return RedirectToAction(nameof(LoginIn));
        }



        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

    }


}