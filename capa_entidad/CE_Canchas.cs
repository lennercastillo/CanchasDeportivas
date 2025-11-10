using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace capa_entidad
{
    public class CE_Canchas
    {
        public int IdCancha { get; set; }
        public string? Nombre { get; set; }
        public string? Tipo { get; set; }
        public decimal PrecioPorHora { get; set; }
        public string? Estado { get; set; }
    }

    public class CE_EstadosReservas
    {
        public int IdEstado { get; set; }
        public bool Estado { get; set; }
    }

    




   



}

