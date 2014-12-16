
namespace tiny.review.core.DataModels
{
    public class User : IDbType
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string EmailAdress { get; set; }

        public void Update(IDbType entity)
        {
            UserId = ((User)entity).UserId;
            UserName = ((User)entity).UserName;
            EmailAdress = ((User)entity).EmailAdress;
        }
    }
}
