using Microsoft.AspNetCore.Mvc;
using MovieReviewApi.Dto;
using MovieReviewApi.Interfaces;
using MovieReviewApi.Mappers;

namespace MovieReviewApi.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        private readonly IImageUploadHandler _imageUploadHandler;
        public PersonController(IPersonRepository personRepository, IImageUploadHandler imageUploadHandler)
        {
            _personRepository = personRepository;
            _imageUploadHandler = imageUploadHandler;
        }

        [HttpGet]
        public ActionResult<List<PersonDto>> GetAll()
        {
            return Ok(_personRepository.GetAll().ToDto());
        }

        [HttpGet("byId/{id}")]
        public ActionResult<PersonDto> GetById([FromRoute] int id)
        {
            if (!_personRepository.PersonExistById(id))
            {
                return NotFound("Invalid Index");
            }
            return _personRepository.GetPersonById(id).ToDto();
        }

        [HttpGet("byName/{name}")]
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

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, PersonDto dto)
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

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
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

        [HttpPost("UploadImage")]
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
            person.ImageUrl = _imageUploadHandler.UploadImage(file, person.Fullname, Enums.ImageUploadType.Person);
            if (!_personRepository.Save())
            {
                return BadRequest("Something went wrong");
            }
            return Ok(person.ImageUrl);
        }
    }
}
