using System;
using Machine.Specifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using It = Moq.It;
using System.Web;
using System.Web.Routing;

namespace UnitTestProject1
{
    public class Default_Route_test
    {
        static Mock<HttpContextBase> httpContextMock = new Mock<HttpContextBase>();
        static RouteCollection routes = new RouteCollection();
        static RouteData routeData;

        private Establish route = () =>
            Helper.AssertRoutes(httpContextMock, "~/", routes);

        Because of = () =>
            routeData = routes.GetRouteData(httpContextMock.Object);

        Machine.Specifications.It should_return = () =>
        {
            Assert.AreEqual("Action", routeData.Values["controller"]);
            Assert.AreEqual("Default", routeData.Values["action"]);
        };
    }

    public class Attribute_routing_test
    {
        static Mock<HttpContextBase> httpContextMock = new Mock<HttpContextBase>();
        static RouteCollection routes = new RouteCollection();
        static RouteData routeData;

        private Establish route = () =>
            Helper.AssertRoutes(httpContextMock, "~/Custom/List/23", routes);

        Because of = () =>
            routeData = routes.GetRouteData(httpContextMock.Object);

        Machine.Specifications.It should_return = () =>
        {
            Assert.AreEqual("Home", routeData.Values["controller"]);
            Assert.AreEqual("List", routeData.Values["action"]);
        };
    }

    public class static_segments_test
    {
        static Mock<HttpContextBase> httpContextMock = new Mock<HttpContextBase>();
        static RouteCollection routes = new RouteCollection();
        static RouteData routeData;

        private Establish route = () =>
            Helper.AssertRoutes(httpContextMock, "~/Static/Index", routes);

        Because of = () =>
            routeData = routes.GetRouteData(httpContextMock.Object);

        Machine.Specifications.It should_return = () =>
        {
            Assert.AreEqual("Action", routeData.Values["controller"]);
            Assert.AreEqual("Static", routeData.Values["action"]);
        };
    }

    public class Custom_constraint_test
    {
        static Mock<HttpContextBase> httpContextMock = new Mock<HttpContextBase>();
        static RouteCollection routes = new RouteCollection();
        static RouteData routeData;

        private Establish route = () =>
            Helper.AssertRoutes(httpContextMock, "~/Action/Index/23", routes);

        Because of = () =>
            routeData = routes.GetRouteData(httpContextMock.Object);

        Machine.Specifications.It should_return = () =>
        {
            Assert.AreEqual("Action", routeData.Values["controller"]);
            Assert.AreEqual("Static", routeData.Values["action"]);
            Assert.AreEqual("23", routeData.Values["id"]);
        };
    }

    public class namespacePriority_webAppController_test
    {
        static Mock<HttpContextBase> httpContextMock = new Mock<HttpContextBase>();
        static RouteCollection routes = new RouteCollection();
        static RouteData routeData;

        private Establish route = () =>
            Helper.AssertRoutes(httpContextMock, "~/Home/Index/2", routes);

        Because of = () =>
            routeData = routes.GetRouteData(httpContextMock.Object);

        Machine.Specifications.It should_return = () =>
        {
            Assert.AreEqual("Home", routeData.Values["controller"]);
            Assert.AreEqual("Index", routeData.Values["action"]);
            Assert.AreEqual("2", routeData.Values["id"]);
        };
    }

    public class namespacePriority_customLibController_test
    {
        static Mock<HttpContextBase> httpContextMock = new Mock<HttpContextBase>();
        static RouteCollection routes = new RouteCollection();
        static RouteData routeData;

        private Establish route = () =>
            Helper.AssertRoutes(httpContextMock, "~/Home/Index/asda", routes);

        Because of = () =>
            routeData = routes.GetRouteData(httpContextMock.Object);

        Machine.Specifications.It should_return = () =>
        {
            Assert.AreEqual("Home", routeData.Values["controller"]);
            Assert.AreEqual("Index", routeData.Values["action"]);
            Assert.AreEqual("asda", routeData.Values["id"]);
        };
    }
}
