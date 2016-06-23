using System.Web.Mvc;
using System.Web.Routing;
using TravelWeb.Common;

namespace TravelWeb.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Admin/Base/
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
            //lấy session được lưu trong UserLogin 
            var session = (UserLogin)Session[CommonConstant.USER_SESION];
            //nếu chưa đăng nhập thì sẽ redirect sang login page
            if( session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index", area = "Admin" }));
            }

            base.OnActionExecuting(filterContext);
        }
        

    }
}
