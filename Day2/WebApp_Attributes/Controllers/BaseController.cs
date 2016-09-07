using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp_Attributes.Controllers
{
    public class BaseController : Controller
    {
        protected override void HandleUnknownAction(string actionName)
        {
            string errorMessage = "Action : " + actionName + " is not found in controller "
                                 + this.ControllerContext.RouteData.Values["controller"];
            ViewBag.message = errorMessage;
            this.View("Error").ExecuteResult(this.ControllerContext);
        }
    }
}