using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StarWars.Controllers
{
    public class StarwarsController : Controller
    {
        // GET: Starwars
        public ActionResult ChoseSide()
        {
            return View("Body");
        }
    }
}