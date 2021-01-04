using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ClipMoney.Models;

namespace ClipMoney.Controllers
{

    [RoutePrefix("api/cuenta")]

    public class CuentaController : ApiController
    {

        // GET: api/Cuenta/5
        public Cuenta Get(int num_de_cuenta)
        {
            GestorCuenta gc = new GestorCuenta();
            return gc.obtenerDatosCuenta(num_de_cuenta);
        }
        // POST: api/Cuenta
        public string Post(Cuenta cuenta)
        {
            GestorCuenta gc = new GestorCuenta();
            if(gc.crear_cuenta(cuenta)) return "cuenta creada";
            return "Algo Fallo";
        }
        // PUT: api/Cuenta/5
        public void Put(int id, Cliente clt)
        {

        }

        // DELETE: api/Cuenta/5
        public void Delete(int id)
        {
        }
    }
}
