using MovieReviewApi.Dto;
using MovieReviewApi.Models;

namespace MovieReviewApi.Interfaces
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        public bool Create(Person model);
        public Person GetPersonById(int id);
        public Person GetPersonByName(string name);
        public bool PersonExistById(int id);
        public bool PersonExistByName(string name);
    }
}
