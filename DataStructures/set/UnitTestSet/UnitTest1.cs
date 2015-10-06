using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using set;

namespace UnitTestSet
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodFindElement()
        {
            Set<int> s = new Set<int>();
            Assert.AreEqual(s.FindElement(1), false);
        }

        [TestMethod]
        public void TestMethodAddElement()
        {
            Set<int> s = new Set<int>();
            s.AddElement(0);
            s.AddElement(1);
            Assert.AreEqual(s.FindElement(1), true);
        }

        [TestMethod]
        public void TestMethodRemoveElement()
        {
            Set<int> s = new Set<int>();
            s.AddElement(0);
            s.AddElement(1);
            s.AddElement(1);
            s.RemoveElement(1);
            Assert.AreEqual(s.FindElement(1), false);
        }

        [TestMethod]
        public void TestMethodUnionWithSet()
        {
            Set<int> s1 = new Set<int>();
            s1.AddElement(0);
            s1.AddElement(1);
            Set<int> s2 = new Set<int>();
            s2.AddElement(1);
            s2.AddElement(2);
            s2.AddElement(3);
            Set<int> s3 = new Set<int>();
            for (int i = 0; i < 4; i++)
            {
                s3.AddElement(i);
            }
            Assert.IsTrue(s3 == s1.UnionWithSet(s2));
        }

        [TestMethod]
        public void TestMethodIntersectionWithSet()
        {
            Set<int> s1 = new Set<int>();
            s1.AddElement(0);
            s1.AddElement(1);
            s1.AddElement(2);
            Set<int> s2 = new Set<int>();
            s2.AddElement(1);
            s2.AddElement(2);
            s2.AddElement(3);
            Set<int> s3 = new Set<int>();
            s3.AddElement(1);
            s3.AddElement(2);
            Assert.IsTrue(s3 == s1.IntersectionWithSet(s2));
        }

        [TestMethod]
        public void TestMethodDifferenceWithSet()
        {
            Set<int> s1 = new Set<int>();
            s1.AddElement(0);
            s1.AddElement(1);
            s1.AddElement(2);
            Set<int> s2 = new Set<int>();
            s2.AddElement(1);
            s2.AddElement(2);
            s2.AddElement(3);
            Set<int> s3 = new Set<int>();
            s3.AddElement(0);
            Assert.IsTrue(s3 == s1.DifferenceWithSet(s2));
        }
    }
}
