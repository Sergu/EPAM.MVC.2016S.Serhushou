using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp_Attributes.Infrastructure;
using WebApp_Attributes.Models;

namespace WebApp_Attributes.Controllers
{

    public class AdminController : BaseController
    {
        [Local]
        public ActionResult RemoveUser(string surname)
        {
            var wasDeleted = UserStorage.RemoveUser(surname);
            var model = new RemoveResult { Surname = surname, WasDeleted = wasDeleted };
            return View("RemoveUserView", model);
        }
    }
}