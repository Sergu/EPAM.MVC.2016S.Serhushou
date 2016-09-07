using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp_ControllerFactory.Infrastructure;
using WebApp_ControllerFactory.Models;

namespace WebApp_ControllerFactory.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult RemoveUser(string surname)
        {
            var wasDeleted = UserStorage.RemoveUser(surname);
            var model = new RemoveResult { Surname = surname, WasDeleted = wasDeleted };
            return View("RemoveUserView", model);
        }
    }
}