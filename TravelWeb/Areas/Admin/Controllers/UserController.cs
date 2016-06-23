using System.Web.Mvc;
using Models.Dao;
using Models.EF;

namespace TravelWeb.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        //
        // GET: /Admin/User/

        public ActionResult Index()
        {
           var model = new UserDao().listUser();
            return View(model);
        }


        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(User user)
        {
            if(ModelState.IsValid)
            {
                var addUser = new UserDao().Insert(user);
                if (addUser > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            
            return View(user);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);
            return View();
        }
    }
}
