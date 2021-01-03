﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClipMoney.Models
{
    public class Operacion
    {
        /*Requeridas*/
        private uint id;
        private Decimal monto;
        private DateTime fecha;
        private string tipo;
        private int id_cuenta;


        /*Opcionales*/
        private int origen;
        private int destino;

      
        public Operacion(  /*Requeridas*/
                           uint _id,
                           Decimal Monto,
                           DateTime Fecha,
                           string Tipo,
                           int Id_cuenta,

                          /*Opcionales*/
                          int Origen,
                          int Destino
                          )
        {
            this.id = _id;
            this.monto = Monto;
            this.fecha = Fecha;
            this.tipo = Tipo;
            this.id_cuenta = Id_cuenta;

            this.origen = Origen;
            this.destino = Destino;
            



        }
        public uint ID { get => this.id; set => this.id = value; }
        public decimal Monto { get => this.monto; set => this.monto = value; }
        public DateTime Fecha { get => this.fecha; set => this.fecha = value; }
        public string Tipo { get => this.tipo; set => this.tipo = value; }
        public int Origen { get => this.origen; set => this.origen = value; }
        public int Destino { get => this.destino; set => this.destino = value; }
        public int Id_cuenta { get => this.id_cuenta; set => this.id_cuenta = value; }

    }
        
}