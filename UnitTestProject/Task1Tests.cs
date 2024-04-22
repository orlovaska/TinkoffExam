using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace UnitTestProject
{
    [TestClass]
    public class Task1Tests
    {
        [TestMethod, Timeout(1000)]
        public void TestMain_EnoughGrades_NoTwosOrThrees_MaxFives()
        {
            using (var output = new StringWriter())
            {
                Console.SetOut(output);
                using (var input = new StringReader("7\n4 4 4 5 5 5 5\n"))
                {
                    Console.SetIn(input);
                    Task1.Program.Main(new string[] { });
                    string expectedOutput = "4\r\n";
                    Assert.AreEqual(expectedOutput, output.ToString());
                }
            }
        }

        [TestMethod, Timeout(1000)]
        public void TestMain_NotEnoughGrades()
        {
            using (var output = new StringWriter())
            {
                Console.SetOut(output);
                using (var input = new StringReader("6\n5 5 5 5 5 5\n"))
                {
                    Console.SetIn(input);
                    Task1.Program.Main(new string[] { });
                    string expectedOutput = "-1\r\n";
                    Assert.AreEqual(expectedOutput, output.ToString());
                }
            }
        }

        [TestMethod, Timeout(1000)]
        public void TestMain_GradesWithTwosAndThrees()
        {
            using (var output = new StringWriter())
            {
                Console.SetOut(output);
                using (var input = new StringReader("7\n3 4 5 5 5 2 4\n"))
                {
                    Console.SetIn(input);
                    Task1.Program.Main(new string[] { });
                    string expectedOutput = "-1\r\n";
                    Assert.AreEqual(expectedOutput, output.ToString());
                }
            }
        }

        [TestMethod, Timeout(1000)]
        public void TestMain_AllFives()
        {
            using (var output = new StringWriter())
            {
                Console.SetOut(output);
                using (var input = new StringReader("7\n5 5 5 5 5 5 5\n"))
                {
                    Console.SetIn(input);
                    Task1.Program.Main(new string[] { });
                    string expectedOutput = "7\r\n";
                    Assert.AreEqual(expectedOutput, output.ToString());
                }
            }
        }

        [TestMethod, Timeout(1000)]
        public void TestMain_NoValidSegment()
        {
            using (var output = new StringWriter())
            {
                Console.SetOut(output);
                using (var input = new StringReader("10\n4 4 3 4 5 5 2 5 4 4\n"))
                {
                    Console.SetIn(input);
                    Task1.Program.Main(new string[] { });
                    string expectedOutput = "-1\r\n";
                    Assert.AreEqual(expectedOutput, output.ToString());
                }
            }
        }
    }
}
