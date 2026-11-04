
using Microsoft.AspNetCore.Mvc;
using Dominio;

namespace WebMVC.Controllers
{
    public class CasosController : Controller
    {
        private Sistema _sistema;

        public CasosController(Sistema sistema)
        {
            _sistema = sistema;
        }

        public IActionResult Index()
        {
            string? email =
                HttpContext.Session.GetString("Email");

            string? rol =
                HttpContext.Session.GetString("Rol");

            // Si no inició sesión, va al login.
            if (email == null || rol == null)
            {
                return RedirectToAction("Index", "Login");
            }

            // Solo el Fiscal puede ver todos los casos.
            if (rol != Rol.FISCAL.ToString())
            {
                return Forbid();
            }

            List<Caso> casos = _sistema.ObtenerCasos();

            return View(casos);
        }

        public IActionResult MisCasos()
        {
            string? email = HttpContext.Session.GetString("Email");
            string? rol = HttpContext.Session.GetString("Rol");

            if (email == null || rol == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (rol != Rol.DETECTIVE.ToString())
            {
                return Forbid();
            }

            List<Caso> casos = _sistema.ObtenerCasosPorEmail(email);

            casos.Sort((a, b) =>
                string.Compare(a.Nombre, b.Nombre,
                    StringComparison.OrdinalIgnoreCase));

            return View(casos);
        }
    }
}