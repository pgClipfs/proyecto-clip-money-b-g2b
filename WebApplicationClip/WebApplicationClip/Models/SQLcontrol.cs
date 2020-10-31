﻿using System;
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

    }
}