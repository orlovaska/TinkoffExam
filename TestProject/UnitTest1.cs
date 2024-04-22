using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace TestProject
{
    [TestClass]
    public class MainMethodTests
    {
        private StringWriter output;
        private StringReader input;

        [TestInitialize]
        public void Initialize()
        {
            // Подготовка потока вывода для перехвата
            output = new StringWriter();
            Console.SetOut(output);

            // Подготовка потока ввода
            input = new StringReader("7\n4 4 4 5 5 5 5\n");
            Console.SetIn(input);
        }

        [TestMethod]
        public void TestMainWithValidInput()
        {
            // Вызов метода Main
            TinkoffExam.Program.Main(new string[] { });

            // Проверка вывода
            string expectedOutput = "4\r\n";  // ожидаемый вывод может варьироваться в зависимости от вашей системы
            Assert.AreEqual(expectedOutput, output.ToString());
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Очистка и восстановление стандартного ввода и вывода
            output.Dispose();
            input.Dispose();
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        }
    }
}
