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
    public class Task5Tests
    {
        [TestMethod, Timeout(1000)]
        public void TestMain_ComplexScenario1()
        {
            using (var output = new StringWriter())
            {
                Console.SetOut(output);
                using (var input = new StringReader("4\nW.W\nCWC\nW.W\nCWW\n"))
                {
                    Console.SetIn(input);
                    Task5.Program.Main();
                    string expectedOutput = "2\r\n"; // As per provided expected output
                    Assert.AreEqual(expectedOutput, output.ToString());
                }
            }
        }

        [TestMethod, Timeout(1000)]
        public void TestMain_ComplexScenario2()
        {
            using (var output = new StringWriter())
            {
                Console.SetOut(output);
                using (var input = new StringReader("4\nW.W\n..C\nWW.\nC..\n"))
                {
                    Console.SetIn(input);
                    Task5.Program.Main();
                    string expectedOutput = "1\r\n"; // As per provided expected output
                    Assert.AreEqual(expectedOutput, output.ToString());
                }
            }
        }

        [TestMethod, Timeout(1000)]
        public void TestMain_ComplexScenario3()
        {
            using (var output = new StringWriter())
            {
                Console.SetOut(output);
                using (var input = new StringReader("5\nW.W\nC.C\nWW.\nCC.\nCWW\n"))
                {
                    Console.SetIn(input);
                    Task5.Program.Main();
                    string expectedOutput = "3\r\n"; // As per provided expected output
                    Assert.AreEqual(expectedOutput, output.ToString());
                }
            }
        }


        [TestMethod, Timeout(1000)]
        public void TestMain_Null()
        {
            using (var output = new StringWriter())
            {
                Console.SetOut(output);
                using (var input = new StringReader("5\nWWW\nW.W\n..C\nWW.\nC..\n"))
                {
                    Console.SetIn(input);
                    Task5.Program.Main();
                    string expectedOutput = "0\r\n"; // As per provided expected output
                    Assert.AreEqual(expectedOutput, output.ToString());
                }
            }
        }

        [TestMethod, Timeout(1000)]
        public void TestMain_Many()
        {
            using (var output = new StringWriter())
            {
                Console.SetOut(output);
                using (var input = new StringReader("7\nW.W\nCCC\nWW.\nCCC\nWWW\nCCC\nCCC\n"))
                {
                    Console.SetIn(input);
                    Task5.Program.Main();
                    string expectedOutput = "2\r\n";
                    Assert.AreEqual(expectedOutput, output.ToString());
                }
            }
        }

        [TestMethod, Timeout(1000)]
        public void TestMain_Lock()
        {
            using (var output = new StringWriter())
            {
                Console.SetOut(output);
                using (var input = new StringReader("10\nW.W\nCC.\nCW.\nCW.\nWWC\nCCC\nCCC\nCCC\nCCC\nCCC\n"))
                {
                    Console.SetIn(input);
                    Task5.Program.Main();
                    string expectedOutput = "7\r\n";
                    Assert.AreEqual(expectedOutput, output.ToString());
                }
            }
        }
    }
}
