using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ClipMoney.Models
{
    public class GestorLogin
    {

        //private SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["db_clip"].ToString());
        private SqlConnection cnn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=db_clip;Integrated Security=True");
        public int validar_login(Login lg)
        {
            int conectado = 0; 
            using (cnn)
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("login", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@usuario", lg.Usuario);



                cmd.Parameters.AddWithValue("@contraseña", lg.Contraseña);

                SqlDataReader lectura = cmd.ExecuteReader();

                if (lectura.Read())
                {
                    if (lectura.GetInt32(0) != 0) conectado = lectura.GetInt32(0);
                }
                cnn.Close();
            }

            return conectado;
        }
    }
}