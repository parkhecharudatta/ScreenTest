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

        [TestMethod]
        public void TestDeleteElement()
        {
            LinkedList linkedList = new LinkedList();
            for (int i = 0; i < 10; i++)
            {
                linkedList.AddNode(new Node(i));
            }

            //Before Delete
            string beforeDelete = linkedList.DisplayLinkedList();
            //Delete Node 8.
            linkedList.DeleteNode(8);
            //After Delete
            string afterDelete = linkedList.DisplayLinkedList();

            Assert.AreNotEqual(afterDelete,beforeDelete);
        }

        [TestMethod]
        public void TestIterationOfElements()
        {
            LinkedList linkedList = new LinkedList();
            for (int i = 0; i < 10; i++)
            {
                linkedList.AddNode(new Node(i));
            }

            //Traversing through list.
            for (int i = 0; i < 10; i++)
            {
                var node = linkedList.GetNode(i);
                Assert.AreEqual(node.Data, i);
            }
        }

        [TestMethod]
        public void TestReverseIterationOfElements()
        {
            LinkedList linkedList = new LinkedList();
            for (int i = 0; i < 10; i++)
            {
                linkedList.AddNode(new Node(i));
            }

            //Traversing through list in reverse order.
            var currentNode = linkedList.Tail;

            Assert.AreEqual(currentNode.Data,9);

            var checkString = "";
            while (currentNode != null)
            {
                checkString += currentNode.Data + " -> ";
                currentNode = currentNode.PrevNode;
            }
            checkString += "null\r\n";

            Assert.AreEqual(checkString,linkedList.DisplayReverseLinkedList());
        }
    }
}
