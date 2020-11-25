using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using ClipMoney.Models;

namespace ClipMoney.Controllers
{
    
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        [HttpGet]
        [Authorize]
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }
        [HttpPost]
        [Route("authenticate")]
        public Resp Authenticate(Login login)
        {
            Console.WriteLine(login.Contraseña);
            if (login == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            GestorLogin lc = new GestorLogin();
            int id = lc.validar_login(login);

            if (id != 0)
            {
                var token = TokenGenerator.GenerateToken(login.Usuario);
                Resp rta = new Resp(token, id);
                return rta;
            }
            else
            {
                return null;
            }
        }
    }
}
