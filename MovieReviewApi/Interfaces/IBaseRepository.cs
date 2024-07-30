using MovieReviewApi.Models;
using System.Linq.Expressions;

namespace MovieReviewApi.Interfaces
{
    public interface IBaseRepository<T>
    {
        public List<T> GetAll();
        public bool Update(T model);
        public bool Delete(T model);
        public bool Save();
    }
}
