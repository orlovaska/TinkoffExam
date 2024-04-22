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
            // ���������� ������ ������ ��� ���������
            output = new StringWriter();
            Console.SetOut(output);

            // ���������� ������ �����
            input = new StringReader("7\n4 4 4 5 5 5 5\n");
            Console.SetIn(input);
        }

        [TestMethod]
        public void TestMainWithValidInput()
        {
            // ����� ������ Main
            TinkoffExam.Program.Main(new string[] { });

            // �������� ������
            string expectedOutput = "4\r\n";  // ��������� ����� ����� ������������� � ����������� �� ����� �������
            Assert.AreEqual(expectedOutput, output.ToString());
        }

        [TestCleanup]
        public void Cleanup()
        {
            // ������� � �������������� ������������ ����� � ������
            output.Dispose();
            input.Dispose();
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        }
    }
}
