using System;

class Matrix
{
    private int[,] matrix;

    public Matrix(int rows, int cols)
    {
        matrix = new int[rows, cols];
    }

    public int get(int row, int col)
    {
        return matrix[row, col];
    }

    public void set(int row, int col, int value)
    {
        matrix[row, col] = value;
    }

    public int getLength(int num)
    {
        return matrix.GetLength(num);
    }

    public void add(Matrix addedMatrix)
    {
        if (addedMatrix.getLength(0) != matrix.GetLength(0) &&
            addedMatrix.getLength(1) != matrix.GetLength(1))
        {
            throw new IndexOutOfRangeException();
        }

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] += addedMatrix.get(row, col);
            }
        }
    }

    public void subtract(Matrix addedMatrix)
    {
        if (addedMatrix.getLength(0) != matrix.GetLength(0) &&
            addedMatrix.getLength(1) != matrix.GetLength(1))
        {
            throw new IndexOutOfRangeException();
        }

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] -= addedMatrix.get(row, col);
            }
        }
    }

    public void multiply(Matrix multipliedMatrix)
    {
        if (multipliedMatrix.getLength(0) != matrix.GetLength(1))
        {
            throw new IndexOutOfRangeException();
        }

        Matrix newMatrix = new Matrix(matrix.GetLength(0), multipliedMatrix.getLength(1));

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < multipliedMatrix.getLength(1); col++)
            {
                int result = 0;
                for (int multipliedRow = 0; multipliedRow < matrix.GetLength(1); multipliedRow++)
                {
                    result += matrix[row, multipliedRow] * multipliedMatrix.get(multipliedRow, col);
                }

                newMatrix.set(row, col, result);
            }
        }

        matrix = newMatrix.getMatrix();
    }

    public int[,] getMatrix()
    {
        return this.matrix;
    }

    public string toString()
    {

        string output = "";
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (col != matrix.GetLength(1) - 1)
                {
                    output += matrix[row, col] + ", ";
                }
                else
                {
                    output += matrix[row, col] + "\n";
                }
            }
        }

        return output;
    }
}
