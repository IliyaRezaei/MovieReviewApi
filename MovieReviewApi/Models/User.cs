﻿
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieReviewApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<Role> Role { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }
}
