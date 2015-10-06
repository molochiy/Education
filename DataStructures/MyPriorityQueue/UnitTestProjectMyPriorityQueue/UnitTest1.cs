using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyPriorityQueue;

namespace UnitTestProjectMyPriorityQueue
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodSize()
        {
            PriorityQueue<double> testQueue = new PriorityQueue<double>();
            Assert.IsTrue(testQueue.Size() == 0);
        }

        [TestMethod]
        public void TestMethodSizeAndPushAndPop()
        {
            PriorityQueue<double> testQueue = new PriorityQueue<double>();
            testQueue.Push(1,2);
            testQueue.Pop();
            Assert.IsTrue(testQueue.Size() == 0);
        }

        [TestMethod]
        public void TestMethodSizeAndPush()
        {
            PriorityQueue<double> testQueue = new PriorityQueue<double>();
            testQueue.Push(1, 2);
            testQueue.Push(2, 2);
            testQueue.Push(1, 3);
            Assert.IsTrue(testQueue.Size() == 3);
        }

        [TestMethod]
        public void TestMethodPushAndTop()
        {
            PriorityQueue<double> testQueue = new PriorityQueue<double>();
            testQueue.Push(1, 2);
            testQueue.Push(2, 2);
            testQueue.Push(1, 3);
            Assert.IsTrue(testQueue.Top() == 2);
        }

        [TestMethod]
        public void TestMethodPushAndTopAndPop()
        {
            PriorityQueue<double> testQueue = new PriorityQueue<double>();            
            testQueue.Push(2, 2);
            testQueue.Push(1, 2);
            testQueue.Push(1, 3);
            testQueue.Push(5, 2);
            testQueue.Push(3, 1);
            testQueue.Push(1, 1);
            testQueue.Pop();
            Assert.IsTrue(testQueue.Top() == 3);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestMethodTopOnException()
        {
            PriorityQueue<double> testQueue = new PriorityQueue<double>();
            testQueue.Top();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestMethodPopOnException()
        {
            PriorityQueue<double> testQueue = new PriorityQueue<double>();
            testQueue.Pop();
        }
    }
}
