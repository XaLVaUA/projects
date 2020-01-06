using System;

namespace Task3_Core.BinaryTrees
{
    internal class BinaryTreeNode<T> where T : IComparable<T>
    {
        public T Data { get; set; }

        public BinaryTreeNode<T> ParentNode { get; set; }

        public BinaryTreeNode<T> RightNode { get; set; }

        public BinaryTreeNode<T> LeftNode { get; set; }

        public BinaryTreeNode(T data)
        {
            ParentNode = null;
            RightNode = null;
            LeftNode = null;
            Data = data;
        }
    }
}