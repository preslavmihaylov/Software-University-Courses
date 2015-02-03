using System;
class Sunglasses
{
    // initial input, make it outside the main method in order for it to be visible for every method.
    // (The static void things are examples of methods. They are used to avoid repeating the same code several times)
    static int N = int.Parse(Console.ReadLine());

    // Since the width of the frame is N*2 and the frames are two, then the 
    // cols of the matrix are (N * 4) + N, (N is the width of the bridge)
    static char[,] sunglasses = new char[N, (N * 4) + N];
    static void Main()
    {
        // the start and end variables are used to print the different parts of the sunglasses
        int start = 0;
        int end = N * 2;
        // if the following loop is not done, the program will work fine in visual studio, but it won't in the judge system
        // This way, the default value of the elements in the matrix will be ' ' (empty space)
        for (int i = 0; i < N; i++)
        {
            for (int k = 0; k < (N * 4) + N; k++)
            {
                sunglasses[i, k] = ' ';
            }
        }

        // insert the first part using a method
        PrintFrames(start, end);

        // print the bridge, N / 2 is the row in order for the bridge to be exactly in the middle of the sunglasses
        for (int i = end; i < end + N; i++)
        {
            sunglasses[N / 2, i] = '|';
        }
        // change the values of the variables in order to make the exact same thing on the second part of the sunglasses
        start = end + N;
        end = start + N * 2;

        // insert the second part using a method
        PrintFrames(start, end);

        // print every elements of the matrix
        for (int i = 0; i < N; i++)
        {
            for (int k = 0; k < (N * 4) + N; k++)
            {
                Console.Write(sunglasses[i, k]);
            }
            Console.WriteLine();
        }
    }

    static void PrintFrames(int leftPart, int rightPart)
    {
        for (int row = 0; row < N; row++)
        {
            for (int col = leftPart; col < rightPart; col++)
            {
                // if the row is the top or bottom part of the frame
                if (row == 0 || row == N - 1)
                {
                    sunglasses[row, col] = '*';
                }
                // if the column is the left or right part of the frame
                else if (col == leftPart || col == rightPart - 1)
                {
                    sunglasses[row, col] = '*';
                }
                // if the elements are in any other part of the frame
                else
                {
                    sunglasses[row, col] = '/';
                }

            }
        }
    }
}
