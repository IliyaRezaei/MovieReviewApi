using Microsoft.EntityFrameworkCore;
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

        public bool Create(Movie model)
        {
            _context.Movies.Add(model);
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

        public List<Movie> getAllWithCrew()
        {
            return _context.Movies.Include(x=> x.MovieCrew).ToList();
        }

        public List<Genre> GetAllGenresOfAMovie(int movieId) 
        {
            return _context.MovieGenres.Where(x=> x.MovieId == movieId).Select(g => g.Genre).ToList();
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

        public bool AddMovieGenre(int movieId, int genreId)
        {
            Movie movie = _context.Movies.Where(x => x.Id == movieId).FirstOrDefault();
            Genre genre = _context.Genres.Where(x => x.Id == genreId).FirstOrDefault();
            MovieGenre movieGenre = new MovieGenre
            {
                Movie = movie,
                Genre = genre
            };
            _context.MovieGenres.Add(movieGenre);
            return Save();
        }

        public bool AddMovieActor(int movieId, int actorId)
        {
            Movie movie = _context.Movies.Where(x => x.Id == movieId).FirstOrDefault();
            Person actor = _context.MovieCrew.Where(x => x.Id == actorId).FirstOrDefault();
            MovieActor movieActor = new MovieActor 
            { 
                Movie = movie,
                Actor = actor
            };
            _context.MovieActors.Add(movieActor);
            return Save();
        }

        public bool AddMovieDirector(int movieId, int directorId)
        {
            Movie movie = _context.Movies.Where(x => x.Id == movieId).FirstOrDefault();
            Person director = _context.MovieCrew.Where(x => x.Id == directorId).FirstOrDefault();
            MovieDirector movieDirector = new MovieDirector
            {
                Movie = movie,
                Director = director
            };
            _context.MovieDirectors.Add(movieDirector);
            return Save();
        }
    }
}
