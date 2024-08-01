using Microsoft.EntityFrameworkCore;
using MovieReviewApi.Data;
using MovieReviewApi.Interfaces;
using MovieReviewApi.Models;
using MovieReviewApi.Models.Account;

namespace MovieReviewApi.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(Role model)
        {
            _context.Roles.Add(model);
            return Save();
        }

        public bool Delete(Role model)
        {
            _context.Roles.Remove(model);
            return Save();
        }

        public List<Role> GetAll()
        {
            return _context.Roles.ToList();
        }

        public Role GetRoleById(int id)
        {
            return _context.Roles.Where(x => x.Id == id).FirstOrDefault();
        }

        public Role GetRoleByName(string name)
        {
            return _context.Roles.Where(x => x.Name == name).FirstOrDefault();
        }

        public bool RoleExistById(int id)
        {
            return _context.Roles.Where(x => x.Id == id).Any();
        }

        public bool RoleExistByName(string name)
        {
            return _context.Roles.Where(x => x.Name == name).Any();

        }

        public bool Save()
        {
            var result = _context.SaveChanges();
            return result > 0 ? true : false;
        }

        public bool Update(Role model)
        {
            _context.Roles.Update(model);
            return Save();
        }

        public List<Role> GetRolesOfAUser(int userId)
        {
            return _context.UserRoles.Where(x => x.User.Id == userId).Select(x => x.Role).ToList();
        }

        public bool AddRoleToUser(int userId, int roleId)
        {
            var user = _context.Users.Where(x=> x.Id == userId).FirstOrDefault();
            var role = _context.Roles.Where(x => x.Id == roleId).FirstOrDefault();
            UserRole userRole = new UserRole
            {
                User = user, 
                Role = role
            };

            _context.UserRoles.Add(userRole);
            return Save();
        }

        public bool RemoveRoleOfAUser(int userId, int roleId)
        {
            var userRole = _context.UserRoles.Where(x => x.RoleId == roleId && x.User.Id == userId).FirstOrDefault();
            _context.UserRoles.Remove(userRole);

            return Save();
        }
    }
}
