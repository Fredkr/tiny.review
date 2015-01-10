using System.Collections.Generic;
using tiny.review.core.DataModels;

namespace tiny.review.core.Reviews
{
    public interface IReviewService
    {
        IEnumerable<Review> GetUserReviews(string userName);
        Review GetUserReview(string userName, string revviewId);
        bool AddReview(string userName, string title, string description, int rating);
    }
}
