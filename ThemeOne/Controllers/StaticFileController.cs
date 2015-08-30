using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThemeOne.Controllers
{
    public class StaticFileController : Controller
    {
        //
        // GET: /StaticFile/

        public ActionResult Index()
        {
            return View();
        }

    }
}
