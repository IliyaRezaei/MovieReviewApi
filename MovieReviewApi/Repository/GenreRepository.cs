using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieReviewApi.Data;
using MovieReviewApi.Dto;
using MovieReviewApi.Interfaces;
using MovieReviewApi.Models;

namespace MovieReviewApi.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _context;

        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }

        public Genre GetGenreById(int id)
        {
            return _context.Genres.Where(x => x.Id == id).FirstOrDefault();
        }

        public Genre GetGenreByName(string name)
        {
            return _context.Genres.Where(x=> x.Name == name).FirstOrDefault();
        }

        public bool CreateGenre(Genre model)
        {
            _context.Genres.Add(model);
            return Save();
        }

        public bool DeleteGenre(Genre model)
        {
            _context.Remove(model);
            return Save();
        }

        public bool UpdateGenre(Genre model)
        {
            _context.Update(model);
            return Save();
        }

        public bool GenreExistById(int id)
        {
            return _context.Genres.Where(x=> x.Id == id).Any();
        }

        public bool GenreExistByName(string name)
        {
            return _context.Genres.Where(x => x.Name == name).Any();
        }

        public bool Save()
        {
            var result = _context.SaveChanges();
            return result > 0 ? true : false;
        }

        
    }
}
