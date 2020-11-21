using ClipMoney.Models;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ClipMoney.Controllers
{

    [AllowAnonymous]
    [RoutePrefix("api/cliente")]
    public class ClienteController : ApiController
    {

        
        // GET: api/Cliente/5
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public Cliente Get(int id)
        {
            GestorCliente gc = new GestorCliente();
            return gc.obtener_cliente((uint)id);
        }

        // POST: api/Cliente
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string Post(Cliente cliente)
        {
            GestorCliente gc = new GestorCliente();
            if (gc.crear_cliente(cliente)) return "Cliente creado";
            return "Algo fallo";
        }

        // PUT: api/Cliente/5
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string Put(Cliente cliente)
        {
            GestorCliente gc = new GestorCliente();
            if (gc.actualizar_cliente(cliente)) return "Cliente actualizado";
            return "Algo fallo";
        }
    }
}
