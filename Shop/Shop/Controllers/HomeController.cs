using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.DAL;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {

        private ShopContext db;

        // GET: Home
        public ActionResult Index()
        {

            return View();
        }



        [ChildActionOnly]
        public ActionResult GetCategoryList()
        {
            using (db = new ShopContext())
            {
                ListOfCategory categories = new ListOfCategory();
                categories.categories = db.Category.ToList();
                return PartialView("_CategoryList", categories);
            }
        }
        [ChildActionOnly]
        public ActionResult GetListNewProducts()
        {
            using (db = new ShopContext())
            {
                ListOfProducts products = new ListOfProducts();
                products.products = db.Product.OrderByDescending(p => p.DateAdded).Take(3).ToList();
                return PartialView("_NewProducts", products);
            }
        }
        [ChildActionOnly]
        public ActionResult GetListPopularProducts()
        {
            using (db = new ShopContext())
            {
                ListOfProducts products = new ListOfProducts();
                products.products = db.Product.Take(3).ToList();
                return PartialView("_PopularProducts", products);
            }
        }




    }
}