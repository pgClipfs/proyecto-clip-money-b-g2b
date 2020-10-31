using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationClip.Models
{
    public class Cliente : Persona
    {
        private string usuario;
        private string contraseña;

        public Cliente(string Nombre,
                       string Apellido,
                       uint Dni,
                       DateTime Fecha_de_Nacimiento,
                       uint Telefono,
                       string Email,
                       string Usuario,
                       string Contraseña) : base(Nombre, Apellido, Dni, Fecha_de_Nacimiento, Telefono, Email)
        {
            this.usuario = Usuario;
            this.contraseña = Contraseña;
        }
        //La idea es que no se pueda cambiar el usuario ya que es su identificador
        public string Usuario
        {
            get
            {
                return this.usuario;
            }
        }
        public void cambiar_contraseña(string contraseña_actual, string nueva_contraseña)
        {
            if (contraseña_actual != this.contraseña) Console.WriteLine("Contraseña actual erronea");
            else
            {
                this.contraseña = nueva_contraseña;
            }
        }


    }
}