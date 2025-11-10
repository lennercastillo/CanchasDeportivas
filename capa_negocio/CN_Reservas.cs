using System;
using System.Collections.Generic;
using System.Linq;
using capa_entidad;
using capa_dato;

namespace capa_negocio
{
    public class CN_Reservas
    {
        // Instancia de la Capa de Datos para ejecutar operaciones en la DB
        private CD_Reservas oCD_Reservas = new CD_Reservas();

        // 1. Método para Listar (Listar es el nombre más adecuado, no 'Insertar')
        public List<CE_Reservas> Listar()
        {
            try
            {
                // Llama al método Listar de la Capa de Datos
                // Nota: En tu código de datos, el método se llama 'Insertar()', 
                // pero realiza una lista (SP_Reservas_List). Lo llamamos 'Listar' aquí para ser claro.
                return oCD_Reservas.Insertar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de reservas: " + ex.Message);
            }
        }

        // 2. Método para Agregar (Insertar) una nueva reserva
        public void Agregar(CE_Reservas reserva)
        {
            // ** LÓGICA DE NEGOCIO Y VALIDACIONES **
            // ------------------------------------------------------------------

            // Validación de IDs obligatorios
            if (reserva.IdCancha <= 0)
            {
                throw new ArgumentException("Debe especificar la Cancha a reservar.");
            }
            if (reserva.IdCliente <= 0)
            {
                throw new ArgumentException("Debe especificar el Cliente que realiza la reserva.");
            }

            // Validación de fechas y horas
            if (reserva.FechaReserva.Date < DateTime.Now.Date)
            {
                throw new ArgumentException("No se pueden crear reservas para fechas pasadas.");
            }
            if (reserva.HoraInicio >= reserva.HoraFin)
            {
                throw new ArgumentException("La Hora de Inicio debe ser anterior a la Hora de Fin.");
            }

            // ** VALIDACIÓN CRÍTICA: VERIFICAR DISPONIBILIDAD DE HORARIO **
            // Aquí iría la lógica para asegurarse de que la cancha no esté ocupada
            // en el rango de (FechaReserva, HoraInicio, HoraFin).
            // Esto requeriría agregar un método en CD_Reservas para consultar horarios.
            // if (!VerificarDisponibilidad(reserva)) { throw new Exception("La cancha no está disponible."); }

            // ------------------------------------------------------------------

            try
            {
                oCD_Reservas.InsertarReserva(reserva);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la reserva: " + ex.Message);
            }
        }

        // 3. Método para Actualizar una reserva
        public void Actualizar(CE_Reservas reserva)
        {
            // ** LÓGICA DE NEGOCIO Y VALIDACIONES **
            // ------------------------------------------------------------------
            if (reserva.IdReserva <= 0)
            {
                throw new ArgumentException("El Id de Reserva es obligatorio para la actualización.");
            }

            // Se repetirían algunas validaciones de 'Agregar', como fechas y horas.
            // Podría haber una regla aquí que impida cambiar la fecha si la reserva es inminente (ej. en 1 hora).
            // ------------------------------------------------------------------

            try
            {
                oCD_Reservas.ActualizarReserva(reserva);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la reserva: " + ex.Message);
            }
        }

        // 4. Método para Eliminar una reserva
        public void Eliminar(CE_Reservas reserva)
        {
            // ** LÓGICA DE NEGOCIO Y VALIDACIONES **
            // ------------------------------------------------------------------
            if (reserva.IdReserva <= 0)
            {
                throw new ArgumentException("El Id de Reserva es obligatorio para la eliminación.");
            }

            // Regla de Negocio: Podrías prohibir la eliminación si la fecha de reserva ya pasó
            // o aplicar políticas de cancelación (ej. cobrar una multa si se cancela con poca antelación).
            // ------------------------------------------------------------------

            try
            {
                oCD_Reservas.EliminarReserva(reserva);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la reserva: " + ex.Message);
            }
        }
    }
}