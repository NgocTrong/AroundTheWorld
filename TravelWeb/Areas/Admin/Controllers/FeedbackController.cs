using System.Linq;
using System.Web.Mvc;
using Models.EF;

namespace TravelWeb.Areas.Admin.Controllers
{
    public class FeedbackController : BaseController
    {
        //
        // GET: /Admin/Feedback/

        public ActionResult Index()
        {

            TravelDbContext db = new TravelDbContext();
            
                var model = db.Feedbacks.ToList();
            
            return View(model);
        }

    }
}
