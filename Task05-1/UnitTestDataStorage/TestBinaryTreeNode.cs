using System;
using Students;
using System.Collections.Generic;
using DataStorage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestDataStorage
{
    [TestClass]
    public class TestBinaryTreeNode
    {
        [TestMethod]
        public void TestToListInt()
        {
            BinaryTreeNode<int> node = new BinaryTreeNode<int>(1);
            BinaryTreeNode<int> nodeLeft = new BinaryTreeNode<int>(2);
            BinaryTreeNode<int> nodeRight = new BinaryTreeNode<int>(3);
            node.LeftNode = nodeLeft;
            node.RightNode = nodeRight;
            List<int> list = new List<int>();
            list.AddRange(new int[]{ 1, 2, 3 });
            CollectionAssert.AreEqual(list, node.ToList());
        }
        [TestMethod]
        public void TestToListString()
        {
            BinaryTreeNode<string> node = new BinaryTreeNode<string>("1");
            BinaryTreeNode<string> nodeLeft = new BinaryTreeNode<string>("2");
            BinaryTreeNode<string> nodeRight = new BinaryTreeNode<string>("3");
            node.LeftNode = nodeLeft;
            node.RightNode = nodeRight;
            List<string> list = new List<string>();
            list.AddRange(new string[] { "1", "2", "3" });
            CollectionAssert.AreEqual(list, node.ToList());
        }
        [TestMethod]
        public void TestToListStudentTest()
        {
            BinaryTreeNode<StudentTest> node = new BinaryTreeNode<StudentTest>(new StudentTest("a", "b", new DateTime(10,10,10), 1));
            BinaryTreeNode<StudentTest> nodeLeft = new BinaryTreeNode<StudentTest>(new StudentTest("c", "d", new DateTime(10, 10, 10), 2));
            BinaryTreeNode<StudentTest> nodeRight = new BinaryTreeNode<StudentTest>(new StudentTest("f", "g", new DateTime(10, 10, 10), 3));
            node.LeftNode = nodeLeft;
            node.RightNode = nodeRight;
            List<StudentTest> list = new List<StudentTest>();
            list.AddRange(new StudentTest[] { new StudentTest("a", "b", new DateTime(10, 10, 10), 1),
                new StudentTest("c", "d", new DateTime(10, 10, 10), 2),
                new StudentTest("f", "g", new DateTime(10, 10, 10), 3) 
            });
            CollectionAssert.AreEqual(list, node.ToList());
        }
    }
}
