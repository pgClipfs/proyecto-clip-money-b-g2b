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
    [AllowAnonymous]
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
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }
        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(Login login)
        {

            if (login == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            GestorLogin lc = new GestorLogin();


            if (lc.validar_login(login))
            {
                var token = TokenGenerator.GenerateToken(login.Usuario);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
