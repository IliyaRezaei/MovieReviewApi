﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieReviewApi.Dto;
using MovieReviewApi.Interfaces;
using MovieReviewApi.Mappers;
using MovieReviewApi.Repository;

namespace MovieReviewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        [HttpGet]
        public ActionResult<List<ReviewDto>> GetAll()
        {
            return Ok(_reviewRepository.GetAll().ToDto());
        }

        [HttpGet("getById/{id}")]
        public ActionResult<ReviewDto> GetById(int id)
        {
            if (!_reviewRepository.ReviewExistById(id))
            {
                return NotFound("Invalid Index");
            }
            return _reviewRepository.GetReviewById(id).ToDto();
        }

        [HttpPost]
        public IActionResult Create(ReviewDto dto, int userId)
        {
            if (!ModelState.IsValid || dto.Id != 0)
            {
                return BadRequest("Model is not valid");
            }
            //use jwt or cookie and user.identity to get name or id of the user
            if (!_reviewRepository.Create(dto.ToModel(), userId))
            {
                return BadRequest("Something went wrong while saving the changes");
            }
            return Created("", "Successfully Created");
        }

        [HttpPut]
        public IActionResult Update(int id, ReviewDto dto)
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

        [HttpDelete]
        public IActionResult Delete(int id)
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
    }
}
