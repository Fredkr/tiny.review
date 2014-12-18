using tiny.review.core.DataModels;

namespace tiny.review.core.Users
{
    public interface IUserService
    {
        User GetUserByUserName(string userName);
        User GetUserByEmail(string email);
        void AddUser(string userName, string emailAdress, string password);
    }
}
