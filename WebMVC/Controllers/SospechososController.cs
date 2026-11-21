
using Microsoft.AspNetCore.Mvc;
using Dominio;

namespace WebMVC.Controllers
{
    public class SospechososController : Controller
    {
        // Instancia compartida del sistema.
        private Sistema _sistema = Sistema.Instancia;

        [HttpGet]

        // Lista los sospechosos y permite filtrarlos por edad.
        // Acceso exclusivo para detectives.
        public IActionResult Index(int? edadMinima)
        {
            string? email = HttpContext.Session.GetString("Email");
            string? rol = HttpContext.Session.GetString("Rol");

            if (email == null || rol == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (rol != Rol.DETECTIVE.ToString())
            {
                return StatusCode(403, "Acceso denegado.");
            }

            try
            {
                List<Sospechoso> sospechosos;

                if (edadMinima.HasValue)
                {
                    sospechosos =
                        _sistema.ObtenerSospechososPorEdad(
                            edadMinima.Value);
                }
                else
                {
                    sospechosos =
                        _sistema.ObtenerSospechososPorEdad(0);
                }

                ViewBag.EdadMinima = edadMinima;

                return View(sospechosos);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(new List<Sospechoso>());
            }
        }
    }
}
