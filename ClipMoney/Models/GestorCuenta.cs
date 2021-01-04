﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;



namespace ClipMoney.Models
{
    public class GestorCuenta
    {
        private SqlConnection cnn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=db_clip;Integrated Security=True");


        public Cuenta obtenerDatosCuenta(int num_de_cuenta)
        {
            Cuenta datos_cuenta = null;

            using (cnn)
            {

                cnn.Open();


                SqlCommand cmd = new SqlCommand("obtenerdatos_cuenta", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@num_de_cuenta", num_de_cuenta);

                SqlDataReader lectura = cmd.ExecuteReader();

                if (lectura.Read())
                {

                    int id;
                    string tipo_de_cuenta;
                    string estado_de_cuenta;
                    Decimal saldo;
                    long cbu;
                    long cvu;
                    int id_cliente;

                    id = lectura.GetInt32(0);
                    tipo_de_cuenta = lectura.GetString(1);
                    estado_de_cuenta = lectura.GetString(2);
                    saldo = lectura.GetDecimal(3);
                    cbu = lectura.GetInt64(4);
                    cvu = lectura.GetInt64(5);
                    id_cliente = lectura.GetInt32(6);

                    datos_cuenta = new Cuenta((uint)id,
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

        public bool crear_cuenta(Cuenta cuenta)
        {
            cnn.Open();

            SqlCommand cmd = new SqlCommand("nueva_cuenta", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            
            cmd.Parameters.AddWithValue("@Num_de_cuenta", (int)cuenta.Num_de_cuenta);
            cmd.Parameters.AddWithValue("@Tipo_de_cuenta", cuenta.Tipo_de_cuenta);
            cmd.Parameters.AddWithValue("@Estado_de_cuenta", cuenta.Estado_de_cuenta);
            cmd.Parameters.AddWithValue("@Saldo", cuenta.Saldo);
            cmd.Parameters.AddWithValue("@Cbu", cuenta.Cbu);
            cmd.Parameters.AddWithValue("@Cvu", cuenta.Cvu);
            cmd.Parameters.AddWithValue("@Id_cliente", cuenta.Id_cliente);

            if (cmd.ExecuteScalar() == null) { cnn.Close(); return true; }

            cnn.Close();
            return false;
        }

    }
}