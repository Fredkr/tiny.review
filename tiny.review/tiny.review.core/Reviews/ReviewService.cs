using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using tiny.review.core.DataModels;
using tiny.review.core.RavenDb;

namespace tiny.review.core.Reviews
{
    public class ReviewService : IReviewService
    {
        private readonly DbManager db;

        public ReviewService(DbManager db)
        {
            this.db = db;
        }

        public IEnumerable<Review> GetUserReviews(string userName)
        {
            Expression<Func<User, bool>> query = u => u.UserName.Equals(userName);
            var user = db.GetDocument(query);
            return user.Reviews;
        }

        public Review GetUserReview(string userName, string reviewId)
        {
            var reviews = GetUserReviews(userName);
            return reviews.FirstOrDefault(r => r.Id == reviewId);
        }
        public bool AddReview(string userName, string title, string description, int rating)
        {
            Expression<Func<User, bool>> query = u => u.UserName.Equals(userName);
            var user = db.GetDocument(query);
            user.Reviews.Add(new Review
            {
                Id = Guid.NewGuid().ToString("N"),
                Title = title,
                Description = description,
                Rating = rating
            });
            return db.Uppdate(query,user);
        }
    }
}
