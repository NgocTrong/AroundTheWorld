using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelWeb.Controllers
{
    public class GalleryController : Controller
    {
        //
        // GET: /Gallery/

        public ActionResult Index()
        {
            TravelDbContext db = new TravelDbContext();
            return View(db.Galleries.Take(12).ToList());
        }

    }
}
