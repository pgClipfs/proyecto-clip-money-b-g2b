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

        //private SqlConnection cnn = new SqlConnection( ConfigurationManager.ConnectionStrings["db_clip"].ToString() );
        private SqlConnection cnn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=db_clip;Integrated Security=True");
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
                    uint dni;
                    uint cuil;
                    string dir;
                    string nac;
                    string sexo;
                    string sc;

                    if (!lectura.IsDBNull(3)) { dni = (uint)lectura.GetInt32(3); } else { dni = 0; }
                    if (!lectura.IsDBNull(6)) { cuil = (uint)lectura.GetInt32(6); } else  {cuil = 0; }
                    if (!lectura.IsDBNull(7)) { dir = lectura.GetString(7); } else { dir = null; }
                    if (!lectura.IsDBNull(8)) { nac = lectura.GetString(8); } else { nac = null; }
                    if (!lectura.IsDBNull(9)) { sexo = lectura.GetString(9); } else { sexo = null; }
                    if (!lectura.IsDBNull(12)) { sc = lectura.GetString(12); } else { sc = null; }

                    nuevo_cliente = new Cliente((uint)lectura.GetInt32(0),              //ID
                                                        lectura.GetString(1),           //NOMBRE
                                                        lectura.GetString(2),           //APELLIDO
                                                        lectura.GetString(5),           //TELEFONO
                                                        lectura.GetString(4),           //EMAIL
                                                        lectura.GetString(10),          //USUARIO
                                                        lectura.GetString(11),          //CONTRASEÑA
                                                        dni,                            //DNI
                                                        cuil,                           //CUIL
                                                        dir,//DIRECCION
                                                        nac,//NACIONALIDAD
                                                        sexo, //SEXO
                                                        sc);      //SITUACION CREDITICIA





                }

                cnn.Close();
            }
            return nuevo_cliente;
        }
        //GET
        public int validar_usuario(string usuario,string email)
        {
            SqlConnection cnnu = new SqlConnection(@"Server=.\SQLEXPRESS;Database=db_clip;Integrated Security=True");
            using (cnnu)
            {

                cnnu.Open();

                SqlCommand cmd = new SqlCommand("verificar_usuario", cnnu);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@email", email);

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

            
            using (cnn)
            {

                cnn.Open();

                SqlCommand cmd = new SqlCommand("actualizar_cliente", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id",(int) clt.ID);
                cmd.Parameters.AddWithValue("@nombre", clt.Nombre);
                cmd.Parameters.AddWithValue("@apellido", clt.Apellido);              
                cmd.Parameters.AddWithValue("@email", clt.Email);
                cmd.Parameters.AddWithValue("@telefono", clt.Telefono);
                cmd.Parameters.AddWithValue("@usuario", clt.Usuario);

                if (cmd.ExecuteNonQuery() != 0) { cnn.Close(); return true; }

                cnn.Close();

            }

                    return false;
        }

        //POST
        public bool crear_cliente (Cliente clt)
        {
            if (validar_usuario(clt.Usuario, clt.Email) != 0) return false;
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

        public bool cambiar_contraseña(Cliente clt)
        {
            using (cnn)
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("restablecer_contraseña", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", (int)clt.ID);
                cmd.Parameters.AddWithValue("@contraseña", clt.Contraseña);

                if (cmd.ExecuteNonQuery() != 0) { cnn.Close(); return true; }

                cnn.Close();

            }

                return false;
        }

        public bool cargar_documento(int id,Cliente clt)
        {
            using (cnn)
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("cargar_documento", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", (int)id);
                cmd.Parameters.AddWithValue("@image", clt.Img_doc);

                if (cmd.ExecuteNonQuery() != 0) { cnn.Close(); return true; }

                cnn.Close();
            }
            return false;
        }
        public bool existe_documento(int id)
        {
            using (cnn)
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("existe_documento", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", (int)id);

                SqlDataReader lectura = cmd.ExecuteReader();

                
                if (lectura.Read())
                {
                    if (!lectura.IsDBNull(0)) {
                        cnn.Close();
                        return true; 
                    }
                    
                }

                    cnn.Close();
            }
            return false;
        }








    }
}