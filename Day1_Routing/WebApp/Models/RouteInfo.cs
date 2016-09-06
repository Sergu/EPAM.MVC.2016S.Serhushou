using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class RouteInfo
    {
        public string ControllerName { get; set; }
        public string Action { get; set; }
        public int? Id { get; set; }
    }
}