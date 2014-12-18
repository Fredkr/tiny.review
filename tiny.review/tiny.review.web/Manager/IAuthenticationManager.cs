using tiny.review.web.Models;

namespace tiny.review.web.Manager
{
    public interface IAuthenticationManager
    {
        Login LoginUser(string userName, string email, string password);
    }
}
