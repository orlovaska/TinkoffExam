using System;
using System.Collections.Generic;

namespace Task4
{
    public class Program
    {
        public static void Main()
        {
            string[] firstLine = Console.ReadLine().Split();
            int size = int.Parse(firstLine[0]);
            char direction = firstLine[1][0];

            int[,] matrix = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                string[] row = Console.ReadLine().Split();
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = int.Parse(row[j]);
                }
            }

            var operations = RotateMatrix(matrix, direction);
            Console.WriteLine(operations.Count);
            foreach (var op in operations)
            {
                Console.WriteLine(op);
            }
        }

        static List<string> RotateMatrix(int[,] matrix, char direction)
        {
            int n = matrix.GetLength(0);
            List<string> operations = new List<string>();

            for (int i = 0; i < n / 2; i++)
            {
                for (int j = i; j < n - i - 1; j++)
                {
                    int temp = matrix[i, j];
                    if (direction == 'R')
                    {
                        matrix[i, j] = matrix[n - j - 1, i];
                        matrix[n - j - 1, i] = matrix[n - i - 1, n - j - 1];
                        matrix[n - i - 1, n - j - 1] = matrix[j, n - i - 1];
                        matrix[j, n - i - 1] = temp;

                        operations.Add($"{n - j - 1} {i} {i} {j}");
                        operations.Add($"{n - i - 1} {n - j - 1} {n - j - 1} {i}");
                        operations.Add($"{j} {n - i - 1} {n - i - 1} {n - j - 1}");
                    }
                    else // 'L'
                    {
                        matrix[i, j] = matrix[j, n - i - 1];
                        matrix[j, n - i - 1] = matrix[n - i - 1, n - j - 1];
                        matrix[n - i - 1, n - j - 1] = matrix[n - j - 1, i];
                        matrix[n - j - 1, i] = temp;

                        operations.Add($"{j} {n - i - 1} {i} {j}");
                        operations.Add($"{n - i - 1} {n - j - 1} {j} {n - i - 1}");
                        operations.Add($"{n - j - 1} {i} {n - i - 1} {n - j - 1}");
                    }
                }
            }

            return operations;
        }
    }

}
