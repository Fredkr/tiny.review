using System.Web.Mvc;
using tiny.review.web.Manager;
using tiny.review.web.Models;

namespace tiny.review.web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthenticationManager authentication;

        public LoginController(IAuthenticationManager authentication)
        {
            this.authentication = authentication;
        }

        public ActionResult Login(string userName, string email, string password)
        {
            if ((string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(email)) || string.IsNullOrEmpty(password))
                return Json(new Login { Success = false, Message = "" });

            return Json(authentication.LoginUser(userName, email, password));
        }
    }
}