using System;
class ClassMatrix
{
    static Random randGenerator = new Random();
    static void Main()
    {
        Matrix matrix = new Matrix(4, 4);

        for (int row = 0; row < matrix.getLength(0); row++)
        {
            for (int col = 0; col < matrix.getLength(1); col++)
            {
                matrix.set(row, col, randGenerator.Next(10));
            }
        }

        Matrix secondMatrix = new Matrix(4, 4);

        for (int row = 0; row < secondMatrix.getLength(0); row++)
        {
            for (int col = 0; col < secondMatrix.getLength(1); col++)
            {
                secondMatrix.set(row, col, randGenerator.Next(10));
            }
        }

        Console.WriteLine("First: ");
        Console.WriteLine(matrix.toString());
        Console.WriteLine(new string('-', 20));
        Console.WriteLine("Second:");
        Console.WriteLine(secondMatrix.toString());
        Console.WriteLine(new string('-', 20));

        matrix.add(secondMatrix);
        Console.WriteLine("Added: ");
        Console.WriteLine(matrix.toString());
        Console.WriteLine(new string('-', 20));
        
        matrix.subtract(secondMatrix);
        Console.WriteLine("Subtracted: ");
        Console.WriteLine(matrix.toString());
        Console.WriteLine(new string('-', 20));

        matrix.multiply(secondMatrix);
        Console.WriteLine("Multiplied: ");
        Console.WriteLine(matrix.toString());
        Console.WriteLine(new string('-', 20));
    }
}
