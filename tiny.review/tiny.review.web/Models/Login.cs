namespace tiny.review.web.Models
{
    public class Login
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public User User { get; set; }
    }
}