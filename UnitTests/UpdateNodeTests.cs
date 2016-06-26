using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SegmentTree;

namespace UnitTests
{
    [TestClass]
    public class UpdateNodeTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            SegmentTree.SegmentTree tree = new SegmentTree.SegmentTree();
            tree.Build(new List<int> { 1 });

            tree.UpdateNode(0, 10);

            int[] expected = { -1, 10 };
            int[] actual = tree.GetTreeNodeValues();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            SegmentTree.SegmentTree tree = new SegmentTree.SegmentTree();
            tree.Build(new List<int> { 1, 2 });

            tree.UpdateNode(0, 10);
            tree.UpdateNode(1, 20);

            int[] expected = { -1, 30, 10, 20 };
            int[] actual = tree.GetTreeNodeValues();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            SegmentTree.SegmentTree tree = new SegmentTree.SegmentTree();
            tree.Build(new List<int> { 1, 2, 3 });

            tree.UpdateNode(0, 10);
            tree.UpdateNode(1, 20);
            tree.UpdateNode(2, 30);

            int[] expected = { -1, 60, 30, 30, 10, 20, 0, 0 };
            int[] actual = tree.GetTreeNodeValues();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
