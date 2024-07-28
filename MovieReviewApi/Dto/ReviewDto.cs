namespace MovieReviewApi.Dto
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public DateTime PostDate { get; set; }
    }
}
