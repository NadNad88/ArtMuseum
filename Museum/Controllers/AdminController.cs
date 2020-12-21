using Museum.Entities;
using Museum.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Museum.Controllers
{
    //[Authorize]
    public class AdminController : Controller
    {
        
        MContext MC = new MContext();


        public ActionResult Index()
        {

            IEnumerable<Client> clients = MC.Clients;
           
            IEnumerable<Event> events = MC.Events;
            IEnumerable<Photo> photos = MC.Photos;


            ViewBag.Events = events;
            ViewBag.Clients = clients;
        
            ViewBag.Photos = photos;

            return View();
        }

        public ActionResult PurchaseInfo()
        {
            IEnumerable<PurchaseOfTicket> purchases = MC.PurchaseOfTickets;
            ViewBag.PurchaseOfTickets = purchases;

            return View();
        }


        public ViewResult CreateEvent()
        {
            return View("AddEvent", new Event());
        }

        public ActionResult Create()
        {
            return View();
        }

   
        public ActionResult AddEvent(int Id)
        {
            Event newEvent = MC.Events
               .FirstOrDefault(g => g.EventId == Id);



            return View(newEvent);
        }
       
       
        [HttpPost]
        public ActionResult AddEvent(Event newEvent, HttpPostedFileBase file)
        {
            
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var image = new Photo()
                    {
                        ImageMimeType = file.ContentType,
                        ImageData = new byte[file.ContentLength]
                    };

                    //Photo image = new Photo();
                    //image.ImageMimeType = file.ContentType;
                    //image.ImageData = new byte[file.ContentLength];


                    file.InputStream.Read(image.ImageData, 0, file.ContentLength);

                    MC.Photos.Add(image);
                }

                newEvent.PhotoId = newEvent.EventId;
                MC.Events.Add(newEvent);
                MC.SaveChanges();

               
            }
            return Redirect("Index");
     
        }



        public ActionResult AddedEvent()
        {

            return View();
        }


        public FileContentResult GetImage(int photoId)
        {
            var image = MC.Photos.FirstOrDefault(p => p.PhotoId == photoId);

            if (image != null)
            {
                return File(image.ImageData, image.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

    }
}