using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capa_entidad;
using Microsoft.Data.SqlClient;

namespace capa_dato
{
    public class CD_Clientes
    {

        CD_conexion conexion = new CD_conexion();

        public List<CE_Clientes> ListarClientes()
        {
            var ListarClientes = new List<CE_Clientes>();
            using (var conexionAbierta = conexion.abrir_conexion())
            {
                using (var comando = new Microsoft.Data.SqlClient.SqlCommand("SP_Clientes_List", conexionAbierta))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            ListarClientes.Add(new CE_Clientes
                            {
                                IdCliente = Convert.ToInt32(lector["IdCliente"]),
                                Nombre = lector["Nombre"].ToString(),
                                Telefono = lector["Telefono"].ToString(),
                                Correo = lector["Correo"].ToString(),
                                Estado = Convert.ToBoolean(lector["Estado"])
                            });
                        }
                    }
                }
                
                return ListarClientes;
            }



        }

        public void InsertarClientes (CE_Clientes cE_Clientes)
        {
            using (var conexionAbierta = conexion.abrir_conexion())
            {
                using (var comando = new SqlCommand("SP_Clientes_Insert", conexionAbierta))
                {

                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Nombre", cE_Clientes.Nombre);
                    comando.Parameters.AddWithValue("@Telefono", cE_Clientes.Telefono);
                    comando.Parameters.AddWithValue("@Correo", cE_Clientes.Correo);
                    comando.Parameters.AddWithValue("@Estado", cE_Clientes.Estado);
                    comando.ExecuteNonQuery();
                }
                
            }
        }

        public void ActualizarClientes(CE_Clientes cE_Clientes)
        {
            using (var conexionAbierta = conexion.abrir_conexion())
            {
                using (var comando = new SqlCommand("SP_Clientes_Update", conexionAbierta))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdCliente", cE_Clientes.IdCliente);
                    comando.Parameters.AddWithValue("@Nombre", cE_Clientes.Nombre);
                    comando.Parameters.AddWithValue("@Telefono", cE_Clientes.Telefono);
                    comando.Parameters.AddWithValue("@Correo", cE_Clientes.Correo);
                    comando.Parameters.AddWithValue("@Estado", cE_Clientes.Estado);
                    comando.ExecuteNonQuery();
                }
                
            }
        }

        public void EliminarClientes (int Id)
        {
            using (var conexionAbierta = conexion.abrir_conexion())
            {
                using (var comando = new SqlCommand("SP_Clientes_Delete", conexionAbierta))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@id", Id);
                    comando.ExecuteNonQuery();
                }
                
            }
        }

        


    }
}
