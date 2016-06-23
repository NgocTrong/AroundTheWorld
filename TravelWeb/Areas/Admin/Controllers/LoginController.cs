using System.Web.Mvc;
using Models.Dao;
using TravelWeb.Areas.Admin.Models;
using TravelWeb.Common;

namespace TravelWeb.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Admin/Login/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.Username, model.Password);
                if (result == 1)
                {
                    //lấy đối tượng đăng nhập
                    var getUser = dao.GetById(model.Username);
                    //tạo Serializable để lưu trữ đối tượng đăng nhập
                    var userSession = new UserLogin {UserId = getUser.UserId, UserName = getUser.UserName};
                    //thêm đối tượng vào session có string name là CommonConstant.USER_SESION
                    Session.Add(CommonConstant.USER_SESION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài Khoản không tồn tại");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản đã bị khóa");
                }
                else
                {
                    ModelState.AddModelError("", "Password không đúng ");
                }
            }
            return View("Index");
        }


    }
}
