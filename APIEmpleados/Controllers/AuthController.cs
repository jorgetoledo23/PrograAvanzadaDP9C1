using APIEmpleados.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace APIEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Registro(UsuarioDTO userDTO)
        {
            if (userDTO == null) return BadRequest();

            Usuario usuario = new Usuario();
            usuario.Name = userDTO.Name;
            usuario.Email = userDTO.Email;
            usuario.Username = userDTO.Username;

            CreatePasswordHash(userDTO.Password, 
                out byte[] passwordHash, out byte[]passwordSalt);

            usuario.PasswordHash = passwordHash;
            usuario.PasswordSalt = passwordSalt;

            _context.Add(usuario);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginIn(LoginDTO loginDTO)
        {
            if (loginDTO == null) return BadRequest();

            var user = _context.Usuarios.FirstOrDefault(u => u.Username == loginDTO.Username);

            if (user == null) return BadRequest();

            if (VerifyPasswordHash(loginDTO.Password, user.PasswordHash, user.PasswordSalt)){
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }







        private void CreatePasswordHash(string password, 
            out byte[] passwordHash, 
            out byte[] passwordSalt) //By Ref
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8
                    .GetBytes(password));
            }
        }


        private bool VerifyPasswordHash(string password, 
            byte[] passwordHash, 
            byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8
                    .GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }



    }
}
