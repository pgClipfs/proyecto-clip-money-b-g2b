using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebApplicationClip.Models
{
    class SQLcontrol
    {
        //Conexion con base de datos
        private SqlConnection cnn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=db_clip_prueba;Integrated Security=True");

        //Logeo del cliente
        public int Login(string usuario, string contraseña)
        {
            //retorno -1 en caso de error
            int retorno = -1;
            try
            {
                //abro la base de datos
                cnn.Open();

                //Cargo el procedimiento almacenado
                SqlCommand cmd = new SqlCommand("login", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Le paso los parametros
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contraseña", contraseña);


                SqlDataReader dr = cmd.ExecuteReader();

                //Me traigo la unica columna que necesito, ya que el logeo genera una sola
                if (dr.Read())
                {
                    retorno = dr.GetInt32(0);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                cnn.Close();
            }
            return retorno;
        }
        public Cliente Datos_cliente(string usuario)
        {
            Cliente retorno = null;
            try
            {
                //abro la base de datos
                cnn.Open();

                //Cargo el procedimiento almacenado
                SqlCommand cmd = new SqlCommand("datos_cliente", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Le paso los parametros
                cmd.Parameters.AddWithValue("@usuario", usuario);


                SqlDataReader dr = cmd.ExecuteReader();

                //Me traigo la unica columna que necesito, ya que el logeo genera una sola
                if (dr.Read())
                {
                    uint dni = (uint)dr.GetInt32(3);
                    uint telefono = (uint)dr.GetInt32(7);
                    retorno = new Cliente(dr.GetString(1), dr.GetString(2), dni, dr.GetDateTime(4), telefono , dr.GetString(8), dr.GetString(9), dr.GetString(10));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                cnn.Close();
            }
            return retorno;
        }

    }
}