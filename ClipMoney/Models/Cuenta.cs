using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClipMoney.Models
{
    public class Cuenta
    {
        /*Requeridas*/
        private uint id;
        private int num_de_cuenta;
        private string tipo_de_cuenta;
        private string estado_de_cuenta;
        private decimal saldo;
        private long cbu;
        private long cvu;
        private int id_cliente;

        public Cuenta(
                       uint _id,
                       int num_de_cuenta,
                       string tipo_de_cuenta,
                       string estado_de_cuenta,
                       decimal saldo,
                       long cbu,
                       long cvu,
                       int id_cliente

            )
        {
            this.id = _id;
            this.num_de_cuenta = num_de_cuenta;
            this.tipo_de_cuenta = tipo_de_cuenta;
            this.estado_de_cuenta = estado_de_cuenta;
            this.saldo = saldo;
            this.cbu = cbu;
            this.cvu = cvu;
            this.id_cliente = id_cliente;




        }
        public uint Id { get => this.id; set => this.id = value; }
        public int Num_de_cuenta { get => this.num_de_cuenta; set => this.num_de_cuenta = value; }
        public string Tipo_de_cuenta { get => this.tipo_de_cuenta; set => this.tipo_de_cuenta = value; }
        public string Estado_de_cuenta { get => this.estado_de_cuenta; set => this.estado_de_cuenta = value; }
        public decimal Saldo { get => this.saldo; set => this.saldo = value; }
        public long Cbu { get => this.cbu; set => this.cbu = value; }
        public long Cvu { get => this.cvu; set => this.cvu = value; }
        public int Id_cliente { get => this.id_cliente; set => this.id_cliente = value; }
    }


}