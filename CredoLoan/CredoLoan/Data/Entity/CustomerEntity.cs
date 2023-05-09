using Microsoft.AspNetCore.Identity;

namespace CredoLoan.Data.Entity
{
    public class CustomerEntity : IdentityUser<int>
    {
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string PersonalNumber { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public DateTime RegisteredAt { get; set; }

        public List<LoanEntity>? LoanEntities { get; set; }
    }
}
