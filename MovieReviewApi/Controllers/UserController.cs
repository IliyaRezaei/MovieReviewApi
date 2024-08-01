using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieReviewApi.Dto;
using MovieReviewApi.Interfaces;
using MovieReviewApi.Mappers;
using MovieReviewApi.Repository;

namespace MovieReviewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {

            _userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult<List<UserDto>> GetAll()
        {
            return Ok(_userRepository.GetAll().ToDto());
        }

        [HttpGet("getById/{id}")]
        public ActionResult<UserDto> GetById(int id)
        {
            if (!_userRepository.UserExistById(id))
            {
                return NotFound("Invalid Index");
            }
            return _userRepository.GetUserById(id).ToDto();
        }

        [HttpGet("getByName/{name}")]
        public ActionResult<UserDto> GetByName(string name)
        {
            if (!_userRepository.UserExistByName(name))
            {
                return NotFound("Invalid Name");
            }
            return _userRepository.GetUserByName(name).ToDto();
        }

        [HttpPost]
        public IActionResult Create(UserDto dto, int roleId)
        {
            if (!ModelState.IsValid || dto.Id != 0)
            {
                return BadRequest("Model is not valid");
            }
            if (!_userRepository.Create(dto.ToModel()))
            {
                return BadRequest("Something went wrong while saving the changes");
            }
            return Created("", "Successfully Created");
        }

        [HttpPut]
        public IActionResult Update(int id, UserDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is not valid");
            }
            if (_userRepository.UserExistById(id))
            {
                NotFound("Invalid Index");
            }
            dto.Id = id;
            if (!_userRepository.Update(dto.ToModel()))
            {
                return BadRequest("Something went wrong while saving the changes");
            }
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var genre = _userRepository.GetUserById(id);
            if (genre == null)
            {
                return NotFound("Invalid Index");
            }
            if (!_userRepository.Delete(genre))
            {
                return BadRequest("Something went wrong while saving the changes");
            }
            return NoContent();
        }

        [HttpGet("GetUsersByRoleId/{roleId}")]
        public ActionResult<List<UserDto>> GetUsersByRoleId(int roleId)
        {
            return _userRepository.GetUsersByRoleId(roleId).ToDto();
        }

        
    }
}
