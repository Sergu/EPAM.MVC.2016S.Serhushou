using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;

namespace UnitTestProject1
{
    public static class Helper
    {
        public static void AssertRoutes(Mock<HttpContextBase> httpContextMock, string url, RouteCollection routes)
        {
            WebApp.RouteConfig.RegisterRoutes(routes);
            httpContextMock.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath).Returns(url);
        }
    }
}
