using tiny.review.core.DataModels;

namespace tiny.review.core.Users
{
    public interface IUserService
    {
        User GetUser(string userId);
        void AddUser(string userName, string emailAdress);
    }
}
