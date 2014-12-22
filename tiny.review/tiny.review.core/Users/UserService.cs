using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using tiny.review.core.DataModels;
using tiny.review.core.RavenDb;

namespace tiny.review.core.Users
{
    public class UserService : IUserService
    {
        private readonly DbManager db;
        public UserService(DbManager db)
        {
            this.db = db;
        }

        public User GetUserByUserName(string userName)
        {
            Expression<Func<User, bool>> query = u => u.UserName.Equals(userName);
            return db.GetDocument(query);
        }
        public User GetUserByEmail(string email)
        {
            Expression<Func<User, bool>> query = u => u.UserName.Equals(email);
            return db.GetDocument(query);
        }

        public bool AddUser(string userName, string emailAdress, string password)
        {
            return db.AddDocument(new User
            {
                UserId = Convert.ToString(db.Count<User>() + 1),
                UserName = userName,
                EmailAdress = emailAdress,
                Reviews = new Collection<Review>()
            }.SetPassword(password));
        }
    }
}
