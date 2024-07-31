using Microsoft.EntityFrameworkCore;
using MovieReviewApi.Data;
using MovieReviewApi.Interfaces;
using MovieReviewApi.Models;

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

    }
}
