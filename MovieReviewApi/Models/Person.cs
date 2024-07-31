namespace MovieReviewApi.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public DateTime Birthdate { get; set; }
        public ICollection<Movie>? Movies { get; set; }
    }
}
