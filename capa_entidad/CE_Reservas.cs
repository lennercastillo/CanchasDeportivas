using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_entidad
{
    public class CE_Reservas
    {
        public int IdReserva { get; set; }
        public int IdCancha { get; set; }

        public int IdCliente { get; set; }

        public int IdUsuario { get; set; }

        public DateTime FechaReserva { get; set; }

        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public string? NombreCliente { get; set; }

        public String? NombreCancha { get; set; }

        public string? Comentario { get; set; }

        public bool Estado { get; set; }
    }

    public class ReservaViewModel
    {
        public CE_Reservas Reserva { get; set; }
        public List<CE_Clientes> ListaClientes { get; set; }

        public List<CE_Canchas> ListaCanchas { get; set; }
    }

    

}
