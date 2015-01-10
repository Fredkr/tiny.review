
namespace tiny.review.core.DataModels
{
    public class Review : IDbType
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public string Id { get; set; }


        public void Update(IDbType entity)
        {
            Title = ((Review)entity).Title;
            Description = ((Review)entity).Description;
            Rating = ((Review)entity).Rating;
        }
    }
}
