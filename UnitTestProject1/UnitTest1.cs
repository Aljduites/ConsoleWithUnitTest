using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication1;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Program.Connected();
        }

        [TestMethod]
        public void TestMethod2()
        {
            Program.Connected2();
        }
    }
}
