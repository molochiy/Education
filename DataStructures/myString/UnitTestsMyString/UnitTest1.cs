namespace UnitTestsMyString
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using myString;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodConcatenation()
        {
            MyString a = new MyString();
            MyString b = new MyString();
            a.GetLine("inA.txt");
            b.GetLine("inB.txt");
            Assert.AreEqual((a+b).ToString(), "qwerty1234567890qwerty");
        }

        [TestMethod]
        public void TestMethodEquel1()
        {
            MyString a = new MyString();
            MyString b = new MyString();
            a.GetLine("inA.txt");
            b.GetLine("inC.txt");
            Assert.IsTrue(a == b);
        }

        [TestMethod]
        public void TestMethodEquel2()
        {
            MyString a = new MyString();
            MyString b = new MyString();
            a.GetLine("inA.txt");
            b.GetLine("inB.txt");
            Assert.IsFalse(a == b);
        }

        [TestMethod]
        public void TestMethodNotEquel1()
        {
            MyString a = new MyString();
            MyString b = new MyString();
            a.GetLine("inA.txt");
            b.GetLine("inB.txt");
            Assert.IsTrue(a != b);
        }

        [TestMethod]
        public void TestMethodNotEquel2()
        {
            MyString a = new MyString();
            MyString b = new MyString();
            a.GetLine("inA.txt");
            b.GetLine("inC.txt");
            Assert.IsFalse(a != b);
        }

        [TestMethod]
        public void TestMethodFind1()
        {
            MyString a = new MyString();
            MyString b = new MyString();
            a.GetLine("inA.txt");
            b.GetLine("inD.txt");
            Assert.AreEqual(a.Find(b), 4);
        }

        [TestMethod]
        public void TestMethodFind2()
        {
            MyString a = new MyString();
            MyString b = new MyString();
            a.GetLine("inA.txt");
            b.GetLine("inB.txt");
            Assert.AreEqual(a.Find(b), -1);
        }

        [TestMethod]
        public void TestMethodReplace1()
        {
            MyString a = new MyString();
            MyString b = new MyString();
            MyString c = new MyString();
            a.GetLine("inA.txt");
            b.GetLine("inD.txt");
            c.GetLine("inE.txt");
            Assert.AreEqual(a.Replace(b, c).ToString(), "qwer12ty3");
        }

        [TestMethod]
        public void TestMethodReplace2()
        {
            MyString a = new MyString();
            MyString b = new MyString();
            MyString c = new MyString();
            a.GetLine("inA.txt");
            b.GetLine("inD.txt");
            c.GetLine("inF.txt");
            Assert.AreEqual(a.Replace(b, c).ToString(), "qwer03");
        }

        [TestMethod]
        public void TestMethodReplace3()
        {
            MyString a = new MyString();
            MyString b = new MyString();
            MyString c = new MyString();
            a.GetLine("inA.txt");
            b.GetLine("inD.txt");
            c.GetLine("inG.txt");
            Assert.AreEqual(a.Replace(b, c).ToString(), "qwer-2-103");
        }

        [TestMethod]
        public void TestMethodIndex1()
        {
            MyString a = new MyString();
            a.GetLine("inA.txt");
            Assert.AreEqual(a[0], 'q');
        }

        [TestMethod]
        public void TestMethodIndex2()
        {
            MyString a = new MyString();
            a.GetLine("inA.txt");
            a[0] = '0';
            Assert.AreEqual(a.ToString(), "0werty123");
        }

        [TestMethod]
        public void TestCopyConstructor()
        {
            MyString a = new MyString();
            a.GetLine("inA.txt");
            MyString b = new MyString(a);
            Assert.IsTrue(a == b);
        }
    }
}
