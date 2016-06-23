using System.Linq;
using System.Web.Mvc;
using Models.EF;

namespace TravelWeb.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Admin/Home/
        

        public ActionResult Index()
        {
            TravelDbContext db = new TravelDbContext();
            var model = db.Contacts.ToList();
            return View(model);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            TravelDbContext db = new TravelDbContext();
            var obj = db.Contacts.Find(id);
            db.Contacts.Remove(obj);
            db.SaveChanges();
            return View();
        }


    }
}
