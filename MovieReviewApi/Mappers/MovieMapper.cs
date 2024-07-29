using MovieReviewApi.Dto;
using MovieReviewApi.Models;

namespace MovieReviewApi.Mappers
{
    public static class MovieMapper
    {
        public static MovieDto ToDto(this Movie movie)
        {
            MovieDto movieDto = new MovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Plot = movie.Plot,
                LengthInMinutes = movie.LengthInMinutes,
                ReleaseDate = movie.ReleaseDate,
            };
            return movieDto;
        }
        public static List<MovieDto> ToDto(this List<Movie> movie)
        {
            List<MovieDto> movieDtos = new List<MovieDto>();
            foreach (var item in movie)
            {
                var movieDto = new MovieDto
                {
                    Id = item.Id,
                    Title = item.Title,
                    Plot = item.Plot,
                    LengthInMinutes = item.LengthInMinutes,
                    ReleaseDate = item.ReleaseDate,
                };
                movieDtos.Add(movieDto);
            }
            return movieDtos;
        }

        public static Movie ToModel(this MovieDto movieDto)
        {
            Movie movie = new Movie
            {
                Id = movieDto.Id,
                Title = movieDto.Title,
                Plot = movieDto.Plot,
                LengthInMinutes = movieDto.LengthInMinutes,
                ReleaseDate = movieDto.ReleaseDate,
            };
            return movie;
        }

        public static List<Movie> ToModel(this List<MovieDto> movieDto)
        {
            List<Movie> movies = new List<Movie>();
            foreach (var item in movieDto)
            {
                var movie = new Movie
                {
                    Id = item.Id,
                    Title = item.Title,
                    Plot = item.Plot,
                    LengthInMinutes = item.LengthInMinutes,
                    ReleaseDate = item.ReleaseDate,
                };
                movies.Add(movie);
            }
            return movies;
        }
    }
}
