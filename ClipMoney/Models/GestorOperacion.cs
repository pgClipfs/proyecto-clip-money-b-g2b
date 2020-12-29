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
        //private SqlConnection cnn = new SqlConnection(@"Server=DESKTOP-RL342J2;Database=db_clip;Integrated Security=True");
        private SqlConnection cnn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=db_clip;Integrated Security=True");



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

                    cmd.Parameters.AddWithValue("@id_cuenta", (int)op.Id_cuenta);
                    cmd.Parameters.AddWithValue("@monto", op.Monto);
                    cmd.Parameters.AddWithValue("@tipodeoperacion", op.Tipo);


                    if (cmd.ExecuteNonQuery() != 0) { cnn.Close(); return true; }

                    cnn.Close();

                }
                if (op.Tipo == "Extraccion") {
                    cnn.Open();


                    SqlCommand cmd = new SqlCommand("extraer_saldo", cnn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_cuenta", (int)op.Id_cuenta);
                    cmd.Parameters.AddWithValue("@monto", op.Monto);
                    cmd.Parameters.AddWithValue("@tipodeoperacion", op.Tipo);


                    if (cmd.ExecuteNonQuery() != 0) { cnn.Close(); return true; }

                    cnn.Close();
                }


            }

            return false;
        }



      
    }
}
