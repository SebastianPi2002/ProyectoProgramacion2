using Microsoft.AspNetCore.Mvc;
using Dominio;

namespace WebMVC.Controllers
{
    public class LoginController : Controller
    {
        // Instancia compartida del sistema.
        private Sistema _sistema = Sistema.Instancia;

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


        [HttpGet]

        // Muestra el formulario de registro de investigadores.
        public IActionResult Registro()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        // Registra un nuevo detective e inicia su sesión automáticamente.
        public IActionResult Registro(Investigador investigador)
        {
            try
            {
                investigador.Rol = Rol.DETECTIVE;

                _sistema.AltaInvestigador(investigador);

                HttpContext.Session.SetString(
                    "Email", investigador.Email);

                HttpContext.Session.SetString(
                    "Rol", investigador.Rol.ToString());

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(investigador);
            }
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