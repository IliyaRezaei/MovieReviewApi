using Microsoft.EntityFrameworkCore;
using MovieReviewApi.Data;
using MovieReviewApi.Interfaces;
using MovieReviewApi.Models;
using MovieReviewApi.Models.Account;
using System.Data;

namespace MovieReviewApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(User model)
        {
            _context.Users.Add(model);
            var role = _context.Roles.FirstOrDefault(x=> x.Name == "User");
            UserRole userRole = new UserRole
            {
                User = model,
                Role = role
            };
            _context.Add(userRole);
            return Save();
        }

        public bool Delete(User model)
        {
            _context.Users.Remove(model);
            return Save();
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.Where(x => x.Id == id).FirstOrDefault();
        }

        public User GetUserByName(string name)
        {
            return _context.Users.Where(x => x.Username == name).FirstOrDefault();
        }

        public bool UserExistById(int id)
        {
            return _context.Users.Where(x => x.Id == id).Any();
        }

        public bool UserExistByName(string name)
        {
            return _context.Users.Where(x => x.Username == name).Any();

        }

        public bool Save()
        {
            var result = _context.SaveChanges();
            return result > 0 ? true : false;
        }

        public bool Update(User model)
        {
            _context.Users.Update(model);
            return Save();
        }

        public List<User> GetUsersByRoleId(int roleId)
        {
            return _context.UserRoles.Where(p => p.Role.Id == roleId).Select(u=> u.User).ToList();
        }
    }
}
