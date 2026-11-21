using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Dominio;

namespace WebMVC.Controllers
{
    public class CasosController : Controller
    {
        // Instancia compartida del sistema.
        private Sistema _sistema = Sistema.Instancia;

        // Lista todos los casos registrados. Acceso exclusivo para fiscales.

        public IActionResult Index()
        {
            string? email =
                HttpContext.Session.GetString("Email");

            string? rol =
                HttpContext.Session.GetString("Rol");

            // Verifica que exista una sesión activa.
            if (email == null || rol == null)
            {
                return RedirectToAction("Index", "Login");
            }

            // Verifica que el usuario tenga rol Fiscal.
            if (rol != Rol.FISCAL.ToString())
            {
                return StatusCode(403, "Acceso denegado. No tenés permisos para acceder a esta sección.");
            }

            List<Caso> casos = _sistema.ObtenerCasos();

            return View(casos);
        }

        // Lista los casos asignados al detective autenticado,
        // ordenados alfabéticamente por nombre.

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
                return StatusCode(403, "Acceso denegado. No tenés permisos para acceder a esta sección.");
            }

            List<Caso> casos = _sistema.ObtenerCasosPorEmail(email);

            casos.Sort((a, b) =>
                string.Compare(a.Nombre, b.Nombre,
                    StringComparison.OrdinalIgnoreCase));

            return View(casos);
        }


        [HttpGet]


        // Muestra los detalles de un caso según los permisos del usuario.
        public IActionResult Detalles(int id)
        {
            string? email = HttpContext.Session.GetString("Email");
            string? rol = HttpContext.Session.GetString("Rol");

            if (email == null || rol == null)
            {
                return RedirectToAction("Index", "Login");
            }

            Caso? caso = _sistema.BuscarCaso(id);

            if (caso == null)
            {
                return NotFound("El caso no existe.");
            }

            if (rol == Rol.DETECTIVE.ToString())
            {
                if (!string.Equals(
                    caso.Investigador.Email,
                    email,
                    StringComparison.OrdinalIgnoreCase))
                {
                    return StatusCode(403, "No tenés permisos para ver este caso.");
                }
            }
            else if (rol != Rol.FISCAL.ToString())
            {
                return StatusCode(403, "Acceso denegado.");
            }

            return View(caso);
        }



        [HttpGet]

        // Muestra el formulario de creación de casos para fiscales.
        public IActionResult Crear()
        {
            string? email = HttpContext.Session.GetString("Email");
            string? rol = HttpContext.Session.GetString("Rol");

            if (email == null || rol == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (rol != Rol.FISCAL.ToString())
            {
                return StatusCode(403, "Acceso denegado.");
            }

            CargarListas();

            return View();
        }

        // Carga los detectives y sospechosos disponibles para seleccionar.

        private void CargarListas()
        {
            ViewBag.Detectives = new SelectList(
                _sistema.ObtenerDetectives(),
                "Email",
                "Nombre"
            );

            ViewBag.Sospechosos = new SelectList(
                _sistema.ObtenerSospechosos(),
                "Cedula",
                "Nombre"
            );
        }



        [HttpPost]
        [ValidateAntiForgeryToken]

        // Registra un nuevo caso con el detective y sospechoso seleccionados.
        public IActionResult Crear(
            string nombre,
            string descripcion,
            string emailDetective,
            string cedulaSospechoso)
        {
            string? email = HttpContext.Session.GetString("Email");
            string? rol = HttpContext.Session.GetString("Rol");

            if (email == null || rol == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (rol != Rol.FISCAL.ToString())
            {
                return StatusCode(403, "Acceso denegado.");
            }

            try
            {
                Investigador? detective =
                    _sistema.BuscarInvestigador(emailDetective);

                Sospechoso? sospechoso = null;

                foreach (Sospechoso s in _sistema.ObtenerSospechosos())
                {
                    if (s.Cedula == cedulaSospechoso)
                    {
                        sospechoso = s;
                        break;
                    }
                }

                if (detective == null)
                {
                    throw new Exception("El detective no existe.");
                }

                if (sospechoso == null)
                {
                    throw new Exception("El sospechoso no existe.");
                }

                Caso caso = new Caso(
                    nombre,
                    descripcion,
                    false,
                    sospechoso,
                    detective
                );

                _sistema.AltaCaso(caso);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                CargarListas();

                return View();
            }
        }

    }
}