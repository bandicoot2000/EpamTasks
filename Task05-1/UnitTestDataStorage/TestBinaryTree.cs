using System;
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
            binaryTreeDeserializat.BalancingTree();
            Assert.AreEqual(binaryTree, binaryTreeDeserializat);
        }
    }
}
