using System.ComponentModel.DataAnnotations;

namespace MovieReviewApi.Models
{
    public class MovieDirector
    {
        public int MovieId { get; set; }
        public int DirectorId { get; set; }

        public Movie Movie { get; set; }
        public Person Director { get; set; }
    }
}
