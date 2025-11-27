using Microsoft.AspNetCore.Mvc;
using capa_negocio;
using capa_entidad;


namespace capa_presentacion.Controllers
{
    public class ClientesController : Controller

    {

        CN_Clientes Clientes = new CN_Clientes();

        public ActionResult ListarClientes()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("El estado del modelo no es válido.");
                }
                var olista = Clientes.Listar();
                return View(olista);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error al obtener la lista de clientes: " + ex.Message;
                return View(new List<CE_Clientes>());
            }

        }

        public ActionResult InsertarCliente()
        {
            return View();
        }

        [HttpPost]

        public ActionResult InsertarClientes(CE_Clientes cliente)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(404, $"No se encontro el modelo");
                }
                Clientes.Insertar(cliente);
                return RedirectToAction("ListarClientes");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al agregar el cliente: {ex.Message}");
            }


        }

        [HttpGet]

     

        public ActionResult Actualizar(int id)
        {
           var oCliente = Clientes.Listar();
           var cliente = oCliente.FirstOrDefault(c => c.IdCliente == id);

            if (cliente == null)
            {
                return NotFound($"No se pudo actualizar el cliente con el id: {id}");
            }
            return View(cliente);
        }

        public ActionResult Actualizar(CE_Clientes clientes)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Clientes.Actualizar(clientes);
                    return RedirectToAction("ListarClientes");
                }
                Clientes.Actualizar(clientes);
                return RedirectToAction("ListarClientes");




            }


            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar la cancha: {ex.Message} ");
            }
        }

        public ActionResult Eliminar(int id)
        {
            try
            {
                Clientes.Eliminar(id);
                return RedirectToAction("ListarClientes");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar el cliente: {ex.Message}");
            }
        }




    }
}