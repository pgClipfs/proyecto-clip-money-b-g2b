using ClipMoney.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ClipMoney.Controllers
{

    [RoutePrefix("api/cliente")]
    public class ClienteController : ApiController
    {


        // GET: api/Cliente/5
        
        public Cliente Get(int id)
        {
            GestorCliente gc = new GestorCliente();
            return gc.obtener_cliente((uint)id);
        }

        // POST: api/Cliente
        //[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public string Post(Cliente cliente)
        {
            GestorCliente gc = new GestorCliente();
            if (gc.crear_cliente(cliente)) return "Cliente creado";
            return "Algo fallo";
        }

        // PUT: api/Cliente/5
        //[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public string Put(Cliente cliente)
        {
            GestorCliente gc = new GestorCliente();
            if (gc.actualizar_cliente(cliente)) return "Cliente actualizado";
            return "Algo fallo";
        }
    }
}
