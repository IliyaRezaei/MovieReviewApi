using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieReviewApi.Dto;
using MovieReviewApi.Helpers;
using MovieReviewApi.Interfaces;
using MovieReviewApi.Mappers;
using MovieReviewApi.Repository;

namespace MovieReviewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        private readonly IUploadHandler _uploadHandler;
        public PersonController(IPersonRepository personRepository, IUploadHandler uploadHandler)
        {
            _personRepository = personRepository;
            _uploadHandler = uploadHandler;
        }

        [HttpGet]
        public ActionResult<List<PersonDto>> GetAll()
        {
            return Ok(_personRepository.GetAll().ToDto());
        }

        [HttpGet("getById/{id}")]
        public ActionResult<PersonDto> GetById(int id)
        {
            if (!_personRepository.PersonExistById(id))
            {
                return NotFound("Invalid Index");
            }
            return _personRepository.GetPersonById(id).ToDto();
        }

        [HttpGet("getByName/{name}")]
        public ActionResult<PersonDto> GetByName(string name)
        {
            if (!_personRepository.PersonExistByName(name))
            {
                return NotFound("Invalid Name");
            }
            return _personRepository.GetPersonByName(name).ToDto();
        }

        [HttpPost]
        public IActionResult Create(PersonDto dto)
        {
            if (!ModelState.IsValid || dto.Id != 0)
            {
                return BadRequest("Model is not valid");
            }
            if (!_personRepository.Create(dto.ToModel()))
            {
                return BadRequest("Something went wrong while saving the changes");
            }
            return Created("", "Successfully Created");
        }

        [HttpPut]
        public IActionResult Update(int id, PersonDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is not valid");
            }
            if (_personRepository.PersonExistById(id))
            {
                NotFound("Invalid Index");
            }
            dto.Id = id;
            if (!_personRepository.Update(dto.ToModel()))
            {
                return BadRequest("Something went wrong while saving the changes");
            }
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var genre = _personRepository.GetPersonById(id);
            if (genre == null)
            {
                return NotFound("Invalid Index");
            }
            if (!_personRepository.Delete(genre))
            {
                return BadRequest("Something went wrong while saving the changes");
            }
            return NoContent();
        }

        [HttpPost("UploadPersonImage")]
        public IActionResult UploadPersonImage(IFormFile file, int personId)
        {
            if (!_personRepository.PersonExistById(personId))
            {
                return NotFound("Invalid Index");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is not valid");
            }
            var person = _personRepository.GetPersonById(personId);
            var result = _uploadHandler.UploadPersonImage(file, person);
            if (!_personRepository.Save())
            {
                return BadRequest("Something went wrong");
            }
            return Ok(result);
        }
    }
}
