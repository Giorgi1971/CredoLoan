using CredoLoan.Data;
using CredoLoan.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace CredoLoan.Repositories
{
    public interface ICustomerRepository
    {
        
        Task<List<CustomerEntity>> GetUsersAsync();
        Task<CustomerEntity> GetUserByIdAsync(int id);
        Task AddCustomerToDbAsync(CustomerEntity customer);
        Task SaveChangesAsync();
    }

    public class CustomerRepository : ICustomerRepository
    {
        private readonly LoanDbContext _db;

        public CustomerRepository(LoanDbContext db)
        {
            _db = db;
        }

        public async Task<List<CustomerEntity>> GetUsersAsync()
        {
            var customers = await _db.Customers.ToListAsync();
            return customers ?? throw new Exception("Customer Not Found!");
        }
        public async Task<CustomerEntity> GetUserByIdAsync(int id)
        {
            var customer = await _db.Customers.SingleOrDefaultAsync(x => x.Id == id);
            return customer ?? throw new Exception("Customer Not Found!");
        }

        public async Task AddCustomerToDbAsync(CustomerEntity customer)
        {
            await _db.Customers.AddAsync(customer);
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
