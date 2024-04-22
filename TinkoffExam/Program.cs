using System;
using System.Linq;

namespace Task1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int COUNT_OF_DAYS = 7;
            int n = int.Parse(Console.ReadLine());
            int[] grades = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(FindMaxFivesInValidSegment(grades, COUNT_OF_DAYS));
        }
        public static int FindMaxFivesInValidSegment(int[] grades, int countOfDays)
        {
            if (grades.Length < countOfDays)
            {
                return -1;
            }

            int maxFives = 0;
            int countFives = 0;
            bool isValidSegment = true; // валидность текущего окна
            bool foundValidSegment = false; // был ли найден хотя бы один валидный отрезок

            // первый отрезок. Инициализация окна
            for (int i = 0; i < countOfDays; ++i)
            {
                if (grades[i] == 2 || grades[i] == 3)
                {
                    isValidSegment = false;
                    break;
                }
                if (grades[i] == 5) countFives++;
            }

            if (isValidSegment)
            {
                maxFives = countFives;
                foundValidSegment = true; // нашли хотя бы один валидный отрезок (первый)
            }

            // скользящее окно
            for (int i = countOfDays; i < grades.Length; ++i)
            {
                // добавим новый элемент в отрезок и убираем последний
                if (grades[i - countOfDays] == 5) countFives--;
                if (grades[i] == 5) countFives++;

                // валидность нового окна
                isValidSegment = true;
                for (int j = i - countOfDays + 1; j <= i; ++j)
                {
                    if (grades[j] == 2 || grades[j] == 3)
                    {
                        isValidSegment = false;
                        break;
                    }
                }

                // если новое окна валидно и в нем больше пятёрок, обновляем maxFives
                if (isValidSegment)
                {
                    foundValidSegment = true; // нашли хотя бы один валидный отрезок
                    if (countFives > maxFives)
                    {
                        maxFives = countFives;
                    }
                }
            }

            // если не найден ни один валидный отрезок, возвращаем -1
            return foundValidSegment ? maxFives : -1;
        }
    }
}
