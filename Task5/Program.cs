using System;
using System.IO;

namespace Task5
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char[,] forest = new char[n, 3];
            for (int i = 0; i < n; i++)
            {
                string row = Console.ReadLine();
                for (int j = 0; j < 3; j++)
                {
                    forest[i, j] = row[j];
                }
            }


            int mushrooms = FindMaxMushrooms(forest, n);
            Console.WriteLine(mushrooms);
        }

        public static int FindMaxMushrooms(char[,] forest, int n)
        {
            int[,] mushroomsCount = new int[n, 3];
            int maxMushrooms = 0;

            // начальная строка. Если куст, то -1, иначе. Есди гриб, то 1, иначе 0
            mushroomsCount[0, 0] = isBushes(forest, 0, 0) ? -1 : (isMushroom(forest, 0, 0) ? 1 : 0);
            mushroomsCount[0, 1] = isBushes(forest, 0, 1) ? -1 : (isMushroom(forest, 0, 1) ? 1 : 0);
            mushroomsCount[0, 2] = isBushes(forest, 0, 2) ? -1 : (isMushroom(forest, 0, 2) ? 1 : 0);

            if (mushroomsCount[0, 0] == -1 && mushroomsCount[0, 1] == -1 && mushroomsCount[0, 2] == -1)
            {
                return 0;
            }


            // перебираем лес по уровням
            for (int level = 1; level < n; level++)
            {
                for (int column = 0; column < 3; column++)
                {
                    if (column == 0)
                    {
                        //если кусты, то берем нужный, иначе ставим -1
                        int topLeftCell = isBushes(forest, level - 1, 0) ? -1 : mushroomsCount[level - 1, 0];
                        int topMiddleCell = isBushes(forest, level - 1, 1) ? -1 : mushroomsCount[level - 1, 1];
                        // в случае, если оба кусты, будет -1
                        mushroomsCount[level, column] = Math.Max(topLeftCell, topMiddleCell);
                        if (isMushroom(forest, level, column) && mushroomsCount[level, column] != -1)
                        {
                            mushroomsCount[level, column]++;
                        }
                        if (mushroomsCount[level, column] > maxMushrooms)
                        {
                            maxMushrooms = mushroomsCount[level, column];
                        }
                    }
                    if (column == 1)
                    {
                        int topLeftCell = isBushes(forest, level - 1, 0) ? -1 : mushroomsCount[level - 1, 0];
                        int topMiddleCell = isBushes(forest, level - 1, 1) ? -1 : mushroomsCount[level - 1, 1];
                        int topRightCell = isBushes(forest, level - 1, 2) ? -1 : mushroomsCount[level - 1, 2];

                        mushroomsCount[level, column] = Math.Max(topLeftCell, Math.Max(topMiddleCell, topRightCell));
                        if (isMushroom(forest, level, column) && mushroomsCount[level, column] != -1)
                        {
                            mushroomsCount[level, column]++;
                        }
                        if (mushroomsCount[level, column] > maxMushrooms)
                        {
                            maxMushrooms = mushroomsCount[level, column];
                        }
                    }
                    if (column == 2)
                    {
                        int topMiddleCell = isBushes(forest, level - 1, 1) ? -1 : mushroomsCount[level - 1, 1];
                        int topRightCell = isBushes(forest, level - 1, 2) ? -1 : mushroomsCount[level - 1, 2];

                        mushroomsCount[level, column] = Math.Max(topMiddleCell, topRightCell);
                        if (isMushroom(forest, level, column) && mushroomsCount[level, column] != -1)
                        {
                            mushroomsCount[level, column]++;
                        }
                        if (mushroomsCount[level, column] > maxMushrooms)
                        {
                            maxMushrooms = mushroomsCount[level, column];
                        }
                    }
                }
            }
            return maxMushrooms;
        }

        public static bool isBushes(char[,] forest, int x, int y)
        {
            return forest[x, y] == 'W';
        }

        public static bool isMushroom(char[,] forest, int x, int y)
        {
            return forest[x, y] == 'C';
        }
    }
}
