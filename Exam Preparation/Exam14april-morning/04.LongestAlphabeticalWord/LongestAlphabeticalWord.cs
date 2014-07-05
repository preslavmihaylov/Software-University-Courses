using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LongestAlphabeticalWord
{
    static void Main()
    {
        string word = Console.ReadLine();
        int matrixSize = int.Parse(Console.ReadLine());

        int[,] matrix = new int[matrixSize, matrixSize];

        int count = 0;

        for (int row = 0; row < matrixSize; row++)
        {
            for (int col = 0; col < matrixSize; col++)
            {
                if (count == word.Length)
                {
                    count = 0;
                }
                matrix[row, col] = Convert.ToInt32(word[count]);
                count++;
            }
        }

        List<int> sets = new List<int>();
        List<int> nextSet = new List<int>();

        for (int row = 0; row < matrixSize; row++)
        {
            for (int col = 0; col < matrixSize; col++)
            {
                nextSet.Add(matrix[row, col]);
                for (int nextNumber = col + 1; nextNumber < matrixSize; nextNumber++)
                {
                    if (nextSet[nextSet.Count - 1] < matrix[row, nextNumber])
                    {
                        nextSet.Add(matrix[row, nextNumber]);
                    }
                    else
                    {
                        break;
                    }
                }

                if (sets.Count < nextSet.Count)
                {
                    sets.Clear();
                    foreach (var item in nextSet)
                    {
                        sets.Add(item);
                    }
                }
                else if (sets.Count == nextSet.Count)
                {
                    int winner = 0;
                    for (int currentChar = 0; currentChar < sets.Count; currentChar++)
                    {
                        if (sets[currentChar] < nextSet[currentChar])
                        {
                            winner = 1;
                            break;
                        }
                        else if (sets[currentChar] > nextSet[currentChar])
                        {
                            winner = 2;
                            break;
                        }
                    }

                    if (winner == 2)
                    {
                        sets.Clear();
                        foreach (var item in nextSet)
                        {
                            sets.Add(item);
                        }
                    }
                }
                nextSet.Clear();
            }
        }

        for (int col = 0; col < matrixSize; col++)
        {
            for (int row = 0; row < matrixSize; row++)
            {
                nextSet.Add(matrix[row, col]);
                for (int nextNumber = row + 1; nextNumber < matrixSize; nextNumber++)
                {
                    if (nextSet[nextSet.Count - 1] < matrix[nextNumber, col])
                    {
                        nextSet.Add(matrix[nextNumber, col]);
                    }
                    else
                    {
                        break;
                    }
                }

                if (sets.Count < nextSet.Count)
                {
                    sets.Clear();
                    foreach (var item in nextSet)
                    {
                        sets.Add(item);
                    }
                }
                else if (sets.Count == nextSet.Count)
                {
                    int winner = 0;
                    for (int currentChar = 0; currentChar < sets.Count; currentChar++)
                    {
                        if (sets[currentChar] < nextSet[currentChar])
                        {
                            winner = 1;
                            break;
                        }
                        else if (sets[currentChar] > nextSet[currentChar])
                        {
                            winner = 2;
                            break;
                        }
                    }

                    if (winner == 2)
                    {
                        sets.Clear();
                        foreach (var item in nextSet)
                        {
                            sets.Add(item);
                        }
                    }
                }
                nextSet.Clear();
            }
        }

        for (int row = 0; row < matrixSize; row++)
        {
            for (int col = matrixSize - 1; col >= 0; col--)
            {
                nextSet.Add(matrix[row, col]);
                for (int nextNumber = col - 1; nextNumber >= 0; nextNumber--)
                {
                    if (nextSet[nextSet.Count - 1] < matrix[row, nextNumber])
                    {
                        nextSet.Add(matrix[row, nextNumber]);
                    }
                    else
                    {
                        break;
                    }
                }

                if (sets.Count < nextSet.Count)
                {
                    sets.Clear();
                    foreach (var item in nextSet)
                    {
                        sets.Add(item);
                    }
                }
                else if (sets.Count == nextSet.Count)
                {
                    int winner = 0;
                    for (int currentChar = 0; currentChar < sets.Count; currentChar++)
                    {
                        if (sets[currentChar] < nextSet[currentChar])
                        {
                            winner = 1;
                            break;
                        }
                        else if (sets[currentChar] > nextSet[currentChar])
                        {
                            winner = 2;
                            break;
                        }
                    }

                    if (winner == 2)
                    {
                        sets.Clear();
                        foreach (var item in nextSet)
                        {
                            sets.Add(item);
                        }
                    }
                }
                nextSet.Clear();
            }
        }

        for (int col = 0; col < matrixSize; col++)
        {
            for (int row = matrixSize - 1; row >= 0; row--)
            {
                nextSet.Add(matrix[row, col]);
                for (int nextNumber = row - 1; nextNumber >= 0; nextNumber--)
                {
                    if (nextSet[nextSet.Count - 1] < matrix[nextNumber, col])
                    {
                        nextSet.Add(matrix[nextNumber, col]);
                    }
                    else
                    {
                        break;
                    }
                }

                if (sets.Count < nextSet.Count)
                {
                    sets.Clear();
                    foreach (var item in nextSet)
                    {
                        sets.Add(item);
                    }
                }
                else if (sets.Count == nextSet.Count)
                {
                    int winner = 0;
                    for (int currentChar = 0; currentChar < sets.Count; currentChar++)
                    {
                        if (sets[currentChar] < nextSet[currentChar])
                        {
                            winner = 1;
                            break;
                        }
                        else if (sets[currentChar] > nextSet[currentChar])
                        {
                            winner = 2;
                            break;
                        }
                    }

                    if (winner == 2)
                    {
                        sets.Clear();
                        foreach (var item in nextSet)
                        {
                            sets.Add(item);
                        }
                    }
                }
                nextSet.Clear();
            }
        }

        foreach (var item in sets)
        {
            Console.Write((char)item);
        }
        Console.WriteLine();
        
    }
}
