namespace MovieReviewApi.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public DateTime PostDate { get; set; }
        public User Reviewer { get; set; }
        public Movie Movie { get; set; }
    }
}
