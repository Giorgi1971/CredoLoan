namespace CredoLoan.Data.Entity
{
    public enum Currency
    {
        GEL,
        USD,
        EUR
    }

    public enum LoanType
    {
        FAST,
        AUTO,
        INSTALLMENT
    }

    public enum LoanStatus
    {
        Sended,
        Processing,
        Approved,
        Rejected
    }
}
