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

        // GET: roduct
        public ActionResult Delete()
        {
            ViewBag.Title = "Borrar Producto";
            return View();
        }

        public ActionResult Update()
        {
            ViewBag.Title = "Actualizar Producto";
            return View();
        }

        public ActionResult Products()
        {
            ViewBag.Title = "Products";
            return View();
        }

        public ActionResult Retrieve()
        {
            ViewBag.Title = "Buscar Productos";
            return View();
        }

    }
}