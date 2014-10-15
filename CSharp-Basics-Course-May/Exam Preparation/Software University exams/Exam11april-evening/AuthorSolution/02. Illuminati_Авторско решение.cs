using System;

class Illuminati
{
	static void Main()
	{
		string input = Console.ReadLine();            
		input = input.ToUpper();

		int numberOfVowels = 0;
		int sumOfLetters = 0;

		foreach (char letter in input)
		{
			if (letter == 'A' || letter == 'U' || 
				letter == 'O' || letter == 'E' || letter == 'I')
			{
				sumOfLetters += letter;
				numberOfVowels++;
			}
		}
		Console.WriteLine(numberOfVowels);
		Console.WriteLine(sumOfLetters);
	}
}
