using System;

class DrunkenNumbers
{
    static void Main()
    {
        long roundCount = long.Parse(Console.ReadLine());
        long mitkoScore = 0;
        long vladkoScore = 0;
        

        for (long index = 0; index < roundCount; index++)
        {
            string number = Console.ReadLine();
            string checkedNumber = "";
            int check = 0;
            for (int numCheck = 0; numCheck < number.Length; numCheck++)
            {
                if (number[numCheck] != '0' && number[numCheck] != '-')
                {
                    for (int newString = numCheck; newString < number.Length; newString++)
                    {
                        checkedNumber += number[newString];
                    }
                    break;
                }
            }

            number = checkedNumber;
            if (number.Length % 2 == 0)
            {
                for (int count = 0; count < number.Length; count++)
                {
                    if (count < number.Length / 2)
                    {
                        check = 0;
                        int.TryParse(Convert.ToString(number[count]), out check);
                        mitkoScore += check;
                    }
                    else
                    {
                        check = 0;
                        int.TryParse(Convert.ToString(number[count]), out check);
                        vladkoScore += check;
                    }
                }
            }
            else
            {
                for (int count = 0; count < number.Length; count++)
                {
                    if (count < number.Length / 2)
                    {
                        check = 0;
                        int.TryParse(Convert.ToString(number[count]), out check);
                        mitkoScore += check;
                    }
                    else if (count > number.Length / 2)
                    {
                        check = 0;
                        int.TryParse(Convert.ToString(number[count]), out check);
                        vladkoScore += check;
                    }
                    else
                    {
                        check = 0;
                        int.TryParse(Convert.ToString(number[count]), out check);
                        mitkoScore += check;
                        vladkoScore += check;
                    }
                }
            }
        }

        if (mitkoScore > vladkoScore)
        {
            Console.WriteLine("M {0}", mitkoScore - vladkoScore);
        }
        else if (mitkoScore < vladkoScore)
        {
            Console.WriteLine("V {0}", vladkoScore - mitkoScore);
        }
        else
        {
            Console.WriteLine("No {0}", mitkoScore + vladkoScore);
        }
    }
}
