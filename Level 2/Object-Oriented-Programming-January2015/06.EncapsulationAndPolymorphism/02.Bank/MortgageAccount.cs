using System;

class MortgageAccount : Account
{
    public MortgageAccount(Customer customer, double interestRate) : base(customer, interestRate)
    {
    }

    public MortgageAccount(Customer customer, double startBalance, double interestRate) : base(customer, startBalance, interestRate)
    {
    }

    public override double CalculateInterest(int months)
    {
        if (months <= 12 && this.AccountCustomer is Company)
        {
            return this.Balance * (1 + this.InterestRate * months) / 2;
        }
        else if (months > 12 && this.AccountCustomer is Company)
        {
            double result = this.Balance * (1 + this.InterestRate * 12) / 2;
            result += this.Balance * (1 + this.InterestRate * (months - 12)) / 2;
            return result;
        }
        else if (months <= 6) // In case the customer is an individual 
        {
            return 0;
        }
        else
        {
            return this.Balance * (1 + this.InterestRate * (months - 6));
        }
    }
}
