using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capa_entidad;

namespace capa_dato
{
    internal class CD_TiposReservas
    {

        CD_conexion conexion = new CD_conexion();

        public List<CE_tiposReservas> Listar() 
        {
            var ListarTiposReservas = new List<CE_tiposReservas>();

            using (var conexionAbierta = conexion.abrir_conexion())
            {
                using (var comando = new Microsoft.Data.SqlClient.SqlCommand("SP_TiposReservas_List", conexionAbierta))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            ListarTiposReservas.Add(new CE_tiposReservas
                            {
                                IdReserva = Convert.ToInt32(lector["IdReserva"]),
                                IdCancha = Convert.ToInt32(lector["IdCancha"]),
                                IdCliente = Convert.ToInt32(lector["IdCliente"]),
                                IdUsuario = Convert.ToInt32(lector["IdUsuario"]),
                                FechaReserva = Convert.ToDateTime(lector["FechaReserva"]),
                                HoraInicio = (TimeSpan)(lector["HoraInicio"]),
                                HoraFin = (TimeSpan)(lector["HoraFin"]),
                                IdEstado = Convert.ToInt32(lector["IdEstado"]),
                                Comentario = lector["Comentario"].ToString()
                            });
                        }
                    }
                }
                conexion.cerrar_conexion();
                return ListarTiposReservas;
            }

            
        }

        public void InsertarTiposReservas(CE_tiposReservas cE_tiposReservas)
        {
            using (var conexionAbierta = conexion.abrir_conexion())
            {
                using (var comando = new Microsoft.Data.SqlClient.SqlCommand("SP_TiposReservas_Insert", conexionAbierta))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdCancha", cE_tiposReservas.IdCancha);
                    comando.Parameters.AddWithValue("@IdCliente", cE_tiposReservas.IdCliente);
                    comando.Parameters.AddWithValue("@IdUsuario", cE_tiposReservas.IdUsuario);
                    comando.Parameters.AddWithValue("@FechaReserva", cE_tiposReservas.FechaReserva);
                    comando.Parameters.AddWithValue("@HoraInicio", cE_tiposReservas.HoraInicio);
                    comando.Parameters.AddWithValue("@HoraFin", cE_tiposReservas.HoraFin);
                    comando.Parameters.AddWithValue("@IdEstado", cE_tiposReservas.IdEstado);
                    comando.Parameters.AddWithValue("@Comentario", cE_tiposReservas.Comentario);
                    comando.ExecuteNonQuery();
                }
                conexion.cerrar_conexion();
            }
        }

        public void ActualizarTiposReservas(CE_tiposReservas cE_tiposReservas)
        {
            using (var conexionAbierta = conexion.abrir_conexion())
            {
                using (var comando = new Microsoft.Data.SqlClient.SqlCommand("SP_TiposReservas_Update", conexionAbierta))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdReserva", cE_tiposReservas.IdReserva);
                    comando.Parameters.AddWithValue("@IdCancha", cE_tiposReservas.IdCancha);
                    comando.Parameters.AddWithValue("@IdCliente", cE_tiposReservas.IdCliente);
                    comando.Parameters.AddWithValue("@IdUsuario", cE_tiposReservas.IdUsuario);
                    comando.Parameters.AddWithValue("@FechaReserva", cE_tiposReservas.FechaReserva);
                    comando.Parameters.AddWithValue("@HoraInicio", cE_tiposReservas.HoraInicio);
                    comando.Parameters.AddWithValue("@HoraFin", cE_tiposReservas.HoraFin);
                    comando.Parameters.AddWithValue("@IdEstado", cE_tiposReservas.IdEstado);
                    comando.Parameters.AddWithValue("@Comentario", cE_tiposReservas.Comentario);
                    comando.ExecuteNonQuery();
                }
                conexion.cerrar_conexion();
            }
        }

        public void EliminarTiposReservas(int idReserva)
        {
            using (var conexionAbierta = conexion.abrir_conexion())
            {
                using (var comando = new Microsoft.Data.SqlClient.SqlCommand("SP_TiposReservas_Delete", conexionAbierta))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdReserva", idReserva);
                    comando.ExecuteNonQuery();
                }
                conexion.cerrar_conexion();
            }
        }


    }
}
