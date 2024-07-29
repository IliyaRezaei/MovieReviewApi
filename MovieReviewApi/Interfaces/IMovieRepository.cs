using MovieReviewApi.Models;

namespace MovieReviewApi.Interfaces
{
    public interface IMovieRepository : IRepositoryBase<Movie>
    {
        public Movie GetMovieById(int id);
        public Movie GetMovieByName(string name);
        public bool MovieExistById(int id);
        public bool MovieExistByName(string name);
    }
}
