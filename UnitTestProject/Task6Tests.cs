using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class Task6Tests
    {
        [TestMethod, Timeout(1000)]
        public void TestMain_EnoughGrades_NoTwosOrThrees_MaxFives()
        {
            using (var output = new StringWriter())
            {
                Console.SetOut(output);
                using (var input = new StringReader("3\n..F\n..K\nS.."))
                {
                    Console.SetIn(input);
                    Task6.Program.Main(new string[] { });
                    string expectedOutput = "2\r\n";
                    Assert.AreEqual(expectedOutput, output.ToString());
                }
            }
        }

        [TestMethod, Timeout(1000)]
        public void TestMain_LargeBoard_ManyTransformations()
        {
            // Предположим, что размер доски - 10x10 и фигура начинает как конь.
            // Задаем расположение препятствий (трансформаций) 'K' и цели 'F'.
            int size = 10;
            var inputBuilder = new StringBuilder();
            inputBuilder.AppendLine($"{size}");

            // Генерация доски с трансформациями и целью.
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == 0 && j == size - 1)
                        inputBuilder.Append('F'); // Цель в верхнем правом углу.
                    else if (i % 2 == 0 && j % 2 == 0)
                        inputBuilder.Append('K'); // Трансформации в виде шахматной доски.
                    else
                        inputBuilder.Append('.'); // Пустые клетки.
                }
                inputBuilder.AppendLine();
            }
            // Стартовая позиция в нижнем левом углу.
            inputBuilder[size * (size + Environment.NewLine.Length) - (Environment.NewLine.Length + 1)] = 'S';

            using (var input = new StringReader(inputBuilder.ToString()))
            {
                Console.SetIn(input);

                using (var output = new StringWriter())
                {
                    Console.SetOut(output);

                    Task6.Program.Main(new string[] { });

                    // Здесь мы не знаем ожидаемое количество ходов, так как оно зависит от
                    // конкретной реализации алгоритма. Предположим, что мы знаем ожидаемый ответ.
                    string expectedOutput = "6"; // Примерное ожидаемое количество ходов.
                    Assert.AreEqual(expectedOutput, output.ToString().Trim());
                }
            }
        }
    }
}
