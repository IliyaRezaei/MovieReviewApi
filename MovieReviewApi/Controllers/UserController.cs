using Microsoft.AspNetCore.Mvc;
using MovieReviewApi.Dto;
using MovieReviewApi.Interfaces;
using MovieReviewApi.Mappers;

namespace MovieReviewApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IImageUploadHandler _imageUploadHandler;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UserController(IUserRepository userRepository, IImageUploadHandler imageUploadHandler, IWebHostEnvironment webHostEnvironment)
        {
            _userRepository = userRepository;
            _imageUploadHandler = imageUploadHandler;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public ActionResult<List<UserDto>> GetAll()
        {
            return Ok(_userRepository.GetAll().ToDto());
        }

        [HttpGet("byId/{id}")]
        public ActionResult<UserDto> GetById([FromRoute] int id)
        {
            if (!_userRepository.UserExistById(id))
            {
                return NotFound("Invalid Index");
            }
            return _userRepository.GetUserById(id).ToDto();
        }

        [HttpGet("byName/{name}")]
        public ActionResult<UserDto> GetByName([FromRoute] string name)
        {
            if (!_userRepository.UserExistByName(name))
            {
                return NotFound("Invalid Name");
            }
            return _userRepository.GetUserByName(name).ToDto();
        }

        [HttpPost]
        public IActionResult Create(UserDto dto)
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

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, UserDto dto)
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

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
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

        [HttpGet("byRoleId/{roleId}")]
        public ActionResult<List<UserDto>> GetUsersByRoleId([FromRoute] int roleId)
        {
            return _userRepository.GetUsersByRoleId(roleId).ToDto();
        }

        [HttpPost("UploadImage")]
        public IActionResult UploadUserImage(IFormFile file, int userId)
        {
            if (!_userRepository.UserExistById(userId))
            {
                return NotFound("Invalid Index");
            }
            if (!ModelState.IsValid) 
            {
                return BadRequest("Model is not valid");
            }
            var user = _userRepository.GetUserById(userId);
            user.ImageUrl = _imageUploadHandler.UploadImage(file, user.Username, Enums.ImageUploadType.User);
            if (!_userRepository.Save())
            {
                return BadRequest("Something went wrong");
            }
            return Ok(user.ImageUrl);
        }
    }
}
