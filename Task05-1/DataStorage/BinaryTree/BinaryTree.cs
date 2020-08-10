using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace DataStorage
{
    /// <summary>
    /// Binary tree.
    /// </summary>
    /// <typeparam name="T">Type tree data.</typeparam>
    [Serializable]
    public class BinaryTree<T> where T : IComparable
    {
        /// <summary>
        /// Create binary tree.
        /// </summary>
        public BinaryTree()
        {
            RootNode = null;
        }
        /// <summary>
        /// Root node.
        /// </summary>
        public BinaryTreeNode<T> RootNode { get; set; }
        /// <summary>
        /// Add new node in tree.
        /// </summary>
        /// <param name="node">Node.</param>
        /// <param name="currentNode">Current node.</param>
        /// <returns>This node in tree.</returns>
        public BinaryTreeNode<T> Add(BinaryTreeNode<T> node, BinaryTreeNode<T> currentNode = null)
        {
            if (RootNode == null)
            {
                node.ParentNode = null;
                return RootNode = node;
            }

            currentNode = currentNode ?? RootNode;
            node.ParentNode = currentNode;
            int result = node.Data.CompareTo(currentNode.Data);
            if (result == 0) return currentNode;
            if (result < 0)
            {
                if (currentNode.LeftNode == null)
                {
                    currentNode.LeftNode = node;
                    return node;
                }
                else
                {
                    return Add(node, currentNode.LeftNode);
                }
            }
            else
            {
                if (currentNode.RightNode == null)
                {
                    currentNode.RightNode = node;
                    return node;
                }
                else
                {
                    return Add(node, currentNode.RightNode);
                }
            }
        }
        /// <summary>
        /// Add new node in tree.
        /// </summary>
        /// <param name="data">Data.</param>
        /// <returns>This node in tree.</returns>
        public BinaryTreeNode<T> Add(T data)
        {
            return Add(new BinaryTreeNode<T>(data));
        }
        /// <summary>
        /// Find node in tree.
        /// </summary>
        /// <param name="data">Data.</param>
        /// <param name="startWithNode">Start node.</param>
        /// <returns>This node in tree.</returns>
        public BinaryTreeNode<T> FindNode(T data, BinaryTreeNode<T> startWithNode = null)
        {
            startWithNode = startWithNode ?? RootNode;
            int result = data.CompareTo(startWithNode.Data);
            if (result == 0) return startWithNode;
            if (result < 0)
            {
                if (startWithNode.LeftNode == null) return null;
                else return FindNode(data, startWithNode.LeftNode);
            }
            else
            {
                if (startWithNode.RightNode == null) return null;
                else return FindNode(data, startWithNode.RightNode);
            }
        }

        /// <summary>
        /// Remove node from tree.
        /// </summary>
        /// <param name="node">Node.</param>
        public void Remove(BinaryTreeNode<T> node)
        {
            if (node == null) return;

            var currentNodeSide = node.NodeSide;

            if (node.LeftNode == null && node.RightNode == null)
            {
                if (currentNodeSide == Side.Left) node.ParentNode.LeftNode = null;
                else node.ParentNode.RightNode = null;
            }
            else if (node.LeftNode == null)
            {
                if (currentNodeSide == Side.Left) node.ParentNode.LeftNode = node.RightNode;
                else node.ParentNode.RightNode = node.RightNode;

                node.RightNode.ParentNode = node.ParentNode;
            }
            else if (node.RightNode == null)
            {
                if (currentNodeSide == Side.Left) node.ParentNode.LeftNode = node.LeftNode;
                else node.ParentNode.RightNode = node.LeftNode;

                node.LeftNode.ParentNode = node.ParentNode;
            }
            else
            {
                switch (currentNodeSide)
                {
                    case Side.Left:
                        node.ParentNode.LeftNode = node.RightNode;
                        node.RightNode.ParentNode = node.ParentNode;
                        Add(node.LeftNode, node.RightNode);
                        break;
                    case Side.Right:
                        node.ParentNode.RightNode = node.RightNode;
                        node.RightNode.ParentNode = node.ParentNode;
                        Add(node.LeftNode, node.RightNode);
                        break;
                    default:
                        var bufLeft = node.LeftNode;
                        var bufRightLeft = node.RightNode.LeftNode;
                        var bufRightRight = node.RightNode.RightNode;
                        node.Data = node.RightNode.Data;
                        node.RightNode = bufRightRight;
                        node.LeftNode = bufRightLeft;
                        Add(bufLeft, node);
                        break;
                }
            }
        }
        /// <summary>
        /// Remove node from tree.
        /// </summary>
        /// <param name="data">Data.</param>
        public void Remove(T data)
        {
            var foundNode = FindNode(data);
            Remove(foundNode);
        }

        /// <summary>
        /// Balansing tree.
        /// </summary>
        public void BalancingTree()
        {
            List<T> listNodes = RootNode.ToList();
            listNodes.Sort();
            RootNode = null;
            ListToTree(-1, listNodes.Count, listNodes);
        }

        private void ListToTree(int start, int end, List<T> listNodes)
        {
            int middle = (start + end) / 2;
            if(start < middle && end > middle)
            {
                Add(listNodes.ElementAt(middle));
                ListToTree(start, middle, listNodes);
                ListToTree(middle, end, listNodes);
            }   
        }

        /// <summary>
        /// Repair tree link.
        /// </summary>
        public void Repair()
        {
            List<T> listNodes = RootNode.ToList();
            RootNode = null;
            foreach (var node in listNodes)
            {
                Add(node);
            }
        }

        /// <summary>
        /// Determines whether two objects are equal.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>Result.</returns>
        public override bool Equals(object obj)
        {
            return obj is BinaryTree<T> tree &&
                   EqualityComparer<BinaryTreeNode<T>>.Default.Equals(RootNode, tree.RootNode);
        }

        /// <summary>
        /// Get object hash code.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return -120845931 + EqualityComparer<BinaryTreeNode<T>>.Default.GetHashCode(RootNode);
        }
        /// <summary>
        /// Convert object to string.
        /// </summary>
        /// <returns>Result.</returns>
        public override string ToString()
        {
            return RootNode.ToString();
        }

    }
}
