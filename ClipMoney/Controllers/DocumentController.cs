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
    [RoutePrefix("api/document")]
    public class DocumentController : ApiController
    {
        [Authorize]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string Put(int id, Cliente clt)
        {
            GestorCliente gc = new GestorCliente();
            if (gc.cargar_documento(id, clt)) return "Documento cargado";
            return "Algo Fallo";
        }
        [Authorize]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string Get(int id)
        {
            GestorCliente gc = new GestorCliente();
            if (gc.existe_documento(id)) return "true";

            return "false";
        }
    }
}
