using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace ClipMoney.Models
{
    public class GestorOperacion
    {
       

        private SqlConnection cnn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=db_clip;Integrated Security=True");

        //GET
        public List<Operacion> ultimos_movimientos(int num_de_cuenta)
        {

            List<Operacion> list_ultimas_op = new List<Operacion>();
            using (cnn)
            {


                cnn.Open();

                SqlCommand cmd = new SqlCommand("lista_ultimos_movimientos", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@num_de_cuenta", num_de_cuenta);

                SqlDataReader lectura = cmd.ExecuteReader();

                while (lectura.Read())
                {
                    int Origen;
                    int Destino;

                    if (!lectura.IsDBNull(1) ) {  Origen = lectura.GetInt32(1); } else { Origen = 0; }
                    if (!lectura.IsDBNull(2))
                    {
                        Destino = lectura.GetInt32(2);

                    }
                    else { Destino = 0; }
                    uint _id = (uint)lectura.GetInt32(0);
                    Decimal Monto = lectura.GetDecimal(3);
                    DateTime Fecha = lectura.GetDateTime(4);
                    string Tipo = lectura.GetString(5);
                    int Id_cuenta = lectura.GetInt32(6);

                    Operacion op = new Operacion(_id,
                                                  Monto,
                                                  Fecha,
                                                   Tipo,
                                                   Id_cuenta,
                                                   Destino,
                                                   Origen

                        );

                    list_ultimas_op.Add(op);



                }

                cnn.Close();
            }
            return list_ultimas_op;
        }

        //PUT
        public bool operaciones_saldo(Operacion op)
        {


            using (cnn)
            {
                if (op.Tipo == "Ingreso")
                {
                    cnn.Open();


                    SqlCommand cmd = new SqlCommand("depositar_saldo", cnn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_cuenta", op.Id_cuenta);
                    cmd.Parameters.AddWithValue("@monto", op.Monto);
                    
                    



                    if (cmd.ExecuteNonQuery() != 0) { cnn.Close(); return true; }

                    cnn.Close();

                }
                if (op.Tipo == "Extraccion")
                {
                    cnn.Open();


                    SqlCommand cmd = new SqlCommand("extraer_saldo", cnn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_cuenta", op.Id_cuenta);
                    cmd.Parameters.AddWithValue("@monto", op.Monto);
                   



                    if (cmd.ExecuteNonQuery() != 0) { cnn.Close(); return true; }

                    cnn.Close();
                }


            }

            return false;
        }




    }
}
