using MovieReviewApi.Data;
using MovieReviewApi.Interfaces;
using MovieReviewApi.Models;

namespace MovieReviewApi.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _context;
        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Create(Person model)
        {
            _context.MovieCrew.Add(model);
            return Save();
        }

        public bool Delete(Person model)
        {
            _context.MovieCrew.Remove(model);
            return Save();
        }

        public List<Person> GetAll()
        {
            return _context.MovieCrew.ToList();
        }

        public Person GetPersonById(int id)
        {
            return _context.MovieCrew.Where(x => x.Id == id).FirstOrDefault();
        }

        public Person GetPersonByName(string name)
        {
            return _context.MovieCrew.Where(x=> x.Fullname == name).FirstOrDefault();
        }

        public bool PersonExistById(int id)
        {
            return _context.MovieCrew.Where(x => x.Id == id).Any();
        }

        public bool PersonExistByName(string name)
        {
            return _context.MovieCrew.Where(x=> x.Fullname == name).Any();
        }

        public bool Save()
        {
            var result = _context.SaveChanges();
            return result > 0 ? true : false;
        }

        public bool Update(Person model)
        {
            _context.MovieCrew.Update(model);
            return Save();
        }
    }
}
