using System;
using System.Collections.Generic;
using System.Linq;
using capa_entidad;
using capa_dato;

namespace capa_negocio
{
    public class CN_Canchas
    {
        // Instancia de la Capa de Datos para acceder a las operaciones de la DB
        private CD_Canchas oCD_Canchas = new CD_Canchas();

        // 1. Método para Listar todas las canchas
        public List<CE_Canchas> ListarCanchas()
        {
            

            try
            {
                return oCD_Canchas.Listar();
            }
            catch (Exception ex)
            {
                // En un proyecto real, deberías loggear (registrar) la excepción.
                throw new Exception("Error en el listado de canchas: " + ex.Message);
            }
        }

        // 2. Método para Agregar una nueva cancha
        public void Agregar(CE_Canchas cancha)
        {
            // **Reglas de Negocio/Validaciones:**
            // ------------------------------------
            if (string.IsNullOrWhiteSpace(cancha.Nombre))
            {
                throw new ArgumentException("El nombre de la cancha es obligatorio.");
            }
            if (cancha.PrecioPorHora <= 0)
            {
                throw new ArgumentException("El precio por hora debe ser mayor a cero.");
            }
            // ------------------------------------

            try
            {
                oCD_Canchas.AgregarCancha(cancha);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la cancha: " + ex.Message);
            }
        }

        // 3. Método para Actualizar una cancha existente
        public void Actualizar(CE_Canchas cancha)
        {
            // **Reglas de Negocio/Validaciones:**
            // ------------------------------------
            if (cancha.IdCancha <= 0)
            {
                throw new ArgumentException("El Id de la cancha es inválido para la actualización.");
            }
            if (string.IsNullOrWhiteSpace(cancha.Tipo))
            {
                throw new ArgumentException("El tipo de cancha no puede estar vacío.");
            }
            // ------------------------------------

            try
            {
                oCD_Canchas.ActualizarCancha(cancha);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la cancha: " + ex.Message);
            }
        }

        
        public void Eliminar(CE_Canchas cancha)
        {
            // **Regla de Negocio:** // ------------------------------------
            if (cancha.IdCancha <= 0)
            {
                throw new ArgumentException("El Id de la cancha es obligatorio para la eliminación.");
            }
            // Podrías validar aquí si la cancha tiene reservas activas antes de permitir la eliminación.
            // ------------------------------------

            try
            {
                oCD_Canchas.EliminarCancha(cancha);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la cancha: " + ex.Message);
            }
        }

        // **Nota sobre ListarCancha(CE_Canchas cE_Canchas):**
        // Tu Capa de Datos tiene un método ListarCancha(CE_Canchas cE_Canchas) que parece ser para filtrar,
        // pero usa ExecuteNonQuery() (lo cual es incorrecto para una consulta SELECT).
        // Si ese método se corrigiera para devolver un solo objeto CE_Canchas o List<CE_Canchas>, 
        // la Capa de Negocio tendría un método BuscarCancha(CE_Canchas filtro) similar.
    }
}