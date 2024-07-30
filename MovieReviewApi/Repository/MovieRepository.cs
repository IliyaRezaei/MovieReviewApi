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

        public bool Create(Movie model, int genreId)
        {
            _context.Movies.Add(model);
            Genre genre = _context.Genres.Where(x=> x.Id == genreId).FirstOrDefault();
            MovieGenre movieGenre = new MovieGenre 
            {
                Movie = model,
                Genre = genre
            };
            _context.Add(movieGenre);
            return Save();
        }

        public bool Delete(Movie model)
        {
            _context.Movies.Remove(model);
            return Save();
        }

        public List<Movie> GetAll()
        {
            return _context.Movies.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _context.Movies.Where(x=> x.Id == id).FirstOrDefault();
        }

        public Movie GetMovieByName(string name)
        {
            return _context.Movies.Where(x => x.Title == name).FirstOrDefault();
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

        public bool Update(Movie model)
        {
            _context.Movies.Update(model);
            return Save();
        }

    }
}
