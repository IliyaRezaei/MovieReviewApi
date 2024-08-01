using MovieReviewApi.Data;
using MovieReviewApi.Interfaces;
using MovieReviewApi.Models;

namespace MovieReviewApi.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _context;
        public ReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(Review model, int userId)
        {
            var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();
            user.Reviews.Add(model);
            _context.Reviews.Add(model);
            
            return Save();
        }

        public bool Delete(Review model)
        {
            _context.Reviews.Remove(model);
            return Save();
        }

        public List<Review> GetAll()
        {
            return _context.Reviews.ToList();
        }

        public Review GetReviewById(int id)
        {
            return _context.Reviews.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool ReviewExistById(int id)
        {
            return _context.Reviews.Where(x => x.Id == id).Any();
        }

        public bool Save()
        {
            var result = _context.SaveChanges();
            return result > 0 ? true : false;
        }

        public bool Update(Review model)
        {
            _context.Reviews.Update(model);
            return Save();
        }
    }
}
