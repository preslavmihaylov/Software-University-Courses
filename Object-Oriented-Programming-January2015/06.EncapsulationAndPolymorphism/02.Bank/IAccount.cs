using System;
public interface IAccount
{
    Customer AccountCustomer { get; }
    double Balance { get; }
    DateTime OpeningDate { get; }
    void Deposit(double value);
    double CalculateInterest(int months);
}