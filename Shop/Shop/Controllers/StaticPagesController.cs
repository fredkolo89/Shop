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
                    //tu jest wzorzec Wzorzec Post-Redirect-Get, zeby jak 
                    //klikniesz odswiez na formularzu to zeby nie wysylal sie jeszcze raz
                    // tylko zeby poszedl normalny get

                    //temdata to stryktura która przechowuje dane tylko na dwa 
                    //żadania czyli tylko na to przekierowanie
                    TempData["name"] = contact.Name;
                    return RedirectToAction("RedirectFromSendMessage");
                }
              
            }
        }

        public ActionResult RedirectFromSendMessage()
        {
            //ViewBagi ukryja diva z formularzem i odkryja z Informacja ze wysłano
            ViewBag.hide = "hide";
            ViewBag.visible = "";
            ViewBag.Information = string.Format("Dzieki {0} za kontakt z nami", TempData["name"]);
            return View("contact");
        }
    }
}