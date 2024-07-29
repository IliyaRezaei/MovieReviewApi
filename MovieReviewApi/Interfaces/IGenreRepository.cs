using Microsoft.AspNetCore.Mvc;
using MovieReviewApi.Dto;
using MovieReviewApi.Models;

namespace MovieReviewApi.Interfaces
{
    public interface IGenreRepository
    {
        public List<Genre> GetGenres();
        public Genre GetGenreById(int id);
        public Genre GetGenreByName(string name);
        public bool CreateGenre(Genre model);
        public bool UpdateGenre(Genre model);
        public bool DeleteGenre(Genre model);
        public bool GenreExistById(int id);
        public bool GenreExistByName(string name);
        public bool Save();
    }
}
