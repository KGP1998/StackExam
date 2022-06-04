using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewStackExam.Controllers
{
    public class StackExamsController : Controller
    {
        // GET: StackExams

        public ActionResult GlobalAction(string viewName)
        {
            return View("~\\" + viewName);
        }
    }
}