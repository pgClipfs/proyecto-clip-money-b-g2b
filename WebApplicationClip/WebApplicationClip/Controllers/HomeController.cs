using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationClip.Models;

namespace WebApplicationClip.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SQLcontrol sql = new SQLcontrol();
            if (sql.Login("Fablas", "fab123") == 1)
            {
                return View();
            }              
            else
            {
                Console.WriteLine("Fallo el logeo con la base de datos");
                return RedirectToAction("flogin");
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