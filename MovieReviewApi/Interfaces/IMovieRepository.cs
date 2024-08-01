using MovieReviewApi.Models;

namespace MovieReviewApi.Interfaces
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        public bool Create(Movie model);
        public Movie GetMovieById(int id);
        public Movie GetMovieByName(string name);
        public bool MovieExistById(int id);
        public bool MovieExistByName(string name);
    }
}
