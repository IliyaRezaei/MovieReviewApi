using MovieReviewApi.Dto;
using MovieReviewApi.Models;

namespace MovieReviewApi.Mappers
{
    public static class PersonMapper
    {
        public static PersonDto ToDto(this Person person)
        {
            PersonDto personDto = new PersonDto
            {
                Id = person.Id,
                Fullname = person.Fullname
            };
            return personDto;
        }
        public static List<PersonDto> ToDto(this List<Person> person)
        {
            List<PersonDto> personDtos = new List<PersonDto>();
            foreach (var item in person)
            {
                var personDto = new PersonDto
                {
                    Id = item.Id,
                    Fullname = item.Fullname,
                };
                personDtos.Add(personDto);
            }
            return personDtos;
        }

        public static Person ToModel(this PersonDto personDto)
        {
            Person person = new Person
            {
                Id = personDto.Id,
                Fullname = personDto.Fullname
            };
            return person;
        }

        public static List<Person> ToModel(this List<PersonDto> personDto)
        {
            List<Person> people = new List<Person>();
            foreach (var item in personDto)
            {
                var person = new Person
                {
                    Id = item.Id,
                    Fullname = item.Fullname,
                };
                people.Add(person);
            }
            return people;
        }
    }
}
