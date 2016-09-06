using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomLibrary.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? id)
        {
            var routeInfo = new RouteInfo
            {
                Action = "Index",
                Controller = "Home",
                Id = id
            };

            return View(routeInfo);
        }
    }
}