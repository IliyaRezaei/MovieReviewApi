namespace MovieReviewApi.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Plot { get; set; }
        public int LengthInMinutes { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Actor>? Actors { get; set; }
        public ICollection<Director>? Directors { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }
}
