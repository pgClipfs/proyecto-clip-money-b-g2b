using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClipMoney.Models
{
    public class Login
    {
        private string usuario;
        private string contraseña;

        public Login(string usuario, string contraseña)
        {
            this.usuario = usuario;
            this.contraseña = contraseña;
        }

        public string Usuario { get => this.usuario; set => this.usuario = value; }
        public string Contraseña { get => this.contraseña; set => this.contraseña = value; }
    }
}