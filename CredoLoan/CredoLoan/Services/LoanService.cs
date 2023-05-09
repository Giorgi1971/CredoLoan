using CredoLoan.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using CredoLoan.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace CredoLoan.Services
{
    public interface ILoanService
    {
        Task<LoanResponse> CreateLoanAsync(int loanType, decimal loanAmount, int currency, int loanMonth);
    }
    public class LoanService : ILoanService
    {
        private readonly UserManager<CustomerEntity> _userManager;

        public LoanService(UserManager<CustomerEntity> userManager)
        {
            _userManager = userManager;
        }
        public async Task<LoanResponse> CreateLoanAsync(int loanType, decimal loanAmount, int currency, int loanMonth)
        {
            ValidateLoanRequest(loanType, loanAmount, currency, loanMonth);
            var loan = new LoanEntity()
            {
                LoanType = (LoanType)loanType,
                LoanAmount = loanAmount,
                Currency = (Currency)currency,
                LoanMonth = loanMonth,
                LoanStatus = LoanStatus.Sended,
                AproveDate = DateTime.Now,
                // avtorizebuli momxmareblis id gvinda.......................................
                CustomerEntityId = 2
            };
            var result = await Task.FromResult(new LoanResponse()
            {
                LoanType = (LoanType)loanType,
                LoanAmount = loanAmount,
                Currency = (Currency)currency,
                LoanMonth = loanMonth,
                LoanStatus = LoanStatus.Sended,
                ResponseDate = DateTime.Now
            });
            return result;
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
