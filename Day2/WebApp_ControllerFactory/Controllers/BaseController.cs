using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp_ControllerFactory.Controllers
{
    public class BaseController : Controller
    {
        public ActionResult Error()
        {
            return View();
        }

        protected override void HandleUnknownAction(string actionName)
        {
            RedirectToAction("Error", "Home");
        }
    }
}