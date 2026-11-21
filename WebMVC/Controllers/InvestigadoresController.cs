
using Microsoft.AspNetCore.Mvc;
using Dominio;

namespace WebMVC.Controllers
{
    public class InvestigadoresController : Controller
    {
        // Instancia compartida del sistema.
        private Sistema _sistema = Sistema.Instancia;


        // Muestra los datos del investigador autenticado.
        public IActionResult Perfil()
        {
            string? email = HttpContext.Session.GetString("Email");

            if (email == null)
            {
                return RedirectToAction("Index", "Login");
            }

            Investigador investigador = _sistema.BuscarInvestigador(email);

            if (investigador == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View(investigador);
        }
    }
}
