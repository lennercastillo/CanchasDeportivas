using Microsoft.AspNetCore.Mvc;
using capa_entidad;
using capa_negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace capa_presentacion.Controllers
{
    public class CanchasController : Controller
    {

        CN_Canchas Canchas = new CN_Canchas();

        public ActionResult ListarCanchas()
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("El estado del modelo no es válido.");
                }

                var olista = Canchas.ListarCanchas();
                return View(olista);
            }

            catch (Exception ex)
            {

                TempData["ErrorMessage"] = "Error al obtener la lista de canchas: " + ex.Message;
                return View(new List<CE_Canchas>());
            }



        }


        public ActionResult AgregarCancha()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AgregarCancha(CE_Canchas cancha)
        {
            try
            {
                if (!ModelState.IsValid) 
                {
                    return StatusCode(404, $"No se encontro el modelo");

                }

                Canchas.AgregarCancha(cancha);
                return RedirectToAction("ListarCanchas");

            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Error al agregar la cancha: {ex.Message} ");
            }
        }

        [HttpGet]



        public ActionResult Actualizar(int id)

        {

            var lista = Canchas.ListarCanchas();
            var cancha = lista.FirstOrDefault(c => c.IdCancha == id);

           if (cancha == null)
            {
                return NotFound($"no se puedo actualizar la cancha con el id: {id}");
            }
            return View(cancha);
        }

        [HttpPost]

        public ActionResult Actualizar(CE_Canchas cancha)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Canchas.Actualizar(cancha);
                    return RedirectToAction("ListarCanchas");
                }
                Canchas.Actualizar(cancha);
                return RedirectToAction("ListarCanchas");




            }


            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar la cancha: {ex.Message} ");
            }
        }

        [HttpPost]

        public ActionResult Eliminar(int id)
        {
            Canchas.Eliminar(id);
            return RedirectToAction("ListarCanchas");
        }

        
}
    }