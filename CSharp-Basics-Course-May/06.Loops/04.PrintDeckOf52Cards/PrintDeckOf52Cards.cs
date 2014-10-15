using System;

class PrintDeckOf52Cards
{
    static void Main()
    {
        for (int card = 2; card <= 14; card++)
        {
            for (int suit = 5; suit >= 2; suit--)
            {
                string output = "";

                switch (card)
                {
                    case 11:
                        output += "J";
                        break;
                    case 12:
                        output += "Q";
                        break;
                    case 13:
                        output += "K";
                        break;
                    case 14:
                        output += "A";
                        break;
                    default:
                        output += card;
                        break;
                }

                // because of the wrong order in the ascii table...
                if (suit != 2)
                {
                    Console.Write(output + (char)suit + " ");
                }
                else
                {
                    Console.Write(output + (char)6 + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
