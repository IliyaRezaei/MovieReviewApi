using MovieReviewApi.Dto;
using MovieReviewApi.Models;

namespace MovieReviewApi.Mappers
{
    public static class ReviewMapper
    {
        public static ReviewDto ToDto(this Review review)
        {
            ReviewDto reviewDto = new ReviewDto
            {
                Id = review.Id,
                Text = review.Text,
                Rating = review.Rating,
                PostDate = review.PostDate,
            };
            return reviewDto;
        }
        public static List<ReviewDto> ToDto(this List<Review> review)
        {
            List<ReviewDto> reviewDtos = new List<ReviewDto>();
            foreach (var item in review)
            {
                var reviewDto = new ReviewDto
                {
                    Id = item.Id,
                    Text = item.Text,
                    Rating = item.Rating,
                    PostDate = item.PostDate,
                };
                reviewDtos.Add(reviewDto);
            }
            return reviewDtos;
        }

        public static Review ToModel(this ReviewDto reviewDto)
        {
            Review review = new Review
            {
                Id = reviewDto.Id,
                Text = reviewDto.Text,
                Rating = reviewDto.Rating,
                PostDate = reviewDto.PostDate,
            };
            return review;
        }

        public static List<Review> ToModel(this List<ReviewDto> reviewDto)
        {
            List<Review> reviews = new List<Review>();
            foreach (var item in reviewDto)
            {
                var review = new Review
                {
                    Id = item.Id,
                    Text = item.Text,
                    Rating = item.Rating,
                    PostDate = item.PostDate,
                };
                reviews.Add(review);
            }
            return reviews;
        }
    }
}
