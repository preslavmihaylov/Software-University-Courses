using System;

public abstract class Account : IAccount
{
    private Customer accountCustomer;
    private double balance;
    private DateTime openingDate;
    private double interestRate;

    public double InterestRate
    {
        get
        {
            return this.interestRate;
        }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }
            this.interestRate = value;
        }
    }


    public DateTime OpeningDate
    {
        get
        {
            return this.openingDate;
        }
        private set
        {
            this.openingDate = value;
        }
    }

    public Customer AccountCustomer
    {
        get
        {
            return this.accountCustomer;
        }
        set
        {
            this.accountCustomer = value;
        }
    }

    public double Balance
    {
        get
        {
            return this.balance;
        }
        protected set
        {
            this.balance = value;
        }
    }

    public Account(Customer customer, double interestRate)
    {
        this.AccountCustomer = customer;
        this.Balance = 0;
        this.InterestRate = interestRate;
        this.OpeningDate = DateTime.Now;
    }

    public Account(Customer customer, double startBalance, double interestRate) : this(customer, interestRate)
    {
        this.Balance = startBalance;
    }

    public void Deposit(double value)
    {
        this.Balance += value;
    }

    public abstract double CalculateInterest(int months);
}
