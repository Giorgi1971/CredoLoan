using CredoLoan.Data.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredoLoan.Models.Responses
{
    public class LoanResponse
    {
        public LoanType LoanType { get; set; }
        [Column(TypeName = "decimal(18,5)")]
        public decimal LoanAmount { get; set; }
        public Currency Currency { get; set; }
        public int LoanMonth { get; set; }
        public LoanStatus LoanStatus { get; set; }
        public DateTime? ResponseDate { get; set; }
    }
}
