using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebServices.Controllers
{
    public class MMProductController : Controller
    {
        // GET: MMProduct
        public ActionResult Insert()
        {
            ViewBag.Title = "Insertar Producto";
            return View();
        }
    }
}