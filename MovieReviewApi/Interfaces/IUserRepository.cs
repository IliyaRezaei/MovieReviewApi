using MovieReviewApi.Models;

namespace MovieReviewApi.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public bool Create(User model);
        public User GetUserById(int id);
        public User GetUserByName(string name);
        public List<User> GetUsersByRoleId(int roleId);
        public bool UserExistById(int id);
        public bool UserExistByName(string name);
    }
}
