using System;
using System.Collections.Generic;
using System.Linq;
using capa_entidad;
using capa_dato;


namespace capa_negocio
{
    public class CN_Reservas
    {
        
        CD_Reservas oCD_Reservas = new CD_Reservas();

        
        public List<CE_Reservas> Listar()
        {
            oCD_Reservas = new CD_Reservas();
            return oCD_Reservas.Listar();
        }


        //public void InsertarReservas(CE_Reservas reserva)
        //{

        //    oCD_Reservas.InsertarReserva(reserva);


        //}
        public void InsertarReservas( ReservaViewModel reserva)
        {

            oCD_Reservas.InsertarReserva(reserva);


        }

        public void Actualizar(CE_Reservas reserva)
        {

            oCD_Reservas.ActualizarReserva(reserva);
        }

        
        public void Eliminar(int id)
        {
           oCD_Reservas.EliminarReserva(id);

        }

        //metodo filtrar por nombre

        public List<CE_Reservas> ListarNombre(string BuscarNombreReserva) 
        {
            return oCD_Reservas.ListarNombre(BuscarNombreReserva);
        }
    }
}