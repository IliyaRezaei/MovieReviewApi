using MovieReviewApi.Models;

namespace MovieReviewApi.Interfaces
{
    public interface IReviewRepository : IBaseRepository<Review>
    {
        public bool Create(Review model, int userId);
        public Review GetReviewById(int id);
        public bool ReviewExistById(int id);
    }
}
