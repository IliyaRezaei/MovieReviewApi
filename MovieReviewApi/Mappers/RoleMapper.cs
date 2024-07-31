using MovieReviewApi.Dto;
using MovieReviewApi.Models;

namespace MovieReviewApi.Mappers
{
    public static class RoleMapper
    {
        public static RoleDto ToDto(this Role role)
        {
            RoleDto roleDto = new RoleDto
            {
                Id = role.Id,
                Name = role.Name,
            };
            return roleDto;
        }
        public static List<RoleDto> ToDto(this List<Role> role)
        {
            List<RoleDto> roleDtos = new List<RoleDto>();
            foreach (var item in role)
            {
                var roleDto = new RoleDto
                {
                    Id = item.Id,
                    Name = item.Name,
                };
                roleDtos.Add(roleDto);
            }
            return roleDtos;
        }

        public static Role ToModel(this RoleDto roleDto)
        {
            Role role = new Role
            {
                Id = roleDto.Id,
                Name = roleDto.Name,
            };
            return role;
        }

        public static List<Role> ToModel(this List<RoleDto> roleDto)
        {
            List<Role> roles = new List<Role>();
            foreach (var item in roleDto)
            {
                var role = new Role
                {
                    Id = item.Id,
                    Name = item.Name,
                };
                roles.Add(role);
            }
            return roles;
        }
    }
}
