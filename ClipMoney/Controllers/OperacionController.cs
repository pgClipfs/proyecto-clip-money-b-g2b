
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using ClipMoney.Models;

namespace ClipMoney.Controllers
{

    [RoutePrefix("api/operacion")]
    public class OperacionController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IEnumerable<Operacion> Get(int id)
        {
            GestorOperacion gop = new GestorOperacion();
            return gop.ultimos_movimientos(id); ;
        }
     
        

        [HttpPut] 
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string PutOperaciones(Operacion operacion)
        {
            GestorOperacion gop = new GestorOperacion();
            if (gop.operaciones_saldo(operacion)) return "Operacion completada";
            return "Algo fallo";
        }
    }
}
