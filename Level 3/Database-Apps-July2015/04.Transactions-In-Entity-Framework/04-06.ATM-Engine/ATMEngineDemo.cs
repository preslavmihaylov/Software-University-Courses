using System;
using System.Linq;
using System.Transactions;

class ATMEngineDemo
{
    static void Main()
    {
        SeedDatabase();

        Console.Write("Enter Card Number: ");
        string cardNumber = Console.ReadLine();

        Console.Write("Enter Card PIN: ");
        string cardPIN = Console.ReadLine();

        var context = new ATMContext();

        var cardAccount = context.CardAccounts
            .Where(c => c.CardPIN == cardPIN && c.CardNumber == cardNumber)
            .FirstOrDefault();

        if (cardAccount != null)
        {
            Console.Write("How much would you like to withdraw? ");
            decimal amount = decimal.Parse(Console.ReadLine());

            TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = IsolationLevel.RepeatableRead
            });

            using (transactionScope)
            {
                if (cardAccount.CardCash >= amount)
                {
                    cardAccount.CardCash -= amount;
                    Console.WriteLine("Withdrawal successful.");
                }
                else
                {
                    throw new InvalidOperationException("Insufficient amount of money in the card.");
                }

                PreserveTransactionHistory(context, cardNumber, amount);
                context.SaveChanges();
                transactionScope.Complete();
            }
        }
        else
        {
            throw new InvalidOperationException("Invalid Card Number or PIN");
        }
    }

    static void PreserveTransactionHistory(ATMContext context, 
        string cardNumber, 
        decimal amount)
    {
        TransactionHistory transactionHistory = new TransactionHistory();
        transactionHistory.Amount = amount;
        transactionHistory.CardNumber = cardNumber;

        context.TransactionHistories.Add(transactionHistory);
    }

    static void SeedDatabase()
    {
        ATMContext context = new ATMContext();

        context.CardAccounts.Add(new CardAccount()
        {
            CardCash = 500,
            CardNumber = "2001",
            CardPIN = "1112"
        });

        context.CardAccounts.Add(new CardAccount()
        {
            CardCash = 800,
            CardNumber = "2002",
            CardPIN = "1113"
        });

        context.CardAccounts.Add(new CardAccount()
        {
            CardCash = 1000,
            CardNumber = "2003",
            CardPIN = "1114"
        });
        
        context.SaveChanges();
    }
}