using Microsoft.AspNetCore.Mvc;
using capa_negocio;
using capa_entidad;

namespace capa_presentacion.Controllers
{
    public class ClientesController : Controller

    {

        private readonly CN_Clientes _negocio;


        public ClientesController()
        {
            _negocio = new CN_Clientes();
        }

        [HttpGet]
        public ActionResult Listar()
        {
            var clientes = _negocio.Listar();
            return View(clientes);
        }

        [HttpGet]

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Agregar(CE_Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _negocio.Insertar(cliente);
                    return RedirectToAction("Listar");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Error al agregar el cliente. Inténtelo de nuevo.");
                }
            }
            return View(cliente);
        }

        [HttpGet]

        public ActionResult Editar(int id)
        {
            
            var cliente = _negocio.Listar().FirstOrDefault(c => c.IdCliente == id);
            return View(cliente);
        }

        [HttpPost]

        public ActionResult Editar(CE_Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _negocio.Actualizar(cliente);
                    return RedirectToAction("Listar");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Error al actualizar el cliente. Inténtelo de nuevo.");
                }
            }
            return View(cliente);
        }

        [HttpPost]

        public ActionResult Eliminar(int id)
        {
            try
            {
                _negocio.Eliminar(id);
                return RedirectToAction("Listar");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error al eliminar el cliente. Inténtelo de nuevo.");
                var clientes = _negocio.Listar();
                return View("Listar", clientes);
            }
        }

        

    
    }
}
