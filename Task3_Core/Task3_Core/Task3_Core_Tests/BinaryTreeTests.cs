using System;
using NUnit.Framework;
using Task3_Core;
using Task3_Core.BinaryTrees;
using Task3_Core.BinaryTrees.Exceptions;

namespace Task3_Core_Tests
{
    [TestFixture]
    public class BinaryTreeTests
    {
        [Test]
        public void AddLeaf()
        {
            //arrange
            var tree = new BinaryTree<int>() { 1, 2 };

            //act
            var addResult = tree.Add(5);
            addResult = addResult && tree.Add(8);
            var contains = tree.Contains(5) && tree.Contains(8);
            var count = tree.Count;

            //assert
            Assert.True(addResult);
            Assert.True(contains);
            Assert.AreEqual(4, count);
        }

        [Test]
        public void AddRoot()
        {
            //arrange
            var tree = new BinaryTree<int>();

            //act
            var addResult = tree.Add(5);
            var contains = tree.Contains(5);
            var count = tree.Count;

            //assert
            Assert.True(addResult);
            Assert.True(contains);
            Assert.AreEqual(1, count);
        }

        [Test]
        public void AddNull()
        {
            //arrange
            var tree = new BinaryTree<StudentTestInfo>();

            //act
            var addResult = tree.Add(null);
            var count = tree.Count;

            //assert
            Assert.False(addResult);
            Assert.AreEqual(0, count);
        }

        [Test]
        public void Contains()
        {
            //arrange
            var tree = new BinaryTree<int>
            {
                50, 40, 100, 35, 45, 70, 110
            };

            //act
            var contains = tree.Contains(100);

            //assert
            Assert.True(contains);
        }

        [Test]
        public void ContainsNonExisted()
        {
            //arrange
            var tree = new BinaryTree<int>
            {
                50, 40, 100, 35, 45, 70, 110
            };

            //act
            var contains = tree.Contains(200);

            //assert
            Assert.False(contains);
        }

        [Test]
        public void ContainsNull()
        {
            //arrange
            var studentTestInfo = new StudentTestInfo("a", "b", "c", DateTime.Now, 10);
            var tree = new BinaryTree<StudentTestInfo>
            {
                studentTestInfo
            };

            //act
            var contains = tree.Contains(null);

            //assert
            Assert.False(contains);
        }

        [Test]
        public void RemoveNotExisted()
        {
            //arrange
            var tree = new BinaryTree<int>
            {
                50, 40, 100, 35, 45, 70, 110
            };

            //act
            var removeResult = tree.Remove(200);
            var count = tree.Count;

            //assert
            Assert.False(removeResult);
            Assert.AreEqual(7, count);
        }

        [Test]
        public void RemoveNull()
        {
            //arrange
            var studentTestInfo = new StudentTestInfo("a", "b", "c", DateTime.Now, 10);
            var tree = new BinaryTree<StudentTestInfo>
            {
                studentTestInfo
            };

            //act
            var removeResult = tree.Remove(null);
            var count = tree.Count;

            //assert
            Assert.False(removeResult);
            Assert.AreEqual(1, count);
        }

        [Test]
        public void RemoveLeaf()
        {
            //arrange
            var tree = new BinaryTree<int>
            {
                50, 40, 100, 35, 45, 70, 110
            };

            //act
            var removeResult = tree.Remove(45);
            var count = tree.Count;

            //assert
            Assert.True(removeResult);
            Assert.False(tree.Contains(45));
            Assert.AreEqual(6, count);
        }

        [Test]
        public void RemoveIntermediate()
        {
            //arrange
            var tree = new BinaryTree<int>
            {
                50, 40, 100, 35, 45, 70, 110
            };

            //act
            var removeResult =tree.Remove(100);
            var count = tree.Count;

            //assert
            Assert.True(removeResult);
            Assert.False(tree.Contains(100));
            Assert.AreEqual(6, count);
        }

        [Test]
        public void RemoveIntermediateWithSuccessorOffspringsNoOther()
        {
            //arrange
            var tree = new BinaryTree<int>
            {
                50, 40, 100, 35, 45, 70, 110, 65, 90, 105, 120
            };

            //act
            var removeResult = tree.Remove(100);
            var count = tree.Count;

            //assert
            Assert.True(removeResult);
            Assert.False(tree.Contains(100));
            Assert.AreEqual(10, count);
        }

        [Test]
        public void RemoveIntermediateWithSuccessorOffspringsWithOther()
        {
            //arrange
            var tree = new BinaryTree<int>
            {
                10, 7, 18, 2, 6, 3, 9, 4, 13, 34, 8, 11
            };

            //act
            var removeResult = tree.Remove(13);
            var count = tree.Count;

            //assert
            Assert.True(removeResult);
            Assert.False(tree.Contains(100));
            Assert.AreEqual(11, count);
        }

        [Test]
        public void RemoveRoot()
        {
            //arrange
            var tree = new BinaryTree<int>
            {
                50, 40, 100, 35, 45, 70, 110
            };

            //act
            var removeResult = tree.Remove(50);
            var count = tree.Count;

            //assert
            Assert.True(removeResult);
            Assert.False(tree.Contains(50));
            Assert.AreEqual(6, count);
        }

        [Test]
        public void TreeMax()
        {
            //arrange
            var tree = new BinaryTree<int>
            {
                2, 5, 1, 10, 8, 7, 9, 4, 3
            };

            //act
            var max = tree.TreeMax();

            //assert
            Assert.AreEqual(10, max);
        }

        [Test]
        public void TreeMaxEmptyTree()
        {
            var tree = new BinaryTree<int>();

            Assert.Throws(typeof(BinaryTreeEmptyTreeException), () => tree.TreeMax());
        }

        [Test]
        public void TreeMin()
        {
            //arrange
            var tree = new BinaryTree<int>
            {
                2, 5, 1, 10, 8, 7, 9, 4, 3
            };

            //act
            var min = tree.TreeMin();

            //assert
            Assert.AreEqual(1, min);
        }

        [Test]
        public void TreeMinEmptyTree()
        {
            var tree = new BinaryTree<int>();

            Assert.Throws(typeof(BinaryTreeEmptyTreeException), () => tree.TreeMin());
        }
    }
}