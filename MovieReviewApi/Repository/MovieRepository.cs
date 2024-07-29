using MovieReviewApi.Data;
using MovieReviewApi.Interfaces;
using MovieReviewApi.Models;

namespace MovieReviewApi.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateMovie(Movie model)
        {
            _context.Movies.Add(model);
            return Save();
        }

        public bool DeleteMovie(Movie model)
        {
            _context.Movies.Remove(model);
            return Save();
        }

        public Movie GetMovieById(int id)
        {
            return _context.Movies.Where(x=> x.Id == id).FirstOrDefault();
        }

        public Movie GetMovieByName(string name)
        {
            return _context.Movies.Where(x => x.Title == name).FirstOrDefault();
        }

        public List<Movie> GetMovies()
        {
            return _context.Movies.ToList();
        }

        public bool MovieExistById(int id)
        {
            return _context.Movies.Where(x=> x.Id == id).Any();
        }

        public bool MovieExistByName(string name)
        {
            return _context.Movies.Where(x => x.Title == name).Any();
        }

        public bool Save()
        {
            var result = _context.SaveChanges();
            return result > 0 ? true : false;
        }

        public bool UpdateMovie(Movie model)
        {
            _context.Movies.Update(model);
            return Save();
        }
    }
}
