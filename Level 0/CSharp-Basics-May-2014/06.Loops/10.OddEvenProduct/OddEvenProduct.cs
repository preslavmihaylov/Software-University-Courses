using System;

class OddEvenProduct
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();

        int oddProduct = 1;
        int evenProduct = 1;

        for (int index = 0; index < input.Length; index++)
        {
            int number = Convert.ToInt32(Convert.ToString(input[index]));

            if ((index + 1) % 2 == 0)
            {
                evenProduct *= number;
            }
            else
            {
                oddProduct *= number;
            }
        }

        if (oddProduct == evenProduct)
        {
            Console.WriteLine("yes");
            Console.WriteLine("product = {0}", oddProduct);
        }
        else
        {
            Console.WriteLine("no");
            Console.WriteLine("odd_product = {0}", oddProduct);
            Console.WriteLine("even_product = {0}", evenProduct);
        }
    }
}
