using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models;
using WebApp.ViewModel;

namespace WebApp.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class HomeController : Controller
    {
        //[Authorize(Roles = "Administrador")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ContactViewModel contactViewModel = new ContactViewModel();

            List<string> Contactos = new List<string>
            {
                "Wsp: +56 9 1234 5678",
                "Correo: sistema@inacap.cl",
                "Direccion: Curico, CL"
            };
            List<int> Numeros = new List<int>
            {
                1,
                2,
                3
            };

            contactViewModel.Numeros = Numeros;
            contactViewModel.Contactos = Contactos;

            return View(contactViewModel);
        }

        public RedirectToActionResult LoginOut()
        {
            return RedirectToAction(nameof(Index));
            //return RedirectToAction("asdasd","asdasd");
         }

    }
}