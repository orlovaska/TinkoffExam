using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace UnitTestProject
{
    [TestClass]
    public class Task3Tests
    {
        [TestMethod]
        public void TestMainMethodWithRootAndSubdirectories()
        {
            using (var input = new StringReader("3\nParent\nParent\\Child\nParent\\Child\\Grandchild\n"))
            {
                Console.SetIn(input);

                using (var output = new StringWriter())
                {
                    Console.SetOut(output);

                    Task3.Program.Main();

                    string expectedOutput = "Parent\r\n  Child\r\n    Grandchild\r\n";
                    Assert.AreEqual(expectedOutput, output.ToString());
                }
            }
        }

        [TestMethod]
        public void TestMainMethodWithMultipleLevelsAndDirectories()
        {
            // Подготовка входных данных для теста
            string inputString = "7\n" +
                                 "Root\n" +
                                 "Root\\Branch1\n" +
                                 "Root\\Branch2\n" +
                                 "Root\\Branch1\\Leaf1\n" +
                                 "Root\\Branch1\\Leaf2\n" +
                                 "Root\\Branch2\\Leaf3\\Twig\n" +
                                 "Root\\Branch2\\Leaf3\n"
                                 ;
            using (var input = new StringReader(inputString))
            {
                Console.SetIn(input);

                using (var output = new StringWriter())
                {
                    Console.SetOut(output);

                    // Вызов основного метода программы
                    Task3.Program.Main();

                    // Ожидаемый результат, сформированный на основе входных данных
                    string expectedOutput = "Root\r\n" +
                                            "  Branch1\r\n" +
                                            "    Leaf1\r\n" +
                                            "    Leaf2\r\n" +
                                            "  Branch2\r\n" +
                                            "    Leaf3\r\n" +
                                            "      Twig\r\n";

                    // Убедитесь, что ожидаемый результат соответствует фактическому
                    Assert.AreEqual(expectedOutput, output.ToString());
                }
            }
        }

        [TestMethod]
        public void TestMainMethodMultipleLevelsAndDirectories()
        {
            // Подготовка входных данных для теста
            string inputString = "4\n" +
                                 "Root\n" +
                                 "Root\\Branch1\n" +
                                 "Root\\Branch2\n" +
                                 "Root\\Branch1\\Leaf1\n" +
                                 "Root\\Branch1\\Leaf2\n" +
                                 "Root\\Branch2\\Leaf3\n" +
                                 "Root\\Branch2\\Leaf3\\Twig\n"
                                 ;
            using (var input = new StringReader(inputString))
            {
                Console.SetIn(input);

                using (var output = new StringWriter())
                {
                    Console.SetOut(output);

                    // Вызов основного метода программы
                    Task3.Program.Main();

                    // Ожидаемый результат, сформированный на основе входных данных
                    string expectedOutput = "Root\r\n" +
                                            "  Branch1\r\n" +
                                            "    Leaf1\r\n" +
                                            "    Leaf2\r\n" +
                                            "  Branch2\r\n" +
                                            "    Leaf3\r\n" +
                                            "      Twig\r\n";

                    // Убедитесь, что ожидаемый результат соответствует фактическому
                    Assert.AreEqual(expectedOutput, output.ToString());
                }
            }
        }
    }
}
