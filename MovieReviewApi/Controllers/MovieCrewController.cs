using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieReviewApi.Dto;
using MovieReviewApi.Interfaces;
using MovieReviewApi.Mappers;
using MovieReviewApi.Repository;

namespace MovieReviewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieCrewController : ControllerBase
    {
        private readonly IMovieCrewRepository _movieCrewRepository;

        public MovieCrewController(IMovieCrewRepository movieCrewRepository)
        {
            _movieCrewRepository = movieCrewRepository;
        }

        [HttpGet]
        public ActionResult<List<PersonDto>> GetAll()
        {
            return Ok(_movieCrewRepository.GetAll().ToDto());
        }

        [HttpGet("byid/{id}")]
        public ActionResult<PersonDto> GetById(int id)
        {
            if (!_movieCrewRepository.PersonExistById(id))
            {
                return NotFound("Invalid Index");
            }
            return _movieCrewRepository.GetPersonById(id).ToDto();
        }

        [HttpGet("byname/{name}")]
        public ActionResult<PersonDto> GetByName(string name)
        {
            //i can split string into two strings and see if the list contain the name or not if it does we retrieve it
            if (!_movieCrewRepository.PersonExistByName(name))
            {
                return NotFound("Invalid Name");
            }
            return _movieCrewRepository.GetPersonByName(name).ToDto();
        }

        [HttpPost]
        public IActionResult Create(PersonDto dto)
        {
            if (!ModelState.IsValid || dto.Id != 0)
            {
                return BadRequest("Model is not valid");
            }
            if (!_movieCrewRepository.Create(dto.ToModel()))
            {
                return BadRequest("Something went wrong while saving the changes");
            }
            // url of the created object
            return Created("", "Successfully Created");
        }

        [HttpPut]
        public IActionResult Update(int id, PersonDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is not valid");
            }
            if (_movieCrewRepository.PersonExistById(id))
            {
                NotFound("Invalid Index");
            }
            dto.Id = id;
            if (!_movieCrewRepository.Update(dto.ToModel()))
            {
                return BadRequest("Something went wrong while saving the changes");
            }
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var movie = _movieCrewRepository.GetPersonById(id);
            if (movie == null)
            {
                return NotFound("Invalid Index");
            }
            if (!_movieCrewRepository.Delete(movie))
            {
                return BadRequest("Something went wrong while saving the changes");
            }
            return NoContent();
        }
    }
}
