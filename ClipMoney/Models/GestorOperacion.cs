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

        //GET
        public List<Operacion> ultimos_movimientos(int id_cuenta)
        {

            List<Operacion> list_ultimas_op = new List<Operacion>();
            using (cnn)
            {


                cnn.Open();

                SqlCommand cmd = new SqlCommand("lista_ultimos_movimientos", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_cuenta", id_cuenta);

                SqlDataReader lectura = cmd.ExecuteReader();

                while (lectura.Read())
                {
                    int Origen;
                    int Destino;

                    if (!lectura.IsDBNull(1)) { Origen = lectura.GetInt32(1); } else { Origen = 0; }
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


                if (op.Tipo == "Giro_al_descubierto")
                {
                    cnn.Open();


                    SqlCommand cmd = new SqlCommand("verificar_saldo", cnn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_cuenta", op.Id_cuenta);


                    SqlDataReader lectura = cmd.ExecuteReader();
                    while (lectura.Read())
                    {
                        Decimal Saldo = lectura.GetDecimal(0);
                        String EstadoCuenta = lectura.GetString(1);
                        if (Saldo <= 0 || EstadoCuenta == "inactivo")
                        {
                            cnn.Close();
                            return false;

                        }
                        else if (Saldo > 0 && EstadoCuenta == "activo")
                        {
                            decimal LimiteGiro = Saldo/10;
                            if (op.Monto <= (Saldo + (LimiteGiro)))
                            {
                                cnn.Close(); // reinicio la conexion para realizar ExecuteNonQuery.
                                cnn.Open();

                                SqlCommand cmdb = new SqlCommand("giro_al_descubierto", cnn);
                                cmdb.CommandType = System.Data.CommandType.StoredProcedure;

                                cmdb.Parameters.AddWithValue("@id_cuenta", op.Id_cuenta);
                                cmdb.Parameters.AddWithValue("@monto", op.Monto);
                                if (cmdb.ExecuteNonQuery() != 0) { cnn.Close(); return true; }
                            }

                        }


                    }

                    cnn.Close();
                }

                return false;
            }




        }
    }
}