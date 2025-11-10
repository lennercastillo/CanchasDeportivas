using System;
using System.Collections.Generic;
using capa_entidad;
using capa_dato;
using System.Linq;

namespace capa_negocio
{
    public class CN_TiposReservas
    {
        // Instancia de la Capa de Datos para ejecutar operaciones en la DB
        private CD_TiposReservas oCD_TiposReservas = new CD_TiposReservas();

        // 1. Método para Listar todas las reservas
        public List<CE_tiposReservas> ListarReservas()
        {
            try
            {
                // La capa de negocio solo actúa como pasarela para el listado simple
                return oCD_TiposReservas.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la Capa de Negocio al listar reservas: " + ex.Message);
            }
        }

        // 2. Método para Insertar una nueva reserva
        public void Insertar(CE_tiposReservas reserva)
        {
            // ** LÓGICA DE NEGOCIO Y VALIDACIONES **
            // ------------------------------------------------------------------

            // Validación de IDs obligatorios
            if (reserva.IdCancha <= 0 || reserva.IdCliente <= 0 || reserva.IdUsuario <= 0 || reserva.IdEstado <= 0)
            {
                throw new ArgumentException("Todos los campos de identificación (Cancha, Cliente, Usuario, Estado) son obligatorios.");
            }

            // Validación de fechas y horas
            if (reserva.FechaReserva.Date < DateTime.Now.Date)
            {
                throw new ArgumentException("No se pueden crear reservas para fechas pasadas.");
            }
            if (reserva.HoraInicio.TotalMinutes <= 0 || reserva.HoraFin.TotalMinutes <= 0 || reserva.HoraInicio >= reserva.HoraFin)
            {
                throw new ArgumentException("El horario de la reserva es inválido. La hora de inicio debe ser anterior a la hora de fin.");
            }

            // ** Validación Crítica (Requiere un método adicional en CD_TiposReservas): **
            // Aquí iría la lógica para llamar a un método de la Capa de Datos 
            // que verifique si la cancha ya está ocupada en el rango de tiempo solicitado.
            // Ejemplo: if (oCD_TiposReservas.CanchaOcupada(reserva)) { throw new Exception("La cancha no está disponible en el horario seleccionado."); }
            // ------------------------------------------------------------------

            try
            {
                oCD_TiposReservas.InsertarTiposReservas(reserva);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar la reserva: " + ex.Message);
            }
        }

        // 3. Método para Actualizar una reserva
        public void Actualizar(CE_tiposReservas reserva)
        {
            // ** LÓGICA DE NEGOCIO Y VALIDACIONES **
            // ------------------------------------------------------------------
            if (reserva.IdReserva <= 0)
            {
                throw new ArgumentException("El Id de Reserva es obligatorio para la actualización.");
            }

            // Repetir validación de horario (Inicio < Fin)
            if (reserva.HoraInicio >= reserva.HoraFin)
            {
                throw new ArgumentException("El horario de la reserva es inválido.");
            }

            // Regla de Negocio: Se podría validar que no se pueda cambiar el estado 
            // a 'Cancelada' si ya se pagó completamente, a menos que un administrador lo autorice.
            // ------------------------------------------------------------------

            try
            {
                oCD_TiposReservas.ActualizarTiposReservas(reserva);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la reserva: " + ex.Message);
            }
        }

        // 4. Método para Eliminar una reserva
        public void Eliminar(int idReserva)
        {
            // ** LÓGICA DE NEGOCIO Y VALIDACIONES **
            // ------------------------------------------------------------------
            if (idReserva <= 0)
            {
                throw new ArgumentException("El Id de Reserva es obligatorio para la eliminación.");
            }

            // Regla de Negocio: Verificar si hay una penalidad de cancelación.
            // Si la reserva es muy próxima, se podría requerir confirmación administrativa.
            // ------------------------------------------------------------------

            try
            {
                oCD_TiposReservas.EliminarTiposReservas(idReserva);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la reserva: " + ex.Message);
            }
        }
    }
}