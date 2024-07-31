using MovieReviewApi.Dto;
using MovieReviewApi.Models;

namespace MovieReviewApi.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToDto(this User user)
        {
            UserDto userDto = new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
            };
            return userDto;
        }
        public static List<UserDto> ToDto(this List<User> user)
        {
            List<UserDto> userDtos = new List<UserDto>();
            foreach (var item in user)
            {
                var userDto = new UserDto
                {
                    Id = item.Id,
                    Username = item.Username,
                    Email = item.Email,
                    PasswordHash = item.PasswordHash,
                };
                userDtos.Add(userDto);
            }
            return userDtos;
        }

        public static User ToModel(this UserDto userDto)
        {
            User user = new User
            {
                Id = userDto.Id,
                Username = userDto.Username,
                Email = userDto.Email,
                PasswordHash = userDto.PasswordHash,
            };
            return user;
        }

        public static List<User> ToModel(this List<UserDto> userDto)
        {
            List<User> users = new List<User>();
            foreach (var item in userDto)
            {
                var user = new User
                {
                    Id = item.Id,
                    Username = item.Username,
                    Email = item.Email,
                    PasswordHash = item.PasswordHash,
                };
                users.Add(user);
            }
            return users;
        }
    }
}
