using System;

class LoanAccount : Account
{
    public LoanAccount(Customer customer, double interestRate) : base(customer, interestRate)
    {
    }

    public LoanAccount(Customer customer, double startBalance, double interestRate) : base(customer, startBalance, interestRate)
    {
    }

    public override double CalculateInterest(int months)
    {
        if (months <= 3 && this.AccountCustomer is Individual)
        {
            return 0;
        }
        else if (months > 3 && this.AccountCustomer is Individual)
        {
            return this.Balance * (1 + this.InterestRate * (months - 3));
        }
        else if (months <= 2) // In case the customer is an individual 
        {
            return 0;
        }
        else
        {
            return this.Balance * (1 + this.InterestRate * (months - 2));
        }
    }
}
