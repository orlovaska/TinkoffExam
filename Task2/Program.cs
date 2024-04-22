using System;

namespace Task2
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] dimensions = Console.ReadLine().Split(' ');
            int n = int.Parse(dimensions[0]);
            int m = int.Parse(dimensions[1]);

            int[,] matrix = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                string[] row = Console.ReadLine().Split(' ');
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = int.Parse(row[j]);
                }
            }

            int[,] rotatedMatrix = RotateMatrix(matrix, n, m);
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(rotatedMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static int[,] RotateMatrix(int[,] matrix, int n, int m)
        {
            int[,] rotated = new int[m, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    rotated[j, n - i - 1] = matrix[i, j];
                }
            }
            return rotated;
        }

    }
}
