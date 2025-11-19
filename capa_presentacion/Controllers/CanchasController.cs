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
        
        private readonly CN_Canchas _negocio;

        public CanchasController()
        {
            
            _negocio = new CN_Canchas();
        }

        
        public ActionResult Listar()
        {
            var canchas = _negocio.ListarCanchas();
            return View(canchas);
        }

        
        public ActionResult Agregar()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Agregar(CE_Canchas cancha)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _negocio.Agregar(cancha);
                    return RedirectToAction("Listar");
                }
                catch (Exception ex)
                {
                    
                    ModelState.AddModelError(string.Empty, "Error al agregar la cancha. Inténtelo de nuevo.");
                    
                }
            }

            return View(cancha); 
        }


        
        [HttpPost]
        
        public ActionResult Eliminar(CE_Canchas cancha) 
        {
            
            if (cancha == null || cancha.IdCancha <= 0)
            {
                
                TempData["ErrorMessage"] = "Información incompleta: El ID de la cancha es requerido para la eliminación.";
                return RedirectToAction("Listar");
            }

            try
            {
               
                _negocio.Eliminar(cancha);

                TempData["SuccessMessage"] = $"La cancha con ID {cancha.IdCancha} ha sido eliminada exitosamente.";
                return RedirectToAction("Listar");
            }
            catch (ArgumentException aex)
            {
               
                TempData["ErrorMessage"] = aex.Message;
                return RedirectToAction("Listar");
            }
            catch (Exception ex)
            {
                
                TempData["ErrorMessage"] = "Ocurrió un error al intentar eliminar la cancha. Detalles: " + ex.Message;
                return RedirectToAction("Listar");
            }
        }
    }
}