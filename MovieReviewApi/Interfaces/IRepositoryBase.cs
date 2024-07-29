using MovieReviewApi.Models;
using System.Linq.Expressions;

namespace MovieReviewApi.Interfaces
{
    public interface IRepositoryBase<T>
    {
        public List<T> GetAll();
        public bool Create(T model);
        public bool Update(T model);
        public bool Delete(T model);
        public bool Save();
    }
}
