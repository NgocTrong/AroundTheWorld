using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Models.Dao;
using Models.EF;
using Models.ViewModel;

namespace TravelWeb.Controllers
{
    public class TouristDestinationController : Controller
    {

        //GET: /TouristDestination/


        public ActionResult Index(string searchString, string sortOrder)
        {
            SetViewBag();
            var db = new TravelDbContext();
            var tvm = new TourViewModel();

            var data = (from a in db.Tours
                        join b in db.TouristDestinations on a.TouristDestinationId equals b.TouristDestinationId
                        join c in db.Provinces on b.ProvinceId equals c.ProvinceId

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
                            TDAvartar = b.TDAvartar

                        });

            if (!string.IsNullOrEmpty(searchString))
            {
                data = data.Where(s => s.TourName.ToLower().Contains(searchString) || s.TouristDestinationName.ToLower().Contains(searchString)
                    || s.ArrivalPoint.ToLower().Contains(searchString) || s.Price.ToString().Contains(searchString)
                    );
            }
            if (!data.Any())
            {
                ViewBag.TDName = "Không tìm thấy Tour nào...";
            }
            else
            {
                tvm.TouristDestinationName = data.First().TouristDestinationName;
                ViewBag.TDName = tvm.TouristDestinationName;
            }


            switch (sortOrder)
            {
                case "Price1":
                    data = data.OrderBy(s => s.Price);
                    if (!data.Any())
                    {
                        ViewBag.TDName = "Không tìm thấy Tour nào với giá này...";
                    }
                    break;
                case "Price2":
                    data = data.Where(s => s.Price < 2000000);
                    if (!data.Any())
                    {
                        ViewBag.TDName = "Không tìm thấy Tour nào với giá này...";
                    }
                    break;
                case "Price3":
                    data = data.Where(s => s.Price >= 2000000 && s.Price < 4000000);
                    if (!data.Any())
                    {
                        ViewBag.TDName = "Không tìm thấy Tour nào với giá này...";
                    }
                    break;
                case "Price4":
                    data = data.Where(s => s.Price >= 4000000 && s.Price < 6000000);
                    if (!data.Any())
                    {
                        ViewBag.TDName = "Không tìm thấy Tour nào với giá này...";
                    }
                    break;
                case "Price5":
                    data = data.Where(s => s.Price >= 6000000 && s.Price < 8000000);
                    if (!data.Any())
                    {
                        ViewBag.TDName = "Không tìm thấy Tour nào với giá này...";
                    }
                    break;
                case "Price6":
                    data = data.Where(s => s.Price >= 8000000 && s.Price < 10000000);
                    if (!data.Any())
                    {
                        ViewBag.TDName = "Không tìm thấy Tour nào với giá này...";
                    }
                    break;
                case "Price7":
                    data = data.Where(s => s.Price > 10000000);
                    if (!data.Any())
                    {
                        ViewBag.TDName = "Không tìm thấy Tour nào với giá này...";
                    }
                    break;

                default:
                    data = data.OrderBy(s => s.Price);
                    break;
            }
            return View(data.ToList());
        }



        //tourist destination by provinceId 

        public ActionResult ListTour(int id)
        {
            //dùng để tránh trường hợp click 2 lần vào link filter,set sẵn giá trị lên server
            SetViewBag();


            TravelDbContext db = new TravelDbContext();
            TourViewModel tvm = new TourViewModel();
            var data = new TourDestinationDao().ViewByProvince(id);
            if (!data.Any())
            {
                var pro = db.Provinces.Single(m => m.ProvinceId == id);
                ViewBag.TDName = "không có Tour nào tại " + pro.ProvinceName;
            }
            else
            {
                tvm.TouristDestinationName = data.First().TouristDestinationName;
                ViewBag.TDName = tvm.TouristDestinationName;
            }
            return View(data);

        }


        //để set giá trị cho price
        public void SetViewBag()
        {
            ViewBag.Price1 = "Price1";
            ViewBag.Price2 = "Price2";
            ViewBag.Price3 = "Price3";
            ViewBag.Price4 = "Price4";
            ViewBag.Price5 = "Price5";
            ViewBag.Price6 = "Price6";
            ViewBag.Price7 = "Price7";
        }


        //getdata 
        [HttpGet]
        public ActionResult GetData(string[] values)
        {

            if (values != null)
            {
                var myValues = Array.ConvertAll(values, int.Parse);
                //var array = new int[] { 7, 8, 9 };
                TravelDbContext db = new TravelDbContext();
                var data = (from a in db.Tours
                            join b in db.TouristDestinations on a.TouristDestinationId equals b.TouristDestinationId
                            join c in db.Provinces on b.ProvinceId equals c.ProvinceId
                            where myValues.Contains(c.ProvinceId)
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
                                TDAvartar = b.TDAvartar

                            });
                return View("GetData", data.ToList());
            }
            else
            {
                
                return RedirectToAction("NoTour");
            }     
        }

        public ActionResult NoTour()
        {
           
            return View();
        }


    }
}