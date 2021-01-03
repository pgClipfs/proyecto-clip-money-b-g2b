using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Mail;
using System.Web.Http.Cors;
using ClipMoney.Models;

namespace ClipMoney.Controllers
{
    [RoutePrefix("api/restablecer")]
    public class RestablecerController : ApiController
    {


        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string Post(Cliente cliente)
        {
            GestorCliente gc = new GestorCliente();
            uint id_cliente = (uint)gc.validar_usuario("", cliente.Email);
            if (id_cliente == 0) return "no existe usuario con ese mail";

            cliente = gc.obtener_cliente(id_cliente);
            var token = TokenGenerator.GenerateToken(cliente.Usuario);
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("testclipfafafa@gmail.com");
                mail.To.Add(cliente.Email);
                mail.Subject = "Hola " + cliente.Nombre;
                mail.Body = "<h1>Enviado por Fablas</h1>" +
                    "<p> http://localhost:4200/restablecer/" + token + "/" + cliente.ID + "</p>";
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("testclipfafafa@gmail.com", "123fablas123");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }

            return "Enviado";
        }

        [Authorize]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string Put(Cliente cliente)
        {
            GestorCliente gc = new GestorCliente();
            if(gc.cambiar_contraseña(cliente)) return "constraseña cambiada";
            return "Algo fallo";
        }
    }
 }
