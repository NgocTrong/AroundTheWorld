using System.Linq;
using System.Web.Mvc;
using Models.Dao;
using Models.EF;
using Models.ViewModel;

namespace TravelWeb.Areas.Admin.Controllers
{
    public class TourDestinationController : BaseController
    {
        //
        // GET: /Admin/TourDestination/
        TravelDbContext db = new TravelDbContext();
        public ActionResult Index()
        {
            var data = (from a in db.TouristDestinations
                        join b in db.Provinces
                        on a.ProvinceId equals b.ProvinceId
                        select new TouristDestinationViewModel()
                        {
                            TouristDestinationId = a.TouristDestinationId,
                            TouristDestinationName = a.TouristDestinationName,
                            TDAvartar = a.TDAvartar,
                            Status = a.Status,
                            ProvinceName = b.ProvinceName,
                            DisplayOrder = a.DisplayOrder
                        }).ToList();

            return View(data);
        }


        //datatable 
        //public ActionResult loaddata()
        //{

        //    var data = (from a in db.TouristDestinations
        //                join b in db.Provinces
        //                on a.ProvinceId equals b.ProvinceId
        //                select new TouristDestinationViewModel()
        //                {
        //                    TouristDestinationId = a.TouristDestinationId,
        //                    TouristDestinationName = a.TouristDestinationName,
        //                    TDAvartar = a.TDAvartar,
        //                    Status = a.Status,
        //                    ProvinceName = b.ProvinceName,
        //                    DisplayOrder = a.DisplayOrder
        //                }).ToList();

        //    return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        //}





        //Create Tourist Destination
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Create(TouristDestination td)
        {
            if(ModelState.IsValid)
            {
                var dao = new TourDestinationDao();
                long id = dao.Insert(td);
                if(id>0)
                {
                    return RedirectToAction("Index", "TourDestination");
                }
                else
                {
                    ModelState.AddModelError("", "fail fail fail");
                }
            }
            else
            {
                ModelState.AddModelError("", "Create Tour fail fail fail");
            }
            SetViewBag();
            return View();
        }

        //List Province
        public void SetViewBag(int? selectedId=null)
        {
            var dao = new ProvinceDao();
            ViewBag.ProvinceId = new SelectList(dao.ListAll(), "ProvinceId", "ProvinceName", selectedId);
        }


        //Delete Tourist Destination
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            var dao = new TourDestinationDao().Delete(id);
            if(dao)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
    }
}
