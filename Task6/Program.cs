using System;
using System.Collections.Generic;
using System.Linq;

namespace Task6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] board = new char[n, n];
            int initialX = 0;
            int initialY = 0;
            int targetX = 0;
            int targetY = 0;

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    if (line[j] == 'S')
                    {
                        initialX = i; initialY = j;
                    }
                    if (line[j] == 'F')
                    {
                        targetX = i; targetY = j;
                    }
                    board[i, j] = line[j];
                }
            }
            Console.WriteLine(FindDistance(initialX, initialY, targetX, targetY, board, n));
        }

        public static int FindDistance(int initialX, int initialY, int targetX, int targetY, char[,] board, int n)
        {
            if (n < 3)
            {
                return -1;
            }
            bool isKnight = true;
            int layerNumber = 0;
            var previousLayer = new HashSet<(int, int)>();
            var currentLayer = new HashSet<(int, int)>() { (initialX, initialY) };

            while (!currentLayer.Contains((targetX, targetY)))
            {
                var nextLayer = new HashSet<(int, int)>();

                foreach (var (x, y) in currentLayer)
                {
                    IEnumerable<(int, int)> nextCells = KnightMoves(x, y);
                    if (board[x, y] == 'K' || isKnight == false)
                    {
                        isKnight = false;
                        //nextCells = KingMoves(x, y);
                        nextCells = FilterMoves(KingMoves(x, y), n);
                    }
                    if (board[x, y] == 'G' || isKnight == true)
                    {
                        isKnight = true;
                        nextCells = FilterMoves(KnightMoves(x, y), n);
                    }
                    foreach (var nextCell in nextCells)
                    {
                        if (!previousLayer.Contains(nextCell))
                        {
                            nextLayer.Add(nextCell);
                        }
                    }
                }

                previousLayer = new HashSet<(int, int)>(currentLayer);
                currentLayer = new HashSet<(int, int)>(nextLayer);
                layerNumber++;
            }

            return layerNumber;
        }

        public static IEnumerable<(int, int)> KingMoves(int x, int y)
        {
            return new List<(int, int)>
            {
                (x - 1, y - 1), (x - 1, y), (x - 1, y + 1),
                (x, y - 1),                 (x, y + 1),
                (x + 1, y - 1), (x + 1, y), (x + 1, y + 1)
            };
        }

        public static IEnumerable<(int, int)> KnightMoves(int x, int y)
        {
            return new List<(int, int)>
            {
                (x - 2, y + 1), (x - 2, y - 1),
                (x - 1, y + 2), (x - 1, y - 2),
                (x + 1, y + 2), (x + 1, y - 2),
                (x + 2, y + 1), (x + 2, y - 1)
            };
        }

        public static IEnumerable<(int, int)> FilterMoves(IEnumerable<(int, int)> moves, int n)
        {
            return moves.Where(move => move.Item1 >= 0 && move.Item1 < n && move.Item2 >= 0 && move.Item2 < n);
        }


    }
}
