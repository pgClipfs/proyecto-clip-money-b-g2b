using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;



namespace ClipMoney.Models
{
    public class GestorCuenta
    {

        //private SqlConnection cnn = new SqlConnection(@"Server=DESKTOP-RL342J2;Database=db_clip;Integrated Security=True");
        private SqlConnection cnn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=db_clip;Integrated Security=True");


        public Cuenta obtenerDatosCuenta(int id)
        {
            Cuenta datos_cuenta = null;

            using (cnn)
            {

                cnn.Open();


                SqlCommand cmd = new SqlCommand("obtenerdatos_cuenta", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_cuenta", id);

                SqlDataReader lectura = cmd.ExecuteReader();

                if (lectura.Read())
                {

                    int num_de_cuenta;
                    string tipo_de_cuenta;
                    string estado_de_cuenta;
                    Decimal saldo;
                    long cbu;
                    long cvu;
                    int id_cliente;

                    id = lectura.GetInt32(0);
                    num_de_cuenta = lectura.GetInt32(1);
                    tipo_de_cuenta = lectura.GetString(2);
                    estado_de_cuenta = lectura.GetString(3);
                    saldo = lectura.GetDecimal(4);
                    cbu = lectura.GetInt64(5);
                    cvu = lectura.GetInt64(6);
                    id_cliente = lectura.GetInt32(7);

                    datos_cuenta = new Cuenta( (uint)id,
                                               num_de_cuenta,            
                                                tipo_de_cuenta,
                                                 estado_de_cuenta,
                                                   saldo,
                                                   cbu,
                                                   cvu,
                                                   id_cliente);






                }

                cnn.Close();
        }

           return datos_cuenta;


        }

    }
}