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

        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet]
        public ActionResult<List<RoleDto>> GetAll()
        {
            return Ok(_roleRepository.GetAll().ToDto());
        }

        [HttpGet("byid/{id}")]
        public ActionResult<RoleDto> GetById(int id)
        {
            if (!_roleRepository.RoleExistById(id))
            {
                return NotFound("Invalid Index");
            }
            return _roleRepository.GetRoleById(id).ToDto();
        }

        [HttpGet("byname/{name}")]
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
    }
}
