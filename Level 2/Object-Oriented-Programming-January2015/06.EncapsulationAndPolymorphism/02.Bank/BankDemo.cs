using System;

class BankDemo
{
    static void Main()
    {
        LoanAccount loanAcc = new LoanAccount(new Individual("Georgi", 28, "1122334455"), 1000, 7);
        Console.WriteLine(loanAcc.CalculateInterest(6));

        DepositAccount depositAcc = new DepositAccount(new Company("SoftUni Ltd.", 1, "1122334455"), 1000, 7);
        Console.WriteLine(depositAcc.CalculateInterest(6));

        MortgageAccount mortgageAcc = new MortgageAccount(new Individual("Pesho", 20, "1122334455"), 1000, 7);
        Console.WriteLine(mortgageAcc.CalculateInterest(6));
    }
}
