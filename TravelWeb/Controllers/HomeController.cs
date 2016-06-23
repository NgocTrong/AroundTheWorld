using System.Web.Mvc;
using Models.Dao;

namespace TravelWeb.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
           var model = new ProvinceDao().ListAll();
           return View(model);
        }

        public ActionResult ProvincePartial()
        {
            var model = new ProvinceDao().ListAll();
            return PartialView(model);
        }

    
 

    }
}
