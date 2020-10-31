using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationClip.Models
{
    public class Persona
    {
        //Atributos de la clase

        private string nombre;
        private string apellido;
        private uint dni;
        private DateTime fecha_de_nacimiento;
        private string domicilio;   //si es para billetera virtual no es necesario
        private int cuil;           //idem
        private uint telefono;
        private string email;

        //Metedos de la clase

        //Metodo de inicio
        public Persona(string Nombre,
                       string Apellido,
                       uint Dni,
                       DateTime Fecha_de_Nacimiento,
                       uint Telefono,
                       string Email)
        {
            this.nombre = Nombre;
            this.apellido = Apellido;
            this.dni = Dni;
            this.fecha_de_nacimiento = Fecha_de_Nacimiento;
            this.telefono = Telefono;
            this.email = Email;
        }
        //Propiedad de Nombre
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }
        //Propiedad de Apellido
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = value;
            }
        }
        //Propiedad de Dni
        public uint Dni
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = value;
            }
        }
        //Propiedad de Fecha de Nacimiento
        public DateTime Fecha_de_Nacimiento
        {
            get
            {
                return this.fecha_de_nacimiento;
            }
            set
            {
                this.fecha_de_nacimiento = value;
            }
        }
        //Propiedad de Domicilio
        public string Domicilio
        {
            get
            {
                return this.domicilio;
            }
            set
            {
                this.domicilio = value;
            }
        }
        //Propiedad de Cuil
        public int Cuil
        {
            get
            {
                return this.cuil;
            }
            set
            {
                this.cuil = value;
            }
        }
        //Propiedad de Telefono
        public uint Telefono
        {
            get
            {
                return this.telefono;
            }
            set
            {
                this.telefono = value;
            }
        }
        //Propiedad de Domicilio
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }


    }
}