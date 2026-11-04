using Microsoft.AspNetCore.Mvc;
using Dominio;

namespace WebMVC.Controllers
{
    public class LoginController : Controller
    {
        private Sistema _sistema;

        public LoginController(Sistema sistema)
        {
            _sistema = sistema;
        }

        // Muestra el formulario de login.
        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Email") != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // Recibe el email y la contraseña.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string email, string contrasena)
        {
            Investigador? investigador =
                _sistema.IniciarSesion(email, contrasena);

            if (investigador == null)
            {
                ViewBag.Error = "Email o contraseña incorrectos.";
                return View();
            }

            HttpContext.Session.SetString(
                "Email", investigador.Email);

            HttpContext.Session.SetString(
                "Rol", investigador.Rol.ToString());

            return RedirectToAction("Index", "Home");
        }

        // Cierra la sesión del investigador.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Login");
        }
    }
}