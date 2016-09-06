using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CustomLibrary.Models;

namespace CustomLibrary
{
    public class HomeController : Controller
    {
        public JsonResult Index(int? id)
        {
            var routeInfo = new RouteInfo
            {
                Action = "Index",
                Controller = "Home",
                Id = id
            };
            return Json(routeInfo,JsonRequestBehavior.AllowGet);
        }

        [Route("Custom/List/{id:int}")]
        public JsonResult List(int id)
        {
            var routeInfo = new RouteInfo
            {
                Action = "List",
                Controller = "Home",
                Id = id
            };
            return Json(routeInfo, JsonRequestBehavior.AllowGet);
        }
    }
}
