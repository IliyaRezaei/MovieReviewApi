using System.ComponentModel.DataAnnotations;

namespace MovieReviewApi.Models.Account
{
    public class AccountUserRoles
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public AccountUser User { get; set; }
        public AccountRole Role { get; set; }
    }
}
