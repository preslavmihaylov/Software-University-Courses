using System;
    class AgeAfter10Years
    {
        static void Main()
        {
            Console.WriteLine("Input your birthday (dd-mm-yyyy)");
            DateTime birthday = DateTime.Parse(Console.ReadLine());
            int Age = DateTime.Now.Year - birthday.Year;

            if (birthday.Month >= DateTime.Now.Month)
            {
                if (birthday.Day > DateTime.Now.Day)
                {
                    Age--;
                }
            }

            Console.WriteLine("Your age now is:");
            Console.WriteLine(Age);
            Console.WriteLine("Your age after 10 years will be:");
            Console.WriteLine(Age + 10);
            
        }
    }
