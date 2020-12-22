using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Product.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult About()
        {
            ViewBag.Message = "Single Page Application (SPA) using ASP.NET MVC 5, Entity Framework 6, Code First Migration, Partial View and AJAX.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "<a href='http://jewel.features.site' target='_blank'>SYED ZAHIDUL HASSAN</a><br />";

            return View();
        }
    }
}