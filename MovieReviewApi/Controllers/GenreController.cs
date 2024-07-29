using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MovieReviewApi.Data;
using MovieReviewApi.Dto;
using MovieReviewApi.Interfaces;
using MovieReviewApi.Mappers;
using MovieReviewApi.Models;

namespace MovieReviewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository _genreRepository;

        public GenreController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        [HttpGet]
        public ActionResult<List<GenreDto>> GetAll()
        {
            return Ok(_genreRepository.GetGenres().ToDto());
        }

        [HttpGet("byid/{id}")]
        public ActionResult<GenreDto> GetById(int id)
        {
            if (!_genreRepository.GenreExistById(id))
            {
                return NotFound("Invalid Index");
            }
            return _genreRepository.GetGenreById(id).ToDto();
        }

        [HttpGet("byname/{name}")]
        public ActionResult<GenreDto> GetByName(string name)
        {
            if (!_genreRepository.GenreExistByName(name)) 
            {
                return NotFound("Invalid Name");
            }
            return _genreRepository.GetGenreByName(name).ToDto();
        }

        [HttpPost]
        public IActionResult Create(GenreDto dto)
        {
            if (!ModelState.IsValid || dto.Id != 0)
            {
                return BadRequest("Model is not valid");
            }
            if (!_genreRepository.CreateGenre(dto.ToModel()))
            {
                return BadRequest("Something went wrong while saving the changes");
            }
            return Created();
        }

        [HttpPut]
        public IActionResult Update(int id, GenreDto dto)
        {
            if (!ModelState.IsValid || dto.Id == 0)
            {
                return BadRequest("Model is not valid");
            }
            if (_genreRepository.GenreExistById(id))
            {
                NotFound("Invalid Index");
            }
            dto.Id = id;
            if (!_genreRepository.UpdateGenre(dto.ToModel()))
            {
                return BadRequest("Something went wrong while saving the changes");
            }
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var genre = _genreRepository.GetGenreById(id);
            if(genre == null)
            {
                return NotFound("Invalid Index");
            }
            if (!_genreRepository.DeleteGenre(genre))
            {
                return BadRequest("Something went wrong while saving the changes");
            }
            return Ok();
        }
    }
}
