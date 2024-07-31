using MovieReviewApi.Models;

namespace MovieReviewApi.Interfaces
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        public bool Create(Role model);
        public Role GetRoleById(int id);
        public Role GetRoleByName(string name);
        public bool RoleExistById(int id);
        public bool RoleExistByName(string name);
    }
}
