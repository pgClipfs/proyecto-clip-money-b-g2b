using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplicationClip.Models;

namespace WebApplicationClip.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string message = "")
        {
            ViewBag.Message = message;
            return View();
        }
        [HttpPost]
        public ActionResult Login(string usr,string pws)
        {
            if(!string.IsNullOrEmpty(usr) && !string.IsNullOrEmpty(pws))
            {
                SQLcontrol sql = new SQLcontrol();
                if (sql.Login(usr, pws) == 1)
                {
                    Session["User"] = usr;
                    return RedirectToAction("Index", "Profile");
                }
                else
                {
                    return RedirectToAction("Index", new { message = "No encontramos tus datos"});    
                }
            }
            else
            {
                return RedirectToAction("Index", new { message = "Llena los campos para poder iniciar seccion" });
            }

        }
        public ActionResult flogin()
        {
            return View();
        }

        public ActionResult Cuenta()
        {
            ViewBag.Message = "Detalles de cuenta del usuario";

            return View();
        }

        public ActionResult Operaciones()
        {
            ViewBag.Message = "Sector donde se realizan operaciones";

            return View();
        }
    }
}