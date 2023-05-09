using CredoLoan.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CredoLoan.Data
{
    public class LoanDbContext : IdentityDbContext<CustomerEntity, RoleEntity, int>
    {
        public LoanDbContext(DbContextOptions<LoanDbContext> options) : base(options) { }

        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<LoanEntity> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RoleEntity>().HasData(
                new RoleEntity { Id = 1, Name = "api-manager", NormalizedName = "API-MANAGER" },
                new RoleEntity { Id = 2, Name = "api-user", NormalizedName = "API-USER" },
                new RoleEntity { Id = 3, Name = "api-operator", NormalizedName = "API-OPERATOR" },
                new RoleEntity { Id = 4, Name = "api-admin", NormalizedName = "API-ADMIN" }
             );

            var password = "pas123";

            var hasherUser = new PasswordHasher<CustomerEntity>();

            var cust1 = new CustomerEntity
            {
                Id = 1,
                FirstName = "Gio",
                LastName = "Mas",
                NormalizedEmail = "GIO5@GMAIL.COM",
                BirthDate = DateTime.Parse("1971-11-26"),
                Email = "gio5@gmail.com",
                PersonalNumber = "01030019697",
                RegisteredAt = DateTime.Now.AddMonths(-15)
            };
            cust1.PasswordHash = hasherUser.HashPassword(cust1, password);

            var cust2 = new CustomerEntity
            {
                Id = 2,
                FirstName = "Nino",
                LastName = "Chale",
                NormalizedEmail = "NINO@GMAIL.COM",
                BirthDate = DateTime.Parse("1978-03-31"),
                Email = "nino@gmail.com",
                PersonalNumber = "01015003600",
                RegisteredAt = DateTime.Now.AddMonths(-11)

            };
            cust2.PasswordHash = password;

            var cust3 = new CustomerEntity
            {
                Id = 3,
                FirstName = "Niko",
                LastName = "Mas",
                NormalizedEmail = "NIKO@GMAIL.COM",
                BirthDate = DateTime.Parse("2017-12-09"),
                Email = "niko@gmail.com",
                PersonalNumber = "01015008765",
                RegisteredAt = DateTime.Now.AddMonths(-1)
            };
            cust3.PasswordHash = password;

            modelBuilder.Entity<CustomerEntity>().HasData(cust1, cust2, cust3);

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new[] {
                new IdentityUserRole<int> { UserId = 1, RoleId = 3 },
                new IdentityUserRole<int> { UserId = 2, RoleId = 2 },
                new IdentityUserRole<int> { UserId = 3, RoleId = 2 },
            });
        }
    }
}
