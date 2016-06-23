using System.Linq;
using System.Web.Mvc;
using Models.EF;

namespace TravelWeb.Areas.Admin.Controllers
{
    public class GalleryController : BaseController
    {
        //
        // GET: /Admin/Gallery/

        public ActionResult Index()
        {
            TravelDbContext db = new TravelDbContext();
            return View(db.Galleries.ToList());
        }



        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Gallery gallery)
        {
            if(ModelState.IsValid)
            {
                TravelDbContext db = new TravelDbContext();
                db.Galleries.Add(gallery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gallery);

        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            TravelDbContext db = new TravelDbContext();
            var gal = db.Galleries.Find(id);
            db.Galleries.Remove(gal);
            db.SaveChanges();
            return View();

        }

    }
}
