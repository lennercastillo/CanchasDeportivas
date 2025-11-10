using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_entidad
{
    public class CE_usuarios
    {
        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Clave { get; set; }
        public bool Estado { get; set; }
    }

}
