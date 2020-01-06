using System;
using System.Collections;
using System.Collections.Generic;

namespace Task3.BinaryTrees
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

            var result = RemoveNode(FindNode(_root, item));
            if (result == null) return false;

            --Count;

            OnElementRemove?.Invoke(this, EventArgs.Empty);
            return true;
        }

        public T TreeMax()
        {
            return MaxNode(_root).Data;
        }

        public T TreeMin()
        {
            return MinNode(_root).Data;
        }

        private BinaryTreeNode<T> MaxNode(BinaryTreeNode<T> node)
        {
            while (node.LeftNode != null)
            {
                node = node.RightNode;
            }

            return node;
        }

        private BinaryTreeNode<T> MinNode(BinaryTreeNode<T> node)
        {
            while (node.RightNode != null)
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
                return null;
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

        private BinaryTreeNode<T> RemoveNode(BinaryTreeNode<T> node)
        {
            BinaryTreeNode<T> parent;
            if (node.LeftNode == null || node.RightNode == null)
            {
                parent = node;
            }
            else
            {
                parent = TreeSuccessor(node);
            }

            var offspring = node.LeftNode != null ? parent.LeftNode : parent.RightNode;

            if (offspring != null)
            {
                offspring.ParentNode = parent.ParentNode;
            }

            if (parent.ParentNode == null)
            {
                _root = offspring;
                return parent;
            }

            if (parent == parent.ParentNode.LeftNode)
            {
                parent.ParentNode.LeftNode = offspring;
            }
            else
            {
                parent.ParentNode.RightNode = offspring;
            }

            return parent;
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