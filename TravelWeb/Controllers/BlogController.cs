using System.Web.Mvc;

namespace TravelWeb.Controllers
{
    public class BlogController : Controller
    {
        //
        // GET: /Blog/

        public ActionResult Index()
        {
            return View();
        }


        //Topic/blog/
        public ActionResult TopPost()
        {
            return View();
        }

        public ActionResult Topic(int id)
        {

            return View();
        }

    }
}
