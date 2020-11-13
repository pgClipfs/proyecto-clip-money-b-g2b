using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ClipMoney.Models
{
    public class GestorCliente
    {

        private SqlConnection cnn = new SqlConnection( ConfigurationManager.ConnectionStrings["db_clip"].ToString() );
        //GET
        public Cliente obtener_cliente (uint id)
        {

            Cliente nuevo_cliente = null;
            using (cnn) {


                cnn.Open();

                SqlCommand cmd = new SqlCommand("obtener_cliente", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
        
                cmd.Parameters.AddWithValue("@id", (int)id);

                SqlDataReader lectura = cmd.ExecuteReader();

                if (lectura.Read())
                {
                    nuevo_cliente = new Cliente((uint)lectura.GetInt32(0),      //ID
                                                        lectura.GetString(1),           //NOMBRE
                                                        lectura.GetString(2),           //APELLIDO
                                                        lectura.GetString(5),           //TELEFONO
                                                        lectura.GetString(4),           //EMAIL
                                                        lectura.GetString(10),          //USUARIO
                                                        lectura.GetString(11),          //CONTRASEÑA
                                                        (uint)lectura.GetInt32(3),      //DNI
                                                        (uint)lectura.GetInt32(6),      //CUIL
                                                        lectura.GetString(7),           //DIRECCION
                                                        lectura.GetString(8),           //NACIONALIDAD
                                                        lectura.GetString(9),           //SEXO
                                                        lectura.GetString(12));         //SITUACION CREDITICIA

                }

                cnn.Close();
            }
            return nuevo_cliente;
        }
        //GET
        public int validar_usuario(string usuario)
        {
            SqlConnection cnnu = new SqlConnection(ConfigurationManager.ConnectionStrings["db_clip"].ToString());
            using (cnnu)
            {

                cnnu.Open();

                SqlCommand cmd = new SqlCommand("verificar_usuario", cnnu);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@usuario", usuario);

                SqlDataReader lectura = cmd.ExecuteReader();

                if (lectura.Read())
                {

                    int res = lectura.GetInt32(0);
                    cnnu.Close();
                    if (res != 0) return res;
                    return 0;


                }
                cnnu.Close();

            }
            return 0;
        }

        //PUT
        public bool actualizar_cliente(Cliente clt)
        {

            if (validar_usuario(clt.Usuario) != 0) return false;
            using (cnn)
            {

                cnn.Open();

                SqlCommand cmd = new SqlCommand("actualizar_cliente", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id",(int) clt.ID);
                cmd.Parameters.AddWithValue("@nombre", clt.Nombre);
                cmd.Parameters.AddWithValue("@apellido", clt.Apellido);
                cmd.Parameters.AddWithValue("@dni", (int)clt.Dni);
                cmd.Parameters.AddWithValue("@email", clt.Email);
                cmd.Parameters.AddWithValue("@telefono", clt.Telefono);
                cmd.Parameters.AddWithValue("@cuil", (int) clt.Cuil);
                cmd.Parameters.AddWithValue("@direccion", clt.Direccion);
                cmd.Parameters.AddWithValue("@nacionalidad", clt.Nacionalidad);
                cmd.Parameters.AddWithValue("@sexo", clt.Sexo);
                cmd.Parameters.AddWithValue("@usuario", clt.Usuario);
                cmd.Parameters.AddWithValue("@situacion_crediticia", clt.Sitacion_crediticia);

                if (cmd.ExecuteNonQuery() != 0) { cnn.Close(); return true; }

                cnn.Close();

            }

                    return false;
        }

        //POST
        public bool crear_cliente (Cliente clt)
        {
            if (validar_usuario(clt.Usuario) != 0) return false;
            using (cnn)
            {
                
                cnn.Open();

                SqlCommand cmd = new SqlCommand("nuevo_cliente", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre", clt.Nombre);
                cmd.Parameters.AddWithValue("@apellido", clt.Apellido);
                cmd.Parameters.AddWithValue("@dni", (int)clt.Dni);
                cmd.Parameters.AddWithValue("@email", clt.Email);
                cmd.Parameters.AddWithValue("@telefono", clt.Telefono);
                cmd.Parameters.AddWithValue("@usuario", clt.Usuario);
                cmd.Parameters.AddWithValue("@clave", clt.Contraseña);

                if (cmd.ExecuteScalar() == null) { cnn.Close(); return true; }

                cnn.Close();
            }

            return false;
        }









    }
}