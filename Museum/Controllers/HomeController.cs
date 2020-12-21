using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Museum.Entities;
using Museum.Models;

namespace Museum.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        MContext db = new MContext();

        public ActionResult Index()
        {
            // получаем из бд все объекты 
            IEnumerable<Event> events = db.Events;
            IEnumerable<Photo> photos = db.Photos;
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.Events = events;
            ViewBag.Photos = photos;
            // возвращаем представление
            return View();
        }




        public ActionResult Completed()
        {
            return View();
        }




        public ActionResult gallery()
        {
            return View();
        }
        public ActionResult events()
        {
            IEnumerable<Event> events = db.Events;
            ViewBag.Events = events;


            IEnumerable<Photo> photos = db.Photos;
            ViewBag.Photos = photos;


            return View();
        }
        public ActionResult contact()
        {
            return View();
        }


        public ActionResult Purchase(int Id)
        {

            ViewBag.Id = Id;

            return View();
        }


        [HttpPost]
        public RedirectResult Purchase(int CountOfTickets,int Id)
        {
            Event events = db.Events
               .FirstOrDefault(g => g.EventId == Id);

            PurchaseOfTicket purchase = new PurchaseOfTicket();


            purchase.DateOfPurchase = DateTime.Now.ToShortDateString();
            purchase.Count = CountOfTickets;
            purchase.Cost = events.CostOfTicket * CountOfTickets;
            purchase.EventId = events.EventId;

            db.PurchaseOfTickets.Add(purchase);

            db.SaveChanges();

            return Redirect("/Home/Completed");
        }


        

    }
}