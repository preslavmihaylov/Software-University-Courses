using System;
class Illuminati
{
    static void Main()
    {
        string input = Console.ReadLine();
        long result = 0;
        int countOfVowels = 0;
        for (int letter = 0; letter < input.Length; letter++)
        {
            if (Convert.ToString(input[letter]) == "A" || Convert.ToString(input[letter]) == "a")
            {
                result += 65;
                countOfVowels++;
            }
            else if (Convert.ToString(input[letter]) == "E" || Convert.ToString(input[letter]) == "e")
            {
                result += 69;
                countOfVowels++;
            }
            else if (Convert.ToString(input[letter]) == "I" || Convert.ToString(input[letter]) == "i")
            {
                result += 73;
                countOfVowels++;
            }
            else if (Convert.ToString(input[letter]) == "O" || Convert.ToString(input[letter]) == "o")
            {
                result += 79;
                countOfVowels++;
            }
            else if (Convert.ToString(input[letter]) == "U" || Convert.ToString(input[letter]) == "u")
            {
                result += 85;
                countOfVowels++;
            }
        }

        Console.WriteLine(countOfVowels);
        Console.WriteLine(result);
    }
}
