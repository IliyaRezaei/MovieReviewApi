using MovieReviewApi.Data;
using MovieReviewApi.Interfaces;

namespace MovieReviewApi.Repository
{
    public class RepositoryBase : IRepositoryBase<T>
    {
        private readonly ApplicationDbContext _context;

        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }


        public bool Create(T model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(T model)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(T model)
        {
            throw new NotImplementedException();
        }
    }
}
