using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Task3_Core.BinaryTrees.Exceptions;

namespace Task3_Core.BinaryTrees
{
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private BinaryTreeNode<T> _root;

        public event EventHandler OnElementAdd;

        public event EventHandler OnElementRemove;

        public int Count { get; private set; }

        public IEnumerable<T> PreOrder
        {
            get
            {
                if (_root != null)
                {
                    foreach (var node in PreOrderTraversal(_root))
                    {
                        yield return node.Data;
                    }
                }
            }
        }

        public IEnumerable<T> InOrder
        {
            get
            {
                if (_root != null)
                {
                    foreach (var node in InOrderTraversal(_root))
                    {
                        yield return node.Data;
                    }
                }
            }
        }

        public IEnumerable<T> OutOrder
        {
            get
            {
                if (_root != null)
                {
                    foreach (var node in OutOrderTraversal(_root))
                    {
                        yield return node.Data;
                    }
                }
            }
        }

        public IEnumerable<T> PostOrder
        {
            get
            {
                if (_root != null)
                {
                    foreach (var node in PostOrderTraversal(_root))
                    {
                        yield return node.Data;
                    }
                }
            }
        }


        public IEnumerable<T> BreadthFirst
        {
            get
            {
                if (_root != null)
                {
                    foreach (var node in BreadthFirstTraversal(_root))
                    {
                        yield return node.Data;
                    }
                }
            }
        }

        public BinaryTree()
        {
            _root = null;
            Count = 0;
        }

        public bool Add(T item)
        {
            if (ReferenceEquals(item, null))
            {
                return false;
            }

            var result = AddNode(new BinaryTreeNode<T>(item));

            if (result == null) return false;

            ++Count;

            OnElementAdd?.Invoke(this, EventArgs.Empty);
            return true;
        }

        public bool Remove(T item)
        {
            if (ReferenceEquals(item, null))
            {
                return false;
            }

            var node = FindNode(_root, item);
            if (node == null) return false;

            var result = RemoveNode(node);
            if (result == false) return false;

            --Count;

            OnElementRemove?.Invoke(this, EventArgs.Empty);
            return true;
        }

        public T TreeMax()
        {
            if (_root == null)
            {
                throw new BinaryTreeEmptyTreeException();
            }

            return MaxNode(_root).Data;
        }

        public T TreeMin()
        {
            if (_root == null)
            {
                throw new BinaryTreeEmptyTreeException();
            }

            return MinNode(_root).Data;
        }

        public bool Contains(T data)
        {
            if (data == null)
            {
                return false;
            }

            return FindNode(_root, data) != null;
        }

        private BinaryTreeNode<T> MaxNode(BinaryTreeNode<T> node)
        {
            while (node.RightNode != null)
            {
                node = node.RightNode;
            }

            return node;
        }

        private BinaryTreeNode<T> MinNode(BinaryTreeNode<T> node)
        {
            while (node.LeftNode != null)
            {
                node = node.LeftNode;
            }

            return node;
        }

        private BinaryTreeNode<T> TreeSuccessor(BinaryTreeNode<T> node)
        {
            if (node.RightNode != null)
            {
                return MinNode(node.RightNode);
            }

            var parent = node.ParentNode;
            while (parent != null && node == parent.RightNode)
            {
                node = parent;
                parent = parent.ParentNode;
            }

            return parent;
        }

        private BinaryTreeNode<T> AddNode(BinaryTreeNode<T> node)
        {
            if (_root == null)
            {
                _root = node;
                return _root;
            }

            BinaryTreeNode<T> addAfterNode;

            {
                var currentNode = _root;
                do
                {
                    addAfterNode = currentNode;
                    currentNode = node.Data.CompareTo(currentNode.Data) < 0 ? currentNode.LeftNode : currentNode.RightNode;
                } while (currentNode != null);
            }

            node.ParentNode = addAfterNode;

            if (node.Data.CompareTo(addAfterNode.Data) < 0)
            {
                addAfterNode.LeftNode = node;
            }
            else
            {
                addAfterNode.RightNode = node;
            }

            return node;
        }

        private BinaryTreeNode<T> FindNode(BinaryTreeNode<T> node, T data)
        {
            while (node != null && !node.Data.Equals(data))
            {
                if (data.CompareTo(node.Data) > 0)
                {
                    return FindNode(node.RightNode, data);
                }
                else
                {
                    return FindNode(node.LeftNode, data);
                }
            }

            return node;
        }

        private bool RemoveNode(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return false;
            }

