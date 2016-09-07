using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using WebApp_ControllerFactory.Controllers;

namespace WebApp_ControllerFactory.Infrastructure
{
    public class CustomControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            Type controllerType = null;
            switch (controllerName)
            {
                case "Home":
                    controllerType = typeof(HomeController);
                    break;
                case "User":
                    controllerType = typeof(UserController);
                    break;
                case "Admin":
                    if (requestContext.HttpContext.Request.IsLocal)
                    {
                        controllerType = typeof(AdminController);
                        break;
                    }
                    controllerType = typeof(BaseController);
                    break;
                default:
                    controllerType = typeof(BaseController);
                    break;
            }
            return controllerType == null ? null : (IController)DependencyResolver.Current.GetService(controllerType);
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            switch (controllerName)
            {
                case "Home":
                    return SessionStateBehavior.Disabled;
                default:
                    return SessionStateBehavior.Default;
            }
        }

        public void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            disposable?.Dispose();
        }
    }
}