using Microsoft.AspNetCore.Mvc;
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
        public bool AddMovieGenre(int movieId, int genreId);
        public bool AddMovieActor(int movieId, int actorId);
        public bool AddMovieDirector(int movieId, int directorId);
    }
}
