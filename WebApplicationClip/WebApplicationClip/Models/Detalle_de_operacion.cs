using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 

namespace WebApplicationClip.Models
{
    public class detalle_de_operacion
    {
        string Fecha; //Realmente necesario ?
        int id_cuenta;
        int id_operacion; //Realmente necesario ?

        public detalle_de_operacion(int id_cuenta)
        {
            this.id_cuenta = id_cuenta;
        }
        public void cargar_operacion(Operaciones operacion) {
            string fecha = (DateTime.Today).ToString(); // Fecha actual
            int numero_de_operacion; //random, sigue alguna logica ?
      
            //INSERT INTO detalle_de_cuenta (id_cuenta, operacion.id, numero_de_operacion )
            //Comunicacion con base de datos, cargo
        }
        public string obtener_operacion(DateTime fecha_inicio, DateTime fecha_fin, int id_operacion = -1 ,string tipo = "*")
        {
            //Defino la estructura de los datos de la siguiente manera
            // "id_cuenta id_operacion monto tipo fecha"
            //Luego solo queda hacer un split con el espacio para separar los datos y mostrarlos
            string datos ="";
            if (id_operacion == -1)
            {
                //conexion y devolucion de datos de sql
                //select 
            }
            else
            {
                //conexion y devolucion de dato de operacion id_opracion de sql
            }

            while(/*mientras existan filas*/false) { 
                //se cargan los string en datos
            }

            return datos;
        }
    }

}