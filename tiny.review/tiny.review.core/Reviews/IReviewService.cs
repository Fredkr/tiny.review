using System.Collections.Generic;
using tiny.review.core.DataModels;

namespace tiny.review.core.Reviews
{
    public interface IReviewService
    {
        IEnumerable<Review> GetUserReviews(string userName);
        bool AddReview(string userName, string title, string description, int rating);
    }
}
