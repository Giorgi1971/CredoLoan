using CredoLoan.Data.Entity;
using CredoLoan.Data;
using Microsoft.EntityFrameworkCore;

namespace CredoLoan.Repositories
{
    public interface ILoanRepository
    {
        Task<List<LoanEntity>> GetLoansAsync();
        Task<List<LoanPeriod>> GetLoanPeriodAsync();
        Task<List<LoanStatus>> GetLoanStatusesAsync();
        Task<List<Currency>> GetLoanCurrencyesAsync();
        Task<List<LoanType>> GetLoantypesesAsync();
        Task<LoanEntity> GetLoanByIdAsync(int id);
        Task AddLoanToDbAsync(LoanEntity loan);
        Task SaveChangesAsync();
    }

    public class LoanRepository : ILoanRepository
    {
        private readonly LoanDbContext _db;

        public LoanRepository(LoanDbContext db)
        {
            _db = db;
        }

        public async Task<List<LoanEntity>> GetLoansAsync()
        {
            return await _db.Loans.ToListAsync();
        }

        public async Task<List<LoanStatus>> GetLoanStatusesAsync()
        {
            return await _db.Statuses.ToListAsync();
        }
        
        public async Task<List<Currency>> GetLoanCurrencyesAsync()
        {
            return await _db.Currencies.ToListAsync();
        }
        public async Task<List<LoanPeriod>> GetLoanPeriodAsync()
        {
            return await _db.LoanPeriods.ToListAsync();
        }

        public async Task<List<LoanType>> GetLoantypesesAsync()
        {
            return await _db.LoanTypes.ToListAsync();
        }

        public async Task<LoanEntity> CreateLoanAsync(LoanEntity loan)
        {
            await _db.Loans.AddAsync(loan);
            //await _db.SaveChangesAsync();

            // Return the created loan object
            return loan;
        }
        public async Task<LoanEntity> GetLoanByIdAsync(int id)
        {
            var customer = await _db.Loans.SingleOrDefaultAsync(x => x.LoanEntityId == id);
            return customer ?? throw new Exception("Customer Not Found!");
        }

        public async Task AddLoanToDbAsync(LoanEntity loan)
        {
            await _db.Loans.AddAsync(loan);
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
