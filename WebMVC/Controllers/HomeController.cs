using Dominio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {

        // Muestra la página principal y la cantidad de casos registrados.
        public IActionResult Index()
        {
            string? email = HttpContext.Session.GetString("Email");

            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Index", "Login");
            }

            List<Caso> casos = _sistema.ObtenerCasos();

            ViewBag.CantidadCasos = casos.Count;

            return View();
        }


        // Muestra la página de privacidad.
        public IActionResult Privacy()
        {
            return View();
        }

        // Instancia compartida del sistema.
        private Sistema _sistema = Sistema.Instancia;

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        // Muestra la información correspondiente a un error de la aplicación.
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
