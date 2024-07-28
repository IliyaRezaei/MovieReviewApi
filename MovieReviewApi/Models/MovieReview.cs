using MovieReviewApi.Models.Account;
using System.ComponentModel.DataAnnotations;

namespace MovieReviewApi.Models
{
    public class MovieReview
    {
        public int MovieId { get; set; }
        public int ReviewId { get; set; }
        public Movie Movie { get; set; }
        public Review Review { get; set; }
    }
}
