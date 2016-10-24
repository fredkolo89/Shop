using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.DAL;
using Shop.Models;

namespace Shop.Controllers
{
    public class StaticPagesController : Controller
    {
        // GET: StaticPages
        public ActionResult Contact()
        {
            return View("Contact");
        }

        [HttpPost]
        public ActionResult SendMessage(Contact contact)
        {

            if (!ModelState.IsValid)
            {
                return View("Contact", contact);
            }
            else
            {
                using (var db = new ShopContext())
                {
                    db.Contact.Add(contact);
                    db.SaveChanges();
                    ViewBag.IsAdded = true;
                }
                return View("Contact", new Contact());
            }
        }
    }
}