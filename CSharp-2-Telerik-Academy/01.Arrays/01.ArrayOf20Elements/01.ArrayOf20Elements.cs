using System;
    class ArrayOf20Elements
    {
        static void Main()
        {
            int[] array = new int[20];

            for (int i = 0; i < 20; i++)
            {
                array[i] = i * 5;
                Console.Write(array[i] + " ");
            }
        }
    }
