using System;
using MetronLabsTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestSuite
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestEmptyCheck()
        {
            LinkedList linkedList = new LinkedList();
            Assert.IsTrue(linkedList.IsEmpty());
            for (int i = 0; i < 10; i++)
            {
                linkedList.AddNode(new Node(i * 10));
            }
            Assert.AreEqual(linkedList.Head.Data, 0);
            Assert.AreEqual(linkedList.Tail.Data, 90);
            Assert.IsFalse(linkedList.IsEmpty());
        }

        [TestMethod]
        public void TestInsertElement()
        {
            LinkedList linkedList = new LinkedList();
            for (int i = 0; i < 10; i++)
            {
                linkedList.AddNode(new Node(i));
                var data = linkedList.GetNode(i);
                Assert.AreEqual(data.Data, i);
            }
        }

    }
}
