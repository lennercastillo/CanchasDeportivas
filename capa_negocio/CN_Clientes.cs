using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using capa_dato;
using capa_dato;
using capa_entidad;
using capa_entidad;

namespace capa_negocio
{
    public class CN_Clientes
    {
        
        CD_Clientes oCD_Clientes = new CD_Clientes();


        public List<CE_Clientes> Listar()
        {
            List<CE_Clientes> lista = oCD_Clientes.ListarClientes();
            //oCD_Clientes = new CD_Clientes();
            if (lista == null)
            {
                return new List<CE_Clientes>();
            }
            return lista;
        }

        // 2. Insertar Nuevo Cliente
        public void Insertar(CE_Clientes cliente)
        {
            oCD_Clientes.InsertarClientes(cliente);
        }

        // 3. Actualizar Cliente
        public void Actualizar(CE_Clientes cliente)
        {
            oCD_Clientes.ActualizarClientes(cliente);
        }

        // 4. Eliminar Cliente
        public void Eliminar(int id)
        {
            oCD_Clientes.EliminarClientes(id);
        }
    }
}