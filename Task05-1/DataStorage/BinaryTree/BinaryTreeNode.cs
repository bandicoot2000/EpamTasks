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
    [Serializable]
    public class BinaryTreeNode<T> where T : IComparable
    {
        public T Data { get; set; }

        public BinaryTreeNode<T> LeftNode { get; set; }

        public BinaryTreeNode<T> RightNode { get; set; }

        [XmlIgnore]
        public BinaryTreeNode<T> ParentNode { get; set; }

        public BinaryTreeNode(T data = default(T))
        {
            Data = data;
        }

        public BinaryTreeNode()
        {
            Data = default(T);
        }

        public List<T> ToList()
        {
            List<T> listNodes = new List<T>();
            listNodes.Add(Data);
            if (LeftNode != null) listNodes.AddRange(LeftNode.ToList());
            if (RightNode != null) listNodes.AddRange(RightNode.ToList());
            return listNodes;
        }

        public Side? NodeSide
        {
            get
            {
                if (ParentNode == null) return null;
                if (ParentNode.LeftNode == this) return Side.Left;
                    else return Side.Right;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is BinaryTreeNode<T> node &&
                   EqualityComparer<T>.Default.Equals(Data, node.Data) &&
                   EqualityComparer<BinaryTreeNode<T>>.Default.Equals(LeftNode, node.LeftNode) &&
                   EqualityComparer<BinaryTreeNode<T>>.Default.Equals(RightNode, node.RightNode) &&
                   NodeSide == node.NodeSide;
        }

        public override int GetHashCode()
        {
            int hashCode = 1235913921;
            hashCode = hashCode * -1521134295 + EqualityComparer<T>.Default.GetHashCode(Data);
            hashCode = hashCode * -1521134295 + EqualityComparer<BinaryTreeNode<T>>.Default.GetHashCode(LeftNode);
            hashCode = hashCode * -1521134295 + EqualityComparer<BinaryTreeNode<T>>.Default.GetHashCode(RightNode);
            hashCode = hashCode * -1521134295 + NodeSide.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "{" + ((LeftNode != null) ? LeftNode.ToString() : "") + 
                Data.ToString() +
                ((RightNode != null) ? RightNode.ToString() : "") + 
                "}";
        }

    }
}
