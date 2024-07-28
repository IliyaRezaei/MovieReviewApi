namespace MovieReviewApi.Dto
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Plot { get; set; }
        public int LengthInMinutes { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
