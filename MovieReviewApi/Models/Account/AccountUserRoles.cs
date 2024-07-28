using System.ComponentModel.DataAnnotations;

namespace MovieReviewApi.Models.Account
{
    public class AccountUserRoles
    {
        [Key]
        public AccountUser User { get; set; }
        [Key]
        public AccountRole Role { get; set; }
    }
}
