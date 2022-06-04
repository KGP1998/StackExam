using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewStackExam.Models
{
    public class RouteModel
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string ViewName { get; set; }
        public string Url { get; set; }
        public string RouteName { get; set; }
    }
}