using System;
using System.Collections.Generic;
using System.Linq;
using capa_entidad;
using capa_dato;

namespace capa_negocio
{
    public class CN_Canchas
    {
        
        CD_Canchas oCD_Canchas = new CD_Canchas();

        
        public List<CE_Canchas> ListarCanchas()
        {

            oCD_Canchas = new CD_Canchas();
            return oCD_Canchas.Listar();


        }

   
        public void AgregarCancha(CE_Canchas cancha)
        {
           oCD_Canchas.AgregarCancha(cancha);
        }

        
        public void Actualizar(CE_Canchas cancha)
        {
           oCD_Canchas.ActualizarCancha(cancha);
        }

        
        public void Eliminar(int id)
        {
           oCD_Canchas.EliminarCancha(id);


        }
    }
}