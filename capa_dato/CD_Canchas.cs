using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capa_entidad;
using Microsoft.Data.SqlClient;

namespace capa_dato
{
    public class CD_Canchas
    {
        CD_conexion conexion = new CD_conexion();

        public List<CE_Canchas> Listar()
        {

            var ListarCanchas = new List<CE_Canchas>();

            using (var conexionAbierta = conexion.abrir_conexion())
            {
                using (var comando = new SqlCommand("SP_Canchas_List", conexionAbierta))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            ListarCanchas.Add(new CE_Canchas
                            {
                                IdCancha = Convert.ToInt32(lector["IdCancha"]),
                                Nombre = lector["Nombre"].ToString(),
                                Tipo = lector["Tipo"].ToString(),
                                PrecioPorHora = Convert.ToDecimal(lector["PrecioPorHora"]),
                                Estado = lector["Estado"].ToString()
                            });
                        }
                    }
                }
                
                return ListarCanchas;

            }




        }

        public void ActualizarCancha(CE_Canchas cE_Canchas)
        {
            using (var conexionAbierta = conexion.abrir_conexion())
            {
                using (var comando = new SqlCommand("SP_Canchas_Update", conexionAbierta))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdCancha", cE_Canchas.IdCancha);
                    comando.Parameters.AddWithValue("@Nombre", cE_Canchas.Nombre);
                    comando.Parameters.AddWithValue("@Tipo", cE_Canchas.Tipo);
                    comando.Parameters.AddWithValue("@PrecioPorHora", cE_Canchas.PrecioPorHora);
                    comando.Parameters.AddWithValue("@Estado", cE_Canchas.Estado);
                    comando.ExecuteNonQuery();
                }
                
            }
        }


        public void EliminarCancha(CE_Canchas cE_Canchas)
        {
            using (var conexionAbierta = conexion.abrir_conexion())
            {
                using (var comando = new SqlCommand("SP_Canchas_Delete", conexionAbierta))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdCancha", cE_Canchas.IdCancha);
                    comando.ExecuteNonQuery();
                }
                
            }

        }

        public void AgregarCancha(CE_Canchas cE_Canchas)
        {
            using (var conexionAbierta = conexion.abrir_conexion())
            {
                using (var comando = new SqlCommand("SP_Canchas_Add", conexionAbierta))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Nombre", cE_Canchas.Nombre);
                    comando.Parameters.AddWithValue("@Tipo", cE_Canchas.Tipo);
                    comando.Parameters.AddWithValue("@PrecioPorHora", cE_Canchas.PrecioPorHora);
                    comando.Parameters.AddWithValue("@Estado", cE_Canchas.Estado);
                    comando.ExecuteNonQuery();
                }
                
            }
        }

        public void ListarCancha(CE_Canchas cE_Canchas)
        {

            using (var conexionAbierta = conexion.abrir_conexion())
            {
                using (var comando = new SqlCommand("SP_Canchas_List", conexionAbierta))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdCancha", cE_Canchas.IdCancha);
                    comando.ExecuteNonQuery();
                }
                
            }

        }
    }
}

