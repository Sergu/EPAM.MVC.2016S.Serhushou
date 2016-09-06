using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ActionController : Controller
    {
        // GET: Action
        public ActionResult Static()
        {
            ViewBag.message = "this segment is static";
            return View("StaticView");
        }

        public ActionResult Index(int? id)
        {
            var routeInfo = new RouteInfo
            {
                Action = "Index",
                ControllerName = "Action",
                Id = id
            };

            return View(routeInfo);
        }

        public ActionResult Default()
        {
            return View();
        }
    }
}