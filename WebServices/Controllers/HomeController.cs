using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebServices.Controllers
{

    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            ViewBag.Title = "Melodic Music";

            return View();
        }


        public ActionResult Login()
        {
            ViewBag.Title = "Login";
            return View();
        }

    }
}
