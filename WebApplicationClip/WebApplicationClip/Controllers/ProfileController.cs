using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApplicationClip.Controllers
{
    public class ProfileController : Controller
    {

        // GET: Profile
        public ActionResult Index()
        {
            if (!string.IsNullOrEmpty(Session["User"] as string)) return View();
            else return RedirectToAction("Index", "Home");

        }
    }
}