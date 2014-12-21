using tiny.review.core.Users;
using tiny.review.web.Models;

namespace tiny.review.web.Manager
{
    public class AuthenticationManager: IAuthenticationManager
    {
        private readonly IUserService userService;

        public AuthenticationManager(IUserService userService)
        {
            this.userService = userService;
        }

        public Login LoginUser(string userName, string email, string password)
        {
            var user = !string.IsNullOrEmpty(userName) ? userService.GetUserByUserName(userName) : userService.GetUserByEmail(email);

            if (user != null && user.ValidatePassword(password))
            {
                return new Login
                {
                    Success = true,
                    Message = "Successfully logged in",
                    User = new User
                    {
                        Name = user.UserName,
                        Email = user.EmailAdress
                    }
                };
            }

            return new Login
            {
                Success = false,
                Message = "Incorrect password",
            };
        }
    }
}