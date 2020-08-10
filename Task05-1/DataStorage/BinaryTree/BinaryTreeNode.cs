using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace DataStorage
{
    /// <summary>
    /// Binary tree node. 
    /// </summary>
    /// <typeparam name="T">Type of node data</typeparam>
    [Serializable]
    public class BinaryTreeNode<T> where T : IComparable
    {
        /// <summary>
        /// Data node.
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// Left node.
        /// </summary>
        public BinaryTreeNode<T> LeftNode { get; set; }
        /// <summary>
        /// Right node.
        /// </summary>
        public BinaryTreeNode<T> RightNode { get; set; }
        /// <summary>
        /// Node parant.
        /// </summary>
        [XmlIgnore]
        public BinaryTreeNode<T> ParentNode { get; set; }

        /// <summary>
        /// Create node.
        /// </summary>
        /// <param name="data">Node data.</param>
        public BinaryTreeNode(T data = default(T))
        {
            Data = data;
        }
        /// <summary>
        /// Create node.
        /// </summary>
        public BinaryTreeNode()
        {
            Data = default(T);
        }

        /// <summary>
        /// Convert node to list.
        /// </summary>
        /// <returns>List nodes.</returns>
        public List<T> ToList()
        {
            List<T> listNodes = new List<T>();
            listNodes.Add(Data);
            if (LeftNode != null) listNodes.AddRange(LeftNode.ToList());
            if (RightNode != null) listNodes.AddRange(RightNode.ToList());
            return listNodes;
        }
        /// <summary>
        /// Return node side.
        /// </summary>
        public Side? NodeSide
        {
            get
            {
                if (ParentNode == null) return null;
                if (ParentNode.LeftNode == this) return Side.Left;
                    else return Side.Right;
            }
        }

        /// <summary>
        /// Determines whether two objects are equal.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>Result.</returns>
        public override bool Equals(object obj)
        {
            return obj is BinaryTreeNode<T> node &&
                   EqualityComparer<T>.Default.Equals(Data, node.Data) &&
                   EqualityComparer<BinaryTreeNode<T>>.Default.Equals(LeftNode, node.LeftNode) &&
                   EqualityComparer<BinaryTreeNode<T>>.Default.Equals(RightNode, node.RightNode) &&
                   NodeSide == node.NodeSide;
        }
        /// <summary>
        /// Get object hash code.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            int hashCode = 1235913921;
            hashCode = hashCode * -1521134295 + EqualityComparer<T>.Default.GetHashCode(Data);
            hashCode = hashCode * -1521134295 + EqualityComparer<BinaryTreeNode<T>>.Default.GetHashCode(LeftNode);
            hashCode = hashCode * -1521134295 + EqualityComparer<BinaryTreeNode<T>>.Default.GetHashCode(RightNode);
            hashCode = hashCode * -1521134295 + NodeSide.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Convert object to string.
        /// </summary>
        /// <returns>Result.</returns>
        public override string ToString()
        {
            return "{" + ((LeftNode != null) ? LeftNode.ToString() : "") + 
                Data.ToString() +
                ((RightNode != null) ? RightNode.ToString() : "") + 
                "}";
        }

    }
}
