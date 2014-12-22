using System.Net;
using System.Web.Mvc;
using tiny.review.core.Reviews;
using tiny.review.core.Users;

namespace tiny.review.web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IReviewService reviewService;


        public UserController(IUserService userService, IReviewService reviewService)
        {
            this.userService = userService;
            this.reviewService = reviewService;
        }

        public JsonResult GetUser(string userId)
        {
            return Json(userService.GetUserByUserName(userId), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetReviews(string userName)
        {
            return Json(reviewService.GetUserReviews(userName));
        }

        public ActionResult AddReview(string userName, string title, string description, int rating)
        {
            var result = reviewService.AddReview(userName, title, description, rating);
            return result ?  new HttpStatusCodeResult(HttpStatusCode.OK):  new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        public ActionResult AddUser(string userName, string emailAdress, string password)
        {
            var result = userService.AddUser(userName, emailAdress, password);
            return result ? new HttpStatusCodeResult(HttpStatusCode.OK) : new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}