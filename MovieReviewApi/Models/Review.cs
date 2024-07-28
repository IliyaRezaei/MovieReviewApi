using MovieReviewApi.Models.Account;

namespace MovieReviewApi.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public AccountUser AccountUser { get; set; }
        public Movie Movie { get; set; }
    }
}
