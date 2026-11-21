
using Microsoft.AspNetCore.Mvc;
using Dominio;

namespace WebMVC.Controllers
{
    public class PerfilController : Controller
    {
        // Instancia compartida del sistema.
        private Sistema _sistema = Sistema.Instancia;

        [HttpGet]

        // Muestra el perfil del investigador autenticado.
        public IActionResult Index()
        {
            string? email =
                HttpContext.Session.GetString("Email");

            if (email == null)
            {
                return RedirectToAction("Index", "Login");
            }

            Investigador? investigador =
                _sistema.BuscarInvestigador(email);

            if (investigador == null)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Login");
            }

            return View(investigador);
        }
    }
}
