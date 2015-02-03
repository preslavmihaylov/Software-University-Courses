using System;

class DepositAccount : Account
{
    public DepositAccount(Customer customer, double interestRate) : base(customer, interestRate)
    {
    }

    public DepositAccount(Customer customer, double startBalance, double interestRate) : base(customer, startBalance, interestRate)
    {
    }

    public void Withdraw(double amount)
    {
        if (this.Balance - amount < 0)
        {
            throw new ArgumentException("The Balance cannot be negative.");
        }

        this.Balance -= amount;
    }

    public override double CalculateInterest(int months)
    {
        if (this.Balance < 1000)
        {
            return 0;
        }
        else
        {
            return this.Balance * (1 + this.InterestRate * months); 
        }
    }
}