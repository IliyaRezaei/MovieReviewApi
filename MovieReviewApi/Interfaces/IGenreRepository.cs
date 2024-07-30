using Microsoft.AspNetCore.Mvc;
using MovieReviewApi.Dto;
using MovieReviewApi.Models;

namespace MovieReviewApi.Interfaces
{
    public interface IGenreRepository : IBaseRepository<Genre>
    {
        public bool Create(Genre model);
        public Genre GetGenreById(int id);
        public Genre GetGenreByName(string name);
        public bool GenreExistById(int id);
        public bool GenreExistByName(string name);
    }
}
