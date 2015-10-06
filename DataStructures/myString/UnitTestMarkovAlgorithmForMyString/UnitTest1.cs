using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using myString;

namespace UnitTestMarkovAlgorithm
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodDoingAlgorithmForMyString30()
        {
            MarkovAlgorithmForMyString m = new MarkovAlgorithmForMyString();
            m.ReadData("in30.txt");
            MyString ms = new MyString(m.DoingAlgorithm());
            string a = string.Empty;
            for (int i = 0; i < 900; i++) a += "1";
            MyString msForCheck = new MyString(a);
            Assert.IsTrue(ms == msForCheck);
        }

        [TestMethod]
        public void TestMethodDoingAlgorithmForString30()
        {
            MarkovAlgorithmForString m = new MarkovAlgorithmForString();
            m.ReadData("in30.txt");
            string ms = m.DoingAlgorithm();
            string msForCheck = string.Empty;
            for (int i = 0; i < 900; i++) msForCheck += "1";
            Assert.IsTrue(ms == msForCheck);
        }

        [TestMethod]
        public void TestMethodDoingAlgorithmForMyString50()
        {
            MarkovAlgorithmForMyString m = new MarkovAlgorithmForMyString();
            m.ReadData("in50.txt");
            MyString ms = new MyString(m.DoingAlgorithm());
            string a = string.Empty;
            for (int i = 0; i < 2500; i++) a += "1";
            MyString msForCheck = new MyString(a);
            Assert.IsTrue(ms == msForCheck);
        }

        [TestMethod]
        public void TestMethodDoingAlgorithmForString50()
        {
            MarkovAlgorithmForString m = new MarkovAlgorithmForString();
            m.ReadData("in50.txt");
            string ms = m.DoingAlgorithm();
            string msForCheck = string.Empty;
            for (int i = 0; i < 2500; i++) msForCheck += "1";
            Assert.IsTrue(ms == msForCheck);
        }
    }
}