            if (node.LeftNode == null && node.RightNode == null)
            {
                if (node == _root)
                {
                    _root = null;
                    return true;
                }

                if (node.ParentNode.LeftNode == node)
                {
                    node.ParentNode.LeftNode = null;
                }
                else
                {
                    node.ParentNode.RightNode = null;
                }

                return true;
            }

            if (node.RightNode == null)
            {
                if (node == _root)
                {
                    _root = node.LeftNode;
                    return true;
                }

                if (node.ParentNode.LeftNode == node)
                {
                    node.ParentNode.LeftNode = node.LeftNode;
                }
                else
                {
                    node.ParentNode.RightNode = node.LeftNode;
                }

                return true;
            }

            if (node.LeftNode == null)
            {
                if (node == _root)
                {
                    _root = node.RightNode;
                    return true;
                }

                if (node.ParentNode.LeftNode == node)
                {
                    node.ParentNode.LeftNode = node.RightNode;
                }
                else
                {
                    node.ParentNode.RightNode = node.RightNode;
                }

                return true;
            }

            var successor = TreeSuccessor(node);

            if (successor.RightNode == null)
            {
                if (successor.ParentNode.LeftNode == successor)
                {
                    successor.ParentNode.LeftNode = successor.LeftNode;
                }
                else
                {
                    successor.ParentNode.RightNode = successor.LeftNode;
                }
            }
            else
            {
                if (successor.ParentNode.LeftNode == successor)
                {
                    successor.ParentNode.LeftNode = successor.RightNode;
                }
                else
                {
                    successor.ParentNode.RightNode = successor.RightNode;
                }
            }

            if (node == _root)
            {
                successor.LeftNode = _root.LeftNode;
                successor.RightNode = _root.RightNode;
                successor.ParentNode = null;
                _root = successor;
                return true;
            }

            if (node.ParentNode.LeftNode == node)
            {
                node.ParentNode.LeftNode = successor;
            }
            else
            {
                node.ParentNode.RightNode = successor;
            }

            successor.LeftNode = node.LeftNode;
            successor.RightNode = node.RightNode;
            successor.ParentNode = node.ParentNode;

            return true;
        }

        private IEnumerable<BinaryTreeNode<T>> PreOrderTraversal(BinaryTreeNode<T> node)
        {
            yield return node;
            if (node.LeftNode != null)
            {
                foreach (var treeNode in PreOrderTraversal(node.LeftNode))
                {
                    yield return treeNode;
                }
            }

            if (node.RightNode != null)
            {
                foreach (var treeNode in PreOrderTraversal(node.RightNode))
                {
                    yield return treeNode;
                }
            }
        }

        private IEnumerable<BinaryTreeNode<T>> InOrderTraversal(BinaryTreeNode<T> node)
        {
            if (node.LeftNode != null)
            {
                foreach (var treeNode in InOrderTraversal(node.LeftNode))
                {
                    yield return treeNode;
                }
            }

            yield return node;

            if (node.RightNode != null)
            {
                foreach (var treeNode in InOrderTraversal(node.RightNode))
                {
                    yield return treeNode;
                }
            }
        }

        private IEnumerable<BinaryTreeNode<T>> OutOrderTraversal(BinaryTreeNode<T> node)
        {
            if (node.RightNode != null)
            {
                foreach (var treeNode in OutOrderTraversal(node.RightNode))
                {
                    yield return treeNode;
                }
            }

            yield return node;

            if (node.LeftNode != null)
            {
                foreach (var treeNode in OutOrderTraversal(node.LeftNode))
                {
                    yield return treeNode;
                }
            }
        }

        private IEnumerable<BinaryTreeNode<T>> PostOrderTraversal(BinaryTreeNode<T> node)
        {
            if (node.LeftNode != null)
            {
                foreach (var treeNode in PostOrderTraversal(node.LeftNode))
                {
                    yield return treeNode;
                }
            }

            if (node.RightNode != null)
            {
                foreach (var treeNode in PostOrderTraversal(node.RightNode))
                {
                    yield return treeNode;
                }
            }

            yield return node;
        }

        private IEnumerable<BinaryTreeNode<T>> BreadthFirstTraversal(BinaryTreeNode<T> node)
        {
            var queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();

                yield return currentNode;

                if (currentNode.LeftNode != null)
                {
                    queue.Enqueue(currentNode.LeftNode);
                }

                if (currentNode.RightNode != null)
                {
                    queue.Enqueue(currentNode.RightNode);
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var node in InOrder)
            {
                yield return node;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}