using MovieReviewApi.Models;

namespace MovieReviewApi.Interfaces
{
    public interface IMovieRepository
    {
        public List<Movie> GetMovies();
        public Movie GetMovieById(int id);
        public Movie GetMovieByName(string name);
        public bool CreateMovie(Movie model);
        public bool UpdateMovie(Movie model);
        public bool DeleteMovie(Movie model);
        public bool MovieExistById(int id);
        public bool MovieExistByName(string name);
        public bool Save();
    }
}
