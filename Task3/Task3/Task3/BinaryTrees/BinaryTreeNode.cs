using System;

namespace Task3.BinaryTrees
{
    internal class BinaryTreeNode<T> where T : IComparable<T>
    {
        public BinaryTree<T> Tree { get; set; }

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

        public static bool operator >(BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            return left.Data.CompareTo(right.Data) > 0;
        }

        public static bool operator <(BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            return left.Data.CompareTo(right.Data) < 0;
        }
    }
}