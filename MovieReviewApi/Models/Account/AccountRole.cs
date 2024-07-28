using System.ComponentModel.DataAnnotations.Schema;

namespace MovieReviewApi.Models.Account
{
    public class AccountRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<AccountUser>? User { get; set; }
    }
}
