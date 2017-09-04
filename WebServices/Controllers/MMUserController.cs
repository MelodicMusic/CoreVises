using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebServices.Controllers
{
    public class MMUserController : Controller
    {
        // GET: MMUser
        public ActionResult Update()
        {
            return View();
        }

        // GET: MMUser
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Retrieve()
        {
            return View();
        }


        public ActionResult Delete()
        {
            return View();
        }


        public ActionResult Users()
        {
            return View();
        }



        // reports
        public ActionResult Reports()
        {
            return View();
        }



        public ActionResult ClientReport()
        {
            return View();
        }

        public ActionResult ProductsReports()
        {
            return View();
        }


    }
}