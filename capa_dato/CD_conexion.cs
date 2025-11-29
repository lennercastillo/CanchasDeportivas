using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace capa_dato
{
    public class CD_conexion
    {

        private readonly SqlConnection conexion = new SqlConnection("Data Source=JONATHANCASTILL\\SQLEXPRESS;Initial Catalog=DB_canchasdeportivas;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

        public SqlConnection abrir_conexion()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }
            return conexion;
        }

        public SqlConnection cerrar_conexion() 
        {
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
            return conexion;
        }
    }
}
