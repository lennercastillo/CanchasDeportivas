using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capa_entidad;


namespace capa_dato
{
    public class CD_Usuarios
    {

        CD_conexion conexion = new CD_conexion();

        public List<CE_usuarios> ListarUsuarios()
        {
            var ListarUsuarios = new List<CE_usuarios>();
            using (var conexionAbierta = conexion.abrir_conexion())
            {
                using (var comando = new Microsoft.Data.SqlClient.SqlCommand("SP_Usuarios_List", conexionAbierta))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            ListarUsuarios.Add(new CE_usuarios
                            {
                                IdUsuario = Convert.ToInt32(lector["IdUsuario"]),
                                Nombre = lector["Nombre"].ToString(),
                                Clave = lector["Clave"].ToString(),      
                                Estado = Convert.ToBoolean(lector["Estado"])
                            });
                        }
                    }
                }
                conexion.cerrar_conexion();
                return ListarUsuarios;
            }
        }

        public void InsertarUsuarios(CE_usuarios cE_usuarios)
        {
            using (var conexionAbierta = conexion.abrir_conexion())
            {
                using (var comando = new Microsoft.Data.SqlClient.SqlCommand("SP_Usuarios_Insert", conexionAbierta))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@NombreUsuario", cE_usuarios.Nombre);
                    comando.Parameters.AddWithValue("@Contrasena", cE_usuarios.Clave);                    
                    comando.Parameters.AddWithValue("@Estado", cE_usuarios.Estado);
                    comando.ExecuteNonQuery();
                }
                conexion.cerrar_conexion();
            }
        }

        public void ActualizarUsuarios(CE_usuarios cE_usuarios)
        {
            using (var conexionAbierta = conexion.abrir_conexion())
            {
                using (var comando = new Microsoft.Data.SqlClient.SqlCommand("SP_Usuarios_Update", conexionAbierta))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdUsuario", cE_usuarios.IdUsuario);
                    comando.Parameters.AddWithValue("@NombreUsuario", cE_usuarios.Nombre);
                    comando.Parameters.AddWithValue("@Contrasena", cE_usuarios.Clave);                    
                    comando.Parameters.AddWithValue("@Estado", cE_usuarios.Estado);
                    comando.ExecuteNonQuery();
                }
                conexion.cerrar_conexion();
            }
        }

        public void EliminarUsuarios(int idUsuario)
        {
            using (var conexionAbierta = conexion.abrir_conexion())
            {
                using (var comando = new Microsoft.Data.SqlClient.SqlCommand("SP_Usuarios_Delete", conexionAbierta))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    comando.ExecuteNonQuery();
                }
                conexion.cerrar_conexion();
            }
        }



    }
}

