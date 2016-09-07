using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApp_Attributes.Infrastructure;
using WebApp_Attributes.Models;

namespace WebApp_Attributes.Controllers
{
    public class UserController : BaseController
    {
        [HttpGet]
        [ActionName("Add-user")]
        public ActionResult AddUser()
        {
            return View("UserCreateView");
        }
        [HttpPost]
        [ActionName("Add-user")]
        public async Task<JsonResult> AddUser(UserView user)
        {
            UserStorage.AddUser(user);
            var users = await Task<IEnumerable<UserView>>.Factory.StartNew(() => UserStorage.GetUsers());
            return Json(users, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        [ActionName("User-List")]
        public ActionResult UserListGet()
        {
            var users = UserStorage.GetUsers();
            return View("UserListView", users);
        }
        [HttpPost]
        [ActionName("User-List")]
        public JsonResult UserListPost()
        {
            var users = UserStorage.GetUsers();
            return Json(users, JsonRequestBehavior.AllowGet);
        }
    }
}