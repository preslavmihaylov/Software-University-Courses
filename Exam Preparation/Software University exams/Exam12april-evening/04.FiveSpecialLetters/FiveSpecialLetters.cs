using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class FiveSpecialLetters
{
    static void Main()
    {
        int start = int.Parse(Console.ReadLine());
        int end = int.Parse(Console.ReadLine());
        List<string> outputLetters = new List<string>();
        bool resultFound = false;

        for (char letter1 = (char)97; letter1 <= (char)101; letter1++)
        {
            for (char letter2 = (char)97; letter2 <= (char)101; letter2++)
            {
                for (char letter3 = (char)97; letter3 <= (char)101; letter3++)
                {
                    for (char letter4 = (char)97; letter4 <= (char)101; letter4++)
                    {
                        for (char letter5 = (char)97; letter5 <= (char)101; letter5++)
                        {
                            List<char> realLetters = new List<char>();
                            realLetters.Add(letter1);
                            if (letter2 != letter1)
                            {
                                realLetters.Add(letter2);
                            }
                            if (letter3 != letter1 && letter3 != letter2)
                            {
                                realLetters.Add(letter3);
                            }
                            if (letter4 != letter3 && letter4 != letter2 && letter4 != letter1)
                            {
                                realLetters.Add(letter4);
                            }
                            if (letter5 != letter4 && letter5 != letter3 && letter5 != letter2 && letter5 != letter1)
                            {
                                realLetters.Add(letter5);
                            }

                            int result = 0;
                            result = GetResult(realLetters);

                            if (result >= start && result <= end)
                            {
                                string output = "" + letter1 + letter2 + letter3 + letter4 + letter5;
                                Console.Write(output + " ");
                                resultFound = true;
                            }
                        }
                    }
                }
            }
        }

        if (resultFound == false)
        {
            Console.WriteLine("No");
        }
    }

    private static int GetResult(List<char> realLetters)
    {
        int result = 0;
        
        for (int index = 0; index < realLetters.Count; index++)
        {
            switch (realLetters[index])
            {
                case 'a':
                    result += (index + 1) * 5;
                    break;
                case 'b':
                    result += (index + 1) * -12;
                    break;
                case 'c':
                    result += (index + 1) * 47;
                    break;
                case 'd':
                    result += (index + 1) * 7;
                    break;
                case 'e':
                    result += (index + 1) * -32;
                    break;
            }
        }

        return result;
    }
}
