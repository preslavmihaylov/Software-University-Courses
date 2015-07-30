using System.Data.Entity;

class ATMContext : DbContext
{
    public ATMContext()
        : base("ATM")
    {
    }

    public DbSet<CardAccount> CardAccounts
    {
        get;
        set;
    }

    public DbSet<TransactionHistory> TransactionHistories
    {
        get;
        set;
    }
}