using Microsoft.CodeAnalysis.CSharp.Syntax;
using MovieReviewApi.Dto;
using MovieReviewApi.Models;

namespace MovieReviewApi.Mappers
{
    public static class GenreMapper
    {
        public static GenreDto ToDto(this Genre genre)
        {
            GenreDto genreDto = new GenreDto{
                Id = genre.Id,
                Name = genre.Name
            };
            return genreDto;
        }
        public static List<GenreDto> ToDto(this List<Genre> genre)
        {
            List<GenreDto> genreDtos = new List<GenreDto>();
            foreach (var item in genre)
            {
                var genreDto = new GenreDto
                {
                    Id = item.Id,
                    Name = item.Name,
                };
                genreDtos.Add(genreDto);
            }
            return genreDtos;
        }

        public static Genre ToModel(this GenreDto genreDto)
        {
            Genre genre = new Genre
            {
                Id = genreDto.Id,
                Name = genreDto.Name
            };
            return genre;
        }

        public static List<Genre> ToModel(this List<GenreDto> genreDto)
        {
            List<Genre> genres = new List<Genre>();
            foreach (var item in genreDto)
            {
                var genre = new Genre
                {
                    Id = item.Id,
                    Name = item.Name,
                };
                genres.Add(genre);
            }
            return genres;
        }
    }
}
