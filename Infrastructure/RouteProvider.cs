using NewStackExam.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NewStackExam.Infrastructure
{
    public class RouteProvider
    {
        public List<RouteModel> GetFileSystemData()
        {
            List<RouteModel> routeModels = new List<RouteModel>();
            string rootpath = HttpContext.Current.Server.MapPath("~\\Views") ;
            var notIncludedFolder = new string[]
            {
                "Shared"
            };

            var viewsFolders = Directory.GetDirectories(rootpath).Where(x => notIncludedFolder.Where(y => !x.Contains(y)).Count() > 0).ToList();
            //viewsFolders.Where(x => new DirectoryInfo(x))
            foreach (var viewsFolder in viewsFolders)
            {
                var views = Directory.GetFiles(viewsFolder);
                foreach (var view in views)
                {
                    routeModels.Add(new RouteModel()
                    {
                        ActionName = Path.GetFileNameWithoutExtension(view),
                        ControllerName = Directory.GetParent(view).Name,
                        RouteName = Path.GetFileNameWithoutExtension(view),
                        ViewName = Path.Combine(Directory.GetParent(view).Parent.Name, Directory.GetParent(view).Name, Path.GetFileName(view)),
                        Url = Path.GetFileNameWithoutExtension(view.Replace("_", "-")),
                    });
                }
            }
            return routeModels;
        }

        public virtual void RegisterRoutes(RouteCollection routes)
        {
            var routeModels = GetFileSystemData();
            foreach (var route in routeModels)
            {
                routes.MapRoute(
                   name: route.RouteName,
                   url: route.Url,
                   defaults: new { controller = "StackExam", action = "GlobalAction", viewName = route.ViewName }
               );
            }
        }
    }
}