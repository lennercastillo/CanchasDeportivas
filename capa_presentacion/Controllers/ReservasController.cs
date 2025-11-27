using System.Reflection;
using capa_entidad;
using capa_negocio;
using capa_presentacion.Models;
using Microsoft.AspNetCore.Mvc;


namespace capa_presentacion.Controllers
{
    public class ReservasController : Controller

    {

       CN_Reservas Reservas = new CN_Reservas();

        public ActionResult ListarReservas()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("El estado del modelo no es válido.");
                }
                var olista = Reservas.Listar();
                return View(olista);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error al obtener la lista de reservas: " + ex.Message;
                return View(new List<CE_Reservas>());
            }

        }

        public ActionResult InsertarReservas()
        {
            // 1. Creas el paquete (el ViewModel)
            ReservaViewModel modelo = new ReservaViewModel();

            // 2. Le pones la lista de clientes adentro (para que el dropdown funcione)
            modelo.ListaClientes = new CN_Clientes().Listar();
            modelo.ListaCanchas = new CN_Canchas().ListarCanchas();

            // 3. Inicializas la reserva (para evitar otros nulos)
            modelo.Reserva = new CE_Reservas();

            // 4. ¡LA CLAVE! Envías el modelo a la vista
            return View(modelo);
            //return View();
        }
        /*
        [HttpPost]
        public ActionResult InsertarReservas(CE_Reservas reservas)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(404, $"No se encontro el modelo");
                }

                Reservas.InsertarReservas(reservas);
                return RedirectToAction("ListarReservas");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al agregar la reserva: {ex.Message}");
            }

        }
        */

        [HttpPost]
        public ActionResult InsertarReservas(ReservaViewModel reservas)
        {
            try
            {
                if (reservas.Reserva == null)
                {
                    return StatusCode(404, $"No se encontro el modelo");
                }

                Reservas.InsertarReservas(reservas);
                return RedirectToAction("ListarReservas");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al agregar la reserva: {ex.Message}");
            }

        }

        [HttpGet]
        public ActionResult Actualizar(int id)
        {
            var oReserva = Reservas.Listar();
            var reserva = oReserva.FirstOrDefault(c => c.IdReserva == id);

            if (reserva == null)
            {
                return NotFound($"No se pudo actualizar el cliente con el id: {id}");
            }
            return View(reserva);
        }

        public ActionResult Actualizar(CE_Reservas reservas)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Reservas.Actualizar(reservas);
                    return RedirectToAction("ListarReservas");
                }
                Reservas.Actualizar(reservas);
                return RedirectToAction("ListarReservas");




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
                Reservas.Eliminar(id);




                return RedirectToAction("ListarReservas");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar la reserva: {ex.Message}");
            }
        }




    }
}