﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieReviewApi.Dto;
using MovieReviewApi.Interfaces;
using MovieReviewApi.Mappers;

namespace MovieReviewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet]
        public ActionResult<List<MovieDto>> GetAll()
        {
            return Ok(_movieRepository.GetMovies().ToDto());
        }

        [HttpGet("byid/{id}")]
        public ActionResult<MovieDto> GetById(int id)
        {
            if (!_movieRepository.MovieExistById(id))
            {
                return NotFound("Invalid Index");
            }
            return _movieRepository.GetMovieById(id).ToDto();
        }

        [HttpGet("byname/{name}")]
        public ActionResult<MovieDto> GetByName(string name)
        {
            if (!_movieRepository.MovieExistByName(name))
            {
                return NotFound("Invalid Name");
            }
            return _movieRepository.GetMovieByName(name).ToDto();
        }

        [HttpPost]
        public IActionResult Create(MovieDto dto)
        {
            if (!ModelState.IsValid || dto.Id != 0)
            {
                return BadRequest("Model is not valid");
            }
            if (!_movieRepository.CreateMovie(dto.ToModel()))
            {
                return BadRequest("Something went wrong while saving the changes");
            }
            return Created("", "Successfully Created");
        }

        [HttpPut]
        public IActionResult Update(int id, MovieDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is not valid");
            }
            if (_movieRepository.MovieExistById(id))
            {
                NotFound("Invalid Index");
            }
            dto.Id = id;
            if (!_movieRepository.UpdateMovie(dto.ToModel()))
            {
                return BadRequest("Something went wrong while saving the changes");
            }
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var movie = _movieRepository.GetMovieById(id);
            if (movie == null)
            {
                return NotFound("Invalid Index");
            }
            if (!_movieRepository.DeleteMovie(movie))
            {
                return BadRequest("Something went wrong while saving the changes");
            }
            return NoContent();
        }
    }
}
