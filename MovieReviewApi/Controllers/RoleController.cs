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
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;

        public RoleController(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        [HttpGet]
        public ActionResult<List<RoleDto>> GetAll()
        {
            return Ok(_roleRepository.GetAll().ToDto());
        }

        [HttpGet("getById/{id}")]
        public ActionResult<RoleDto> GetById(int id)
        {
            if (!_roleRepository.RoleExistById(id))
            {
                return NotFound("Invalid Index");
            }
            return _roleRepository.GetRoleById(id).ToDto();
        }

        [HttpGet("getByName/{name}")]
        public ActionResult<RoleDto> GetByName(string name)
        {
            if (!_roleRepository.RoleExistByName(name))
            {
                return NotFound("Invalid Name");
            }
            return _roleRepository.GetRoleByName(name).ToDto();
        }

        [HttpPost]
        public IActionResult Create(RoleDto dto)
        {
            if (!ModelState.IsValid || dto.Id != 0)
            {
                return BadRequest("Model is not valid");
            }
            if (!_roleRepository.Create(dto.ToModel()))
            {
                return BadRequest("Something went wrong while saving the changes");
            }
            return Created("", "Successfully Created");
        }

        [HttpPut]
        public IActionResult Update(int id, RoleDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is not valid");
            }
            if (_roleRepository.RoleExistById(id))
            {
                NotFound("Invalid Index");
            }
            dto.Id = id;
            if (!_roleRepository.Update(dto.ToModel()))
            {
                return BadRequest("Something went wrong while saving the changes");
            }
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var genre = _roleRepository.GetRoleById(id);
            if (genre == null)
            {
                return NotFound("Invalid Index");
            }
            if (!_roleRepository.Delete(genre))
            {
                return BadRequest("Something went wrong while saving the changes");
            }
            return NoContent();
        }

        [HttpGet("getRolesOfAUser/{userId}")]
        public ActionResult<List<RoleDto>> GetRolesOfAUser(int userId)
        {
            return _roleRepository.GetRolesOfAUser(userId).ToDto();
        }

        [HttpPost("addUserRole/{userId}/{roleId}")]
        public IActionResult AddRoleToUser(int userId, int roleId)
        {
            if (!_roleRepository.RoleExistById(roleId) && !_userRepository.UserExistById(userId))
            {
                return BadRequest("Wrong Indexes");
            }
            if(!_roleRepository.AddRoleToUser(userId, roleId))
            {
                return BadRequest("Failed at saving(someone deleted it before)");
            }
            return Ok("Role Successfully added to user");
        }

        [HttpPost("removeUserRole/{userId}/{roleId}")]
        public IActionResult RemoveRoleOfAUser(int userId, int roleId)
        {
            if (!_roleRepository.RoleExistById(roleId) && !_userRepository.UserExistById(userId))
            {
                return BadRequest("Wrong Indexes");
            }
            if (!_roleRepository.RemoveRoleOfAUser(userId, roleId))
            {
                return BadRequest("Failed at saving(someone deleted it before)");
            }
            return Ok("Role Successfully removed from user");
        }
    }
}
