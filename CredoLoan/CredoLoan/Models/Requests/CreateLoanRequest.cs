using CredoLoan.Data.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CredoLoan.Models.Requests
{
    public class CreateLoanRequest
    {
        public int LoanTypeId { get; set; }

        [Column(TypeName = "decimal(18,5)")]
        public decimal LoanAmount { get; set; }

        public int CurrencyId { get; set; }
        public int LoanPeriodId { get; set; }
    }
}
