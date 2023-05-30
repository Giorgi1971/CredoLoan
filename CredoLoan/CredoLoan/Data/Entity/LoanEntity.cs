using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CredoLoan.Data.Entity
{
    public class LoanEntity
    {
        public int LoanEntityId { get; set; }

        [Column(TypeName = "decimal(18,5)")]
        public decimal LoanAmount { get; set; }

        public int LoanPeriodId { get; set; }
        public LoanPeriod LoanPeriod { get; set; }

        public int LoanStatusId { get; set; }
        public LoanStatus LoanStatus { get; set; }
     
        public DateTime? AproveDate { get; set; }
        
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }

        public int LoanTypeId { get; set; }
        public LoanType LoanType { get; set; }

        public int CustomerEntityId { get; set; }
        public CustomerEntity CustomerEntity { get; set; }
    }
}
