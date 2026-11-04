using Dominio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Caso> casos = _sistema.ObtenerCasos();

            ViewBag.CantidadCasos = casos.Count;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        private Sistema _sistema;

        public HomeController(Sistema sistema)
        {
            _sistema = sistema;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
