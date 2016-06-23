using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Models.Dao;
using Models.EF;
using Models.ViewModel;

namespace TravelWeb.Areas.Admin.Controllers
{
    public class TourController : BaseController
    {
        //
        // GET: /Admin/Tour/

        public ActionResult Index()
        {
            TravelDbContext db = new TravelDbContext();

            var model = (from a in db.Tours
                         join b in db.TouristDestinations on a.TouristDestinationId equals b.TouristDestinationId 
                         select new TourViewModel()
                         {
                             TourId = a.TourId,
                             TourName = a.TourName,
                             DepartureTime = a.DepartureTime,
                             TourTime = a.TourTime,
                             StartingPoint = a.StartingPoint,
                             ArrivalPoint = a.ArrivalPoint,
                             Transport = a.Transport,
                             Price = a.Price,
                             TimeTable = a.TimeTable,
                             DisplayOrder = a.DisplayOrder,
                             Status = a.Status,
                             TouristDestinationName = b.TouristDestinationName,
                            

                         }).ToList();
            return View(model);
        }



        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Tour tour)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dao = new TourDao();
                    dao.Insert(tour);
                    return RedirectToAction("Index");
                }

            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Try Again,hihi!!");
            }



            // return list Tourist Destation Name you choose
            SetViewBag();
            return View(tour);

        }

        public void SetViewBag(long? selectedId = null)
        {

            ViewBag.TouristDestinationId = new SelectList(new TourDao().ListAll(), "TouristDestinationId", "TouristDestinationName", selectedId);
        }

        //Delete
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            if(id == null)
            {
                return  new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            new TourDao().Delete(id);
            return View();
        }


        //test 

        public ActionResult Detail(long id)
        {
            TravelDbContext db = new TravelDbContext();
            var model = db.Tours.Find(id);

            return View(model);
        }

    }
}
