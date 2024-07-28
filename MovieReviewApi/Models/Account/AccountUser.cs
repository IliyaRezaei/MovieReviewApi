
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieReviewApi.Models.Account
{
    public class AccountUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<AccountRole> Role { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }
}
