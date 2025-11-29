using System;
using System.Collections.Generic;
using System.Data;
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
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdCancha", cE_Canchas.IdCancha);
                    comando.Parameters.AddWithValue("@Nombre", cE_Canchas.Nombre);
                    comando.Parameters.AddWithValue("@Tipo", cE_Canchas.Tipo);
                    comando.Parameters.AddWithValue("@PrecioPorHora", cE_Canchas.PrecioPorHora);
                    
                    comando.ExecuteNonQuery();
                }
                
            }
        }


        public void EliminarCancha(int id)
        {
           
                using (SqlCommand comando = new SqlCommand("SP_Canchas_Delete ", conexion.abrir_conexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@Id", id));

                   comando.ExecuteNonQuery();

            }


                
            

        }

        public void AgregarCancha(CE_Canchas cE_Canchas)
        {
            using (var conexionAbierta = conexion.abrir_conexion())
            {
                using (var comando = new SqlCommand("SP_Canchas_Insert", conexionAbierta))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Nombre", cE_Canchas.Nombre);
                    comando.Parameters.AddWithValue("@Tipo", cE_Canchas.Tipo);
                    comando.Parameters.AddWithValue("@PrecioPorHora", cE_Canchas.PrecioPorHora);
                   
                    comando.ExecuteNonQuery();
                }
                
            }
        }

        
    }
}

