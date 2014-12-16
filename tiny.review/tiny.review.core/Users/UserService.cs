using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
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

        public User GetUser(string userId)
        {
            Expression<Func<User, bool>> query = u => u.UserId.Equals(userId);
            return db.GetDocument(query);
        }

        public void AddUser(string userName, string emailAdress)
        {
            db.AddDocument(new User
            {
                UserId = Convert.ToString(db.Count<User>() + 1),
                UserName = userName,
                EmailAdress = emailAdress,
            });
        }
    }
}
