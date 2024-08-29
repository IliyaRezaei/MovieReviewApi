using Microsoft.AspNetCore.Mvc;
using MovieReviewApi.Dto;
using MovieReviewApi.Interfaces;
using MovieReviewApi.Mappers;

namespace MovieReviewApi.Controllers
{
    [Route("api/genres")]
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
            return Ok(_genreRepository.GetAll().ToDto());
        }

        [HttpGet("byId/{id}")]
        public ActionResult<GenreDto> GetById([FromRoute] int id)
        {
            if (!_genreRepository.GenreExistById(id))
            {
                return NotFound("Invalid Index");
            }
            return _genreRepository.GetGenreById(id).ToDto();
        }

        [HttpGet("byName/{name}")]
        public ActionResult<GenreDto> GetByName([FromRoute] string name)
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
            if (!_genreRepository.Create(dto.ToModel()))
            {
                return BadRequest("Something went wrong while saving the changes");
            }
            return Created("","Successfully Created");
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, GenreDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is not valid");
            }
            if (_genreRepository.GenreExistById(id))
            {
                NotFound("Invalid Index");
            }
            dto.Id = id;
            if (!_genreRepository.Update(dto.ToModel()))
            {
                return BadRequest("Something went wrong while saving the changes");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            var genre = _genreRepository.GetGenreById(id);
            if(genre == null)
            {
                return NotFound("Invalid Index");
            }
            if (!_genreRepository.Delete(genre))
            {
                return BadRequest("Something went wrong while saving the changes");
            }
            return NoContent();
        }
    }
}
