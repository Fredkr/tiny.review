
namespace tiny.review.core.DataModels
{
    public class Review : IDbType
    {

        public string Title { get; set; }
        public string Decscription { get; set; }
        public int Rating { get; set; }


        public void Update(IDbType entity)
        {
            Title = ((Review)entity).Title;
            Decscription = ((Review)entity).Decscription;
            Rating = ((Review)entity).Rating;
        }
    }
}
