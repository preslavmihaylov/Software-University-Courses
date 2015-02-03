using System;
    class BankAccountData
    {
        // The task is similar to the previous one, but I am too lazy to do all those methods again. 
        // So I will just declare the variables myself. :)
        static void Main()
        {
            string firstName = "Atanas";
            string middleName = "Atanasov";
            string lastName = "Atanasov";
            decimal money = 12340000.23m; // I am a millionare :P
            string bankName = "Unicredit Bulbank";
            string IBAN = "BG32 UBBS 7827 1013 6179 05";
            long[] creditCards = new long[3];
            long cardNumber = 375325068652286;
            for (int index = 0; index < creditCards.Length; index++)
            {
                creditCards[index] = cardNumber;
                cardNumber++;
            }

            Console.WriteLine(new string('-', 40));
            Console.WriteLine("First Name: {0}", firstName);
            Console.WriteLine("Middle name: {0}", middleName);
            Console.WriteLine("Last Name: {0}", lastName);
            Console.WriteLine("Balance: {0}", money);
            Console.WriteLine("Bank Name: {0}", bankName);
            Console.WriteLine("IBAN: {0}", IBAN);

            for (int index = 0; index < creditCards.Length; index++)
            {
                Console.WriteLine("Credit Card Number {0}: {1}", index + 1, creditCards[index]);
            }

            Console.WriteLine(new string('-', 40));
        }
    }
