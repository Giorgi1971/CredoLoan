using CredoLoan.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using CredoLoan.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Net.WebSockets;
using CredoLoan.Repositories;
using Azure.Core;
using System.Reflection.Metadata.Ecma335;

namespace CredoLoan.Services
{
    public interface ILoanService
    {
        Task<LoanEntity> CreateLoanAsync(int loanType, decimal loanAmount, int currency, int loanMonth);

        Task<List<LoanEntity>> GetLoansAsync();
        Task<List<LoanStatus>> GetLoanStatusesAsync();
        Task<List<Currency>> GetLoanCurrencyesAsync();
        Task<List<LoanType>> GetLoantypesesAsync();
        Task<List<LoanPeriod>> GetLoanPeriodAsync();
        
    }
    public class LoanService : ILoanService
    {
        private readonly UserManager<CustomerEntity> _userManager;
        private readonly ILoanRepository _loanDb;

        public LoanService(UserManager<CustomerEntity> userManager, ILoanRepository loanDb)
        {
            _userManager = userManager;
            _loanDb = loanDb;
        }

        public async Task<List<LoanEntity>> GetLoansAsync()
        {
            return await _loanDb.GetLoansAsync();
        }
        public async Task<List<LoanPeriod>> GetLoanPeriodAsync()
        {
            return await _loanDb.GetLoanPeriodAsync();
        }
        
        public async Task<List<LoanStatus>> GetLoanStatusesAsync()
        {
            return await _loanDb.GetLoanStatusesAsync();
        }
        public async Task<List<Currency>> GetLoanCurrencyesAsync()
        {
            return await _loanDb.GetLoanCurrencyesAsync();
        }
        public async Task<List<LoanType>> GetLoantypesesAsync()
        {
            return await _loanDb.GetLoantypesesAsync();
        }

        public async Task<LoanEntity> CreateLoanAsync(int loanTypeId, decimal loanAmount, int currencyId, int countMonthId)
        {
            //var loanTypeId = int.Parse(loanType);
            //var currencyId = int.Parse(currency);
            //var countMonthId = int.Parse(loanMonth);
            //var validatedAmount = decimal.Parse(loanAmount);
            ValidateLoanRequest(loanTypeId, loanAmount, currencyId, countMonthId);
            var loan = new LoanEntity()
            {
                LoanTypeId = loanTypeId,
                LoanAmount = loanAmount,
                CurrencyId = currencyId,
                LoanPeriodId = countMonthId,
                LoanStatusId = 1,
                // avtorizebuli momxmareblis id gvinda.......................................
                CustomerEntityId = 2
            };

            var res = _loanDb.AddLoanToDbAsync(loan);
            await _loanDb.SaveChangesAsync();
            //var result = await Task.FromResult(new LoanResponse()
            //{
            //    LoanType = (LoanType)loanType,
            //    LoanAmount = loanAmount,
            //    Currency = (Currency)currency,
            //    LoanMonth = loanMonth,
            //    LoanStatus = LoanStatus.Sended,
            //    ResponseDate = DateTime.Now
            //});

            return loan;
        }

        public void ValidateLoanRequest(int loanType, decimal loanAmount, int currency, int loanMonth)
        {
            ValidateLoanType(loanType);
            ValidateLoanType(currency);
            ValidateLoanAmount(loanAmount);
        }

        private void ValidateLoanAmount(decimal loanAmount)
        {
            if (loanAmount <= 0)
                throw new ArgumentException("Invalid WithdrawAmount value. Must be greater than zero.");
        }

        private void ValidateLoanType(int loanType)
        {
            if (loanType < 0 || loanType > 2)
                throw new ArgumentOutOfRangeException();
        }
    }
}
