using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelWeb.Controllers
{
    public class FeedbackController : Controller
    {
        //
        // GET: /Feedback/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FeedBack(Feedback fbk)
        {
            using (TravelDbContext db = new TravelDbContext())
            {
                if(ModelState.IsValid)
                {
                    db.Feedbacks.Add(fbk);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(fbk);
        }

    }
}
