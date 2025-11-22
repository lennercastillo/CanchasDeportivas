using System;
using System.Collections.Generic;
using System.Linq;
using capa_entidad;
using capa_dato;
using System.Text;
using System.Threading.Tasks;
using capa_dato;
using capa_entidad;
using System.Text.RegularExpressions;

namespace capa_negocio
{
    public class CN_Clientes
    {
        
        CD_Clientes oCD_Clientes = new CD_Clientes();


        public List<CE_Clientes> Listar()
        {
           oCD_Clientes = new CD_Clientes();
           return oCD_Clientes.ListarClientes();
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