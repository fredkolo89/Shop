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
                 ListOfCategory categories =new ListOfCategory();
                 categories.categories=db.Category.ToList();
                 return PartialView("_CategoryList", categories);
            }
        }

    

    }
}