using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApp_ControllerFactory.Infrastructure;
using WebApp_ControllerFactory.Models;

namespace WebApp_ControllerFactory.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult AddUser()
        {
            return View("UserCreateView");
        }
        [HttpPost]
        public async Task<JsonResult> AddUser(UserView user)
        {
            UserStorage.AddUser(user);
            var users = await Task<IEnumerable<UserView>>.Factory.StartNew(() => UserStorage.GetUsers());
            return Json(users,JsonRequestBehavior.AllowGet);
        }
        public ActionResult UserList()
        {
            var users = UserStorage.GetUsers();
            return View("UserListView",users);
        }
    }
}