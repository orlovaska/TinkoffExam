using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;

namespace UnitTestProject
{
    [TestClass]
    public class Task2Tests
    {
        [TestMethod]
        public void TestRotateMatrix_3x3()
        {
            int[,] matrix = new int[,]
            {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
            };
            int[,] expected = new int[,]
            {
            { 7, 4, 1 },
            { 8, 5, 2 },
            { 9, 6, 3 }
            };

            int[,] result = Program.RotateMatrix(matrix, 3, 3);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod, Timeout(7000)]
        public void TestRotateMatrix_1x1()
        {
            int[,] matrix = new int[,]
            {
            { 1 }
            };
            int[,] expected = new int[,]
            {
            { 1 }
            };

            int[,] result = Program.RotateMatrix(matrix, 1, 1);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod, Timeout(7000)]
        public void TestRotateMatrix_10x1()
        {
            int[,] matrix = new int[,]
            {
        { 1 },
        { 2 },
        { 3 },
        { 4 },
        { 5 },
        { 6 },
        { 7 },
        { 8 },
        { 9 },
        { 10 }
            };
            int[,] expected = new int[,]
            {
        { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 }
            };

            int[,] result = Program.RotateMatrix(matrix, 10, 1);

            CollectionAssert.AreEqual(expected, result);
        }


        [TestMethod, Timeout(7000)]
        public void TestRotateMatrix_1x10()
        {
            int[,] matrix = new int[,]
            {
        { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
            };
            int[,] expected = new int[,]
            {
        { 1 },
        { 2 },
        { 3 },
        { 4 },
        { 5 },
        { 6 },
        { 7 },
        { 8 },
        { 9 },
        { 10 }
            };

            int[,] result = Program.RotateMatrix(matrix, 1, 10);

            CollectionAssert.AreEqual(expected, result);
        }


        [TestMethod, Timeout(7000)]
        public void TestRotateMatrix_2x2()
        {
            int[,] matrix = new int[,]
            {
            { 1, 2 },
            { 3, 4 }
            };
            int[,] expected = new int[,]
            {
            { 3, 1 },
            { 4, 2 }
            };

            int[,] result = Program.RotateMatrix(matrix, 2, 2);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod, Timeout(7000)]
        public void TestRotateMatrix_50x60()
        {
            int[,] matrix = new int[50, 60];
            int[,] expected = new int[60, 50];
            int num = 1;
            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    matrix[i, j] = num;
                    expected[j, 50 - i - 1] = num;
                    num++;
                }
            }

            int[,] result = Program.RotateMatrix(matrix, 50, 60);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod, Timeout(7000)]
        public void TestRotateMatrix_1000x1000()
        {
            // Создаем матрицу 1000x1000
            int[,] matrix = new int[1000, 1000];
            int num = 1;
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    matrix[i, j] = num++;
                }
            }

            // Подготавливаем ожидаемую матрицу после поворота
            int[,] expected = new int[1000, 1000];
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    expected[j, 999 - i] = matrix[i, j];
                }
            }

            int[,] result = Program.RotateMatrix(matrix, 1000, 1000);

            // Проверяем корректность результата и время выполнения
            CollectionAssert.AreEqual(expected, result);
        }

    }
}
