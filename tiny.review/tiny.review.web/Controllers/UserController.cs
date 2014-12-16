using System.Web.Mvc;
using tiny.review.core.Users;

namespace tiny.review.web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public JsonResult GetUser(string userId)
        {
            return Json(userService.GetUser(userId), JsonRequestBehavior.AllowGet);
        }

        public void AddUser(string userName, string emailAdress)
        {
            userService.AddUser(userName, emailAdress);
        }
    }
}