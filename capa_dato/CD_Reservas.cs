using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capa_entidad;
using Microsoft.Data.SqlClient;

namespace capa_dato
{
    public class CD_Reservas
    {

        CD_conexion conexion = new CD_conexion();

        public List<CE_Reservas> Listar()
        {
            var ListarReserva = new List<CE_Reservas>();

            using (var conexionAbierta = conexion.abrir_conexion())
            {
                using (var comando = new SqlCommand("SP_Reservas_List", conexionAbierta))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            ListarReserva.Add(new CE_Reservas
                            {
                                IdReserva = Convert.ToInt32(lector["IdReserva"]),
                                IdCancha = Convert.ToInt32(lector["IdCancha"]),
                                IdCliente = Convert.ToInt32(lector["IdCliente"]),
                                IdUsuario = Convert.ToInt32(lector["IdUsuario"]),
                                FechaReserva = Convert.ToDateTime(lector["FechaReserva"]),
                                HoraInicio = (TimeSpan)(lector["HoraInicio"]),
                                HoraFin = (TimeSpan)(lector["HoraFin"]),
                                NombreCliente = lector["NombreCliente"].ToString(),
                                Comentario = lector["Comentario"].ToString(),
                                Estado = Convert.ToBoolean(lector["Estado"])

                            });
                        }
                    }
                }
                conexion.cerrar_conexion();
                return ListarReserva;
            }


        }

        public void InsertarReserva(CE_Reservas cE_Reservas)
        {
            using (var conexionAbierta = conexion.abrir_conexion())
            {
                using (var comando = new SqlCommand("SP_Reservas_Insert", conexionAbierta))
                {


                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@IdCancha", cE_Reservas.IdCancha);
                    comando.Parameters.AddWithValue("@IdCliente", cE_Reservas.IdCliente);
                    comando.Parameters.AddWithValue("@IdUsuario", cE_Reservas.IdUsuario);
                    comando.Parameters.AddWithValue("@FechaReserva", cE_Reservas.FechaReserva);
                    comando.Parameters.AddWithValue("@HoraInicio", cE_Reservas.HoraInicio);
                    comando.Parameters.AddWithValue("@HoraFin", cE_Reservas.HoraFin);
                    comando.Parameters.AddWithValue("@NombreCliente", cE_Reservas.NombreCliente);
                    comando.Parameters.AddWithValue("@Comentario", cE_Reservas.Comentario);
                    comando.Parameters.AddWithValue("@Estado", cE_Reservas.Estado);
                    




                    comando.ExecuteNonQuery();



                    comando.ExecuteNonQuery();
                }
                

            }

        }

        public void ActualizarReserva(CE_Reservas cE_Reservas)
        {
            using (var conexionAbierta = conexion.abrir_conexion())
            {
                using (var comando = new SqlCommand("SP_Reservas_Update", conexionAbierta))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdReserva", cE_Reservas.IdReserva);
                    comando.Parameters.AddWithValue("@IdCancha", cE_Reservas.IdCancha);
                    comando.Parameters.AddWithValue("@IdCliente", cE_Reservas.IdCliente);
                    comando.Parameters.AddWithValue("@IdUsuario", cE_Reservas.IdUsuario);
                    comando.Parameters.AddWithValue("@FechaReserva", cE_Reservas.FechaReserva);
                    comando.Parameters.AddWithValue("@HoraInicio", cE_Reservas.HoraInicio);
                    comando.Parameters.AddWithValue("@HoraFin", cE_Reservas.HoraFin);
                    comando.Parameters.AddWithValue("NombreCliente", cE_Reservas.NombreCliente);
                    comando.Parameters.AddWithValue("@Comentario", cE_Reservas.Comentario);
                    comando.Parameters.AddWithValue("@Estado", cE_Reservas.Estado);
                    comando.ExecuteNonQuery();
                }
                
            }
        }

        public void EliminarReserva(int id)
        {
            using (var conexionAbierta = conexion.abrir_conexion())
            {
                using (var comando = new SqlCommand("SP_Reservas_Delete", conexionAbierta))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id", id);
                    comando.ExecuteNonQuery();
                }
                
            }
        }

        

    }

}




