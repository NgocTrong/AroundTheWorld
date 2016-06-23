using Models.Dao;
using Models.EF;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace TravelWeb.Controllers
{
    public class TourController : BaseController
    {
        //
        // GET: /Tour/



        //tour theo id 
        public ActionResult Index(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var db = new TravelDbContext();
            var tvm = new TourViewModel();
            var data = (from a in db.Tours
                        join b in db.TouristDestinations on a.TouristDestinationId equals b.TouristDestinationId
                        where a.TourId == id
                        select new TourViewModel()
                        {
                            TourId = a.TourId,
                            TourName = a.TourName,
                            Image = a.Image,
                            DepartureTime = a.DepartureTime,
                            TourTime = a.TourTime,
                            StartingPoint = a.StartingPoint,
                            ArrivalPoint = a.ArrivalPoint,
                            Transport = a.Transport,
                            Price = a.Price,
                            TimeTable = a.TimeTable,
                            TouristDestinationName = b.TouristDestinationName,
                        }).Single();
            if (data == null)
            {
                return HttpNotFound();
            }

            tvm.TouristDestinationName = data.TouristDestinationName;
            ViewBag.TDName = tvm.TouristDestinationName;


            return View(data);
        }


        [HttpGet]
        public ActionResult BookingTour(long id)
        {

            SetId(id);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BookingTour(Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    new ContactDao().Insert(contact);
                    if (contact.ContactId > 0)
                    {
                        SetAlert("successfully Contacted", "success");
                        return Redirect("/Home/Index");
                    }
                    else
                    {
                        SetAlert("Input not success!", "error");
                        return View("BooKingTour");
                    }


                }
                else
                {
                    SetAlert("Input not success!", "error");
                }

            }
            catch (DataException /* dex     */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            SetId(contact.TourId);
            return View(contact);

        }


        //when user reload page , info is not change 
        public void SetId(long id)
        {
            var db = new TravelDbContext();
            var data = db.Tours.Find(id);
            ViewBag.TourName = data.TourName.ToUpper();
            ViewBag.Price = data.Price;
            ViewBag.Image = data.Image;
            ViewBag.DepartureTime = data.DepartureTime;
            ViewBag.TourId = id;
        }
    }
}
