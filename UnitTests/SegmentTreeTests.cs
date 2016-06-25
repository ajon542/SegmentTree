using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SegmentTree;

namespace UnitTests
{
    [TestClass]
    public class SegmentTreeTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            SegmentTree.SegmentTree tree = new SegmentTree.SegmentTree();
            List<Node<int>> nodes = Converter.Convert(new List<int> { 1 });
            tree.Build(nodes);

            int[] expected = { -1, 1 };

            CollectionAssert.AreEqual(expected, tree.GetTreeNodeValues());
        }

        [TestMethod]
        public void TestMethod2()
        {
            SegmentTree.SegmentTree tree = new SegmentTree.SegmentTree();
            List<Node<int>> nodes = Converter.Convert(new List<int> { 1, 2 });
            tree.Build(nodes);

            int[] expected = { -1, 3, 1, 2 };

            CollectionAssert.AreEqual(expected, tree.GetTreeNodeValues());
        }

        [TestMethod]
        public void TestMethod3()
        {
            SegmentTree.SegmentTree tree = new SegmentTree.SegmentTree();
            List<Node<int>> nodes = Converter.Convert(new List<int> { 1, 2, 3 });
            tree.Build(nodes);

            int[] expected = { -1, 6, 3, 3, 1, 2, 0, 0 };

            CollectionAssert.AreEqual(expected, tree.GetTreeNodeValues());
        }

        [TestMethod]
        public void TestMethod4()
        {
            SegmentTree.SegmentTree tree = new SegmentTree.SegmentTree();
            List<Node<int>> nodes = Converter.Convert(new List<int> { 1, 2, 3, 4 });
            tree.Build(nodes);

            int[] expected = { -1, 10, 3, 7, 1, 2, 3, 4 };

            CollectionAssert.AreEqual(expected, tree.GetTreeNodeValues());
        }

        [TestMethod]
        public void TestMethod5()
        {
            SegmentTree.SegmentTree tree = new SegmentTree.SegmentTree();
            List<Node<int>> nodes = Converter.Convert(new List<int> { 1, 2, 3, 4, 5 });
            tree.Build(nodes);

            int[] expected = { -1, 15, 6, 9, 3, 3, 4, 5, 1, 2, 0, 0, 0, 0, 0, 0 };

            CollectionAssert.AreEqual(expected, tree.GetTreeNodeValues());
        }

        [TestMethod]
        public void TestMethod6()
        {
            SegmentTree.SegmentTree tree = new SegmentTree.SegmentTree();
            List<Node<int>> nodes = Converter.Convert(new List<int> { 1, 2, 3, 4, 5, 6 });
            tree.Build(nodes);

            int[] expected = { -1, 21, 6, 15, 3, 3, 9, 6, 1, 2, 0, 0, 4, 5, 0, 0 };

            CollectionAssert.AreEqual(expected, tree.GetTreeNodeValues());
        }

        [TestMethod]
        public void TestMethod7()
        {
            SegmentTree.SegmentTree tree = new SegmentTree.SegmentTree();
            List<Node<int>> nodes = Converter.Convert(new List<int> { 1, 2, 3, 4, 5, 6, 7 });
            tree.Build(nodes);

            int[] expected = { -1, 28, 10, 18, 3, 7, 11, 7, 1, 2, 3, 4, 5, 6, 0, 0 };

            CollectionAssert.AreEqual(expected, tree.GetTreeNodeValues());
        }
    }
}
