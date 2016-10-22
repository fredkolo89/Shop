using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.DAL;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {

        ShopContext db = new ShopContext();

        // GET: Home
        public ActionResult Index()
        {
            var products = db.Product.Where(p => p.ProductId > 0).ToList();

            return View(products);
        }
    }
}