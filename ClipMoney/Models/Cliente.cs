using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClipMoney.Models
{
    public class Cliente
    {

        //Requeridas
        private uint id;
        private string nombre;
        private string apellido;
        private string telefono;
        private string email;
        private string usuario;
        private string contraseña;

        //Opcionales
        private uint dni;
        private uint cuil;
        private string direccion;
        private string nacionalidad;
        private string sexo;
        private string situacion_crediticia;

        public Cliente(
                        /*Requeridas*/
                        uint Id ,
                        string Nombre,
                        string Apellido,
                        string Telefono,
                        string Email,
                        string Usuario,
                        string Contraseña,

                        /*Opcionales*/
                        uint Dni = 0,
                        uint Cuil = 0,
                        string Direccion = null,
                        string Nacionalidad = null,
                        string Sexo = null,
                        string Situacion_crediticia = null
            ) 
        {
            this.id = Id;
            this.nombre = Nombre;
            this.apellido = Apellido;
            this.telefono = Telefono;
            this.email = Email;
            this.usuario = Usuario;
            this.contraseña = Contraseña;

            this.dni = Dni;
            this.cuil = Cuil;
            this.direccion = Direccion;
            this.nacionalidad = Nacionalidad;
            this.sexo = Sexo;
            this.situacion_crediticia = Situacion_crediticia;
        }
        public uint ID { get => this.id; set => this.id = value; }
        public string Nombre { get => this.nombre; set => this.nombre = value; }
        public string Usuario{ get => this.usuario; set => this.usuario = value; }
        public string Apellido { get => this.apellido; set => this.apellido = value; }
        public string Telefono { get => this.telefono; set => this.telefono = value; }
        public string Email { get => this.email; set => this.email = value; }
        public uint Dni { get => this.dni; set => this.dni = value; }
        public uint Cuil { get => this.cuil; set => this.cuil = value; }
        public string Direccion { get => this.direccion; set => this.direccion = value; }
        public string Nacionalidad { get => this.nacionalidad; set => this.nacionalidad = value; }
        public string Sexo { get => this.sexo; set => this.sexo = value; }

        public string Contraseña { get => this.contraseña; set => this.contraseña = value; }
        public string Sitacion_crediticia { get => this.situacion_crediticia; set => this.situacion_crediticia = value; }


    }
}