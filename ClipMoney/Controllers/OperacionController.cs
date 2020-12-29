using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ClipMoney.Models;

namespace ClipMoney.Controllers
{

    [RoutePrefix("api/operacion")]
    public class OperacionController : ApiController
    {
        // GET: api/Operacion
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Operacion/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Operacion
        public void Post([FromBody] string value)
        {
        }
        // PUT: Ingreso y extraccion

        [HttpPut]
        [EnableCors(origins: "*", headers: "*", methods: "*")]

        public string PutOperaciones(Operacion operacion)
        {
            GestorOperacion gop = new GestorOperacion();
            if (gop.operaciones_saldo(operacion)) return "Operacion completada";
            return "Algo fallo";
        }

      

        // PUT: api/Operacion/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE: api/Operacion/5
        public void Delete(int id)
        {
        }
    }
}
