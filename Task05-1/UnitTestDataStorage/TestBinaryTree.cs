using System;
using Students;
using System.IO;
using System.Xml.Serialization;
using DataStorage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestDataStorage
{
    [TestClass]
    public class TestBinaryTree
    {
        [TestMethod]
        public void TestFindNodeInt()
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>();
            binaryTree.Add(1);
            binaryTree.Add(2);
            binaryTree.Add(3);
            Assert.AreEqual(2, binaryTree.FindNode(2).Data);
        }
        [TestMethod]
        public void TestFindNodeStudentTest()
        {
            BinaryTree<StudentTest> binaryTree = new BinaryTree<StudentTest>();
            binaryTree.Add(new StudentTest("Student", "Test", new DateTime(10, 10, 10), 1));
            binaryTree.Add(new StudentTest("Student", "Test", new DateTime(10, 10, 10), 2));
            binaryTree.Add(new StudentTest("Student", "Test", new DateTime(10, 10, 10), 3));
            Assert.AreEqual(new StudentTest("Student", "Test", new DateTime(10, 10, 10), 2), 
                binaryTree.FindNode(new StudentTest("Student", "Test", new DateTime(10, 10, 10), 2)).Data);
        }
        [TestMethod]
        public void TestRemoveInt()
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>();
            binaryTree.Add(1);
            binaryTree.Add(2);
            binaryTree.Add(3);
            binaryTree.Remove(2);
            Assert.IsNull(binaryTree.FindNode(2));
        }
        [TestMethod]
        public void TestRemoveStudentTest()
        {
            BinaryTree<StudentTest> binaryTree = new BinaryTree<StudentTest>();
            binaryTree.Add(new StudentTest("Student", "Test", new DateTime(10, 10, 10), 1));
            binaryTree.Add(new StudentTest("Student", "Test", new DateTime(10, 10, 10), 2));
            binaryTree.Add(new StudentTest("Student", "Test", new DateTime(10, 10, 10), 3));
            binaryTree.Remove(new StudentTest("Student", "Test", new DateTime(10, 10, 10), 2));
            Assert.IsNull(binaryTree.FindNode(new StudentTest("Student", "Test", new DateTime(10, 10, 10), 2)));
        }
        [TestMethod]
        public void TestBalancingTreeInt()
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>();
            binaryTree.Add(1);
            binaryTree.Add(2);
            binaryTree.Add(3);
            binaryTree.BalancingTree();
            BinaryTree<int> binaryTreeBalancing = new BinaryTree<int>();
            binaryTreeBalancing.Add(2);
            binaryTreeBalancing.Add(1);
            binaryTreeBalancing.Add(3);
            Assert.AreEqual(binaryTreeBalancing, binaryTree);
        }
        [TestMethod]
        public void TestBalancingTreeStudentTest()
        {
            BinaryTree<StudentTest> binaryTree = new BinaryTree<StudentTest>();
            binaryTree.Add(new StudentTest("Student", "Test", new DateTime(10, 10, 10), 1));
            binaryTree.Add(new StudentTest("Student", "Test", new DateTime(10, 10, 10), 2));
            binaryTree.Add(new StudentTest("Student", "Test", new DateTime(10, 10, 10), 3));
            binaryTree.BalancingTree();
            BinaryTree<StudentTest> binaryTreeBalancing = new BinaryTree<StudentTest>();
            binaryTreeBalancing.Add(new StudentTest("Student", "Test", new DateTime(10, 10, 10), 2));
            binaryTreeBalancing.Add(new StudentTest("Student", "Test", new DateTime(10, 10, 10), 1));
            binaryTreeBalancing.Add(new StudentTest("Student", "Test", new DateTime(10, 10, 10), 3));
            Assert.AreEqual(binaryTreeBalancing, binaryTree);
        }
        [TestMethod]
        public void TestSerializationDeserializationInt()
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>();
            binaryTree.Add(4);
            binaryTree.Add(2);
            binaryTree.Add(6);
            binaryTree.Add(1);
            binaryTree.Add(3);
            binaryTree.Add(5);
            binaryTree.Add(7);
            binaryTree.BalancingTree();
            BinaryTree<int> binaryTreeDeserializat;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BinaryTree<int>));
            using (Stream file = File.Open("../../../test.xml", FileMode.OpenOrCreate))
                xmlSerializer.Serialize(file, binaryTree);
            using (Stream file = File.Open("../../../test.xml", FileMode.Open))
                binaryTreeDeserializat = (BinaryTree<int>)xmlSerializer.Deserialize(file);
            binaryTreeDeserializat.Repair();
            Assert.AreEqual(binaryTree, binaryTreeDeserializat);
        }
        [TestMethod]
        public void TestSerializationDeserializationStudentTest()
        {
            BinaryTree<StudentTest> binaryTree = new BinaryTree<StudentTest>();
            binaryTree.Add(new StudentTest("Student", "Test", new DateTime(10, 10, 10), 1));
            binaryTree.Add(new StudentTest("Student", "Test", new DateTime(10, 10, 10), 2));
            binaryTree.Add(new StudentTest("Student", "Test", new DateTime(10, 10, 10), 3));
            binaryTree.Add(new StudentTest("Student", "Test", new DateTime(10, 10, 10), 4));
            binaryTree.Add(new StudentTest("Student", "Test", new DateTime(10, 10, 10), 5));
            binaryTree.Add(new StudentTest("Student", "Test", new DateTime(10, 10, 10), 6));
            binaryTree.Add(new StudentTest("Student", "Test", new DateTime(10, 10, 10), 7));
            binaryTree.BalancingTree();
            BinaryTree<StudentTest> binaryTreeDeserializat;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BinaryTree<StudentTest>));
            using (Stream file = File.Open("../../../test.xml", FileMode.OpenOrCreate))
                xmlSerializer.Serialize(file, binaryTree);
            using (Stream file = File.Open("../../../test.xml", FileMode.Open))
                binaryTreeDeserializat = (BinaryTree<StudentTest>)xmlSerializer.Deserialize(file);
            binaryTreeDeserializat.BalancingTree();
            Assert.AreEqual(binaryTree, binaryTreeDeserializat);
        }
    }
}
