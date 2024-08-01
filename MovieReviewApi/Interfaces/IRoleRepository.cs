using MovieReviewApi.Models;

namespace MovieReviewApi.Interfaces
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        public bool Create(Role model);
        public Role GetRoleById(int id);
        public Role GetRoleByName(string name);
        public List<Role> GetRolesOfAUser(int userId);
        public bool RoleExistById(int id);
        public bool RoleExistByName(string name);
        public bool AddRoleToUser(int userId, int roleId);
        public bool RemoveRoleOfAUser(int userId, int roleId);
    }
}
