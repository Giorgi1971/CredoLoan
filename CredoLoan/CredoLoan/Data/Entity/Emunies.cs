namespace CredoLoan.Data.Entity
{
    public class Currency
    {
        public int CurrencyId { get; set; }
        public string? UnitName { get; set; }
    }

    public class LoanType
    {
        public int LoanTypeId { get; set; }
        public string? Type { get; set; }
    }

    public class LoanStatus
    {
        public int LoanStatusId { get; set; }
        public string? Status { get; set; }
    }
    public class LoanPeriod
    {
        public int LoanPeriodId { get; set; }
        public string? Period { get; set; }
        public int Month { get; set; }
    }
}
