using Microsoft.AspNetCore.Mvc;
using MovieReviewApi.Dto;
using MovieReviewApi.Interfaces;
using MovieReviewApi.Mappers;
using MovieReviewApi.Models;

namespace MovieReviewApi.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IUserRepository _userRepository;
        public ReviewController(IReviewRepository reviewRepository, IUserRepository userRepository)
        {
            _reviewRepository = reviewRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult<List<ReviewDto>> GetAll()
        {
            return Ok(_reviewRepository.GetAll().ToDto());
        }

        [HttpGet("byId/{id}")]
        public ActionResult<ReviewDto> GetById([FromRoute] int id)
        {
            if (!_reviewRepository.ReviewExistById(id))
            {
                return NotFound("Invalid Index");
            }
            return _reviewRepository.GetReviewById(id).ToDto();
        }

        [HttpPost]
        public IActionResult Create(ReviewDto dto, [FromQuery] int userId, [FromQuery] int movieId)
        {
            if (!ModelState.IsValid || dto.Id != 0)
            {
                return BadRequest("Model is not valid");
            }
            //use jwt or cookie and user.identity to get name or id of the user
            if (!_reviewRepository.Create(dto.ToModel(), userId, movieId))
            {
                return BadRequest("Something went wrong while saving the changes");
            }
            return Created("", "Successfully Created");
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, ReviewDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is not valid");
            }
            if (_reviewRepository.ReviewExistById(id))
            {
                NotFound("Invalid Index");
            }
            dto.Id = id;
            if (!_reviewRepository.Update(dto.ToModel()))
            {
                return BadRequest("Something went wrong while saving the changes");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var movie = _reviewRepository.GetReviewById(id);
            if (movie == null)
            {
                return NotFound("Invalid Index");
            }
            if (!_reviewRepository.Delete(movie))
            {
                return BadRequest("Something went wrong while saving the changes");
            }
            return NoContent();
        }

        [HttpGet("GetUserReviewsById/{userId}")]
        public ActionResult<List<Review>> GetUserReviewsById([FromRoute] int userId)
        {
            if (!_userRepository.UserExistById(userId))
            {
                return BadRequest("Invalid Index");
            }
            return Ok(_reviewRepository.GetUserReviewsById(userId).ToDto());
        }
    }
}
