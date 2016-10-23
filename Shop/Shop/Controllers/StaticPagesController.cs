using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class StaticPagesController : Controller
    {
        // GET: StaticPages
        public ActionResult GetStaticPage(string name)
        {
            return View(name);
        }
    }
}