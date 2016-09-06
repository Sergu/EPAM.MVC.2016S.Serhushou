using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace WebApp.Infrastructure
{
    public class SimpleNumberIdConstraint : IRouteConstraint
    {
        public SimpleNumberIdConstraint() { }


        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            object id;
            var isGet = values.TryGetValue("id", out id);
            if (isGet)
            {
                int numb;
                if (int.TryParse((string)id,out numb))
                {
                    for (int i = 2; i < numb; i++)
                    {
                        if ((numb % i) == 0)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            return false;
        }
    }
}