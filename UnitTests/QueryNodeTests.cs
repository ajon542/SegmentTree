using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SegmentTree;

namespace UnitTests
{
    [TestClass]
    public class QueryNodeTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            SegmentTree.SegmentTree tree = new SegmentTree.SegmentTree();
            tree.Build(new List<int> { 1 });

            Assert.AreEqual(1, tree.QueryNodes(new Range<int>(0, 0)));
        }

        [TestMethod]
        public void TestMethod2()
        {
            SegmentTree.SegmentTree tree = new SegmentTree.SegmentTree();
            tree.Build(new List<int> { 1, 2 });

            Assert.AreEqual(3, tree.QueryNodes(new Range<int>(0, 1)));
            Assert.AreEqual(1, tree.QueryNodes(new Range<int>(0, 0)));
            Assert.AreEqual(2, tree.QueryNodes(new Range<int>(1, 1)));
        }

        [TestMethod]
        public void TestMethod3()
        {
            SegmentTree.SegmentTree tree = new SegmentTree.SegmentTree();
            tree.Build(new List<int> { 1, 3, 5, 7, 9, 11 });

            Assert.AreEqual(36, tree.QueryNodes(new Range<int>(0, 6)));
            Assert.AreEqual(9, tree.QueryNodes(new Range<int>(0, 2)));
            Assert.AreEqual(27, tree.QueryNodes(new Range<int>(3, 5)));
            Assert.AreEqual(4, tree.QueryNodes(new Range<int>(0, 1)));
            Assert.AreEqual(5, tree.QueryNodes(new Range<int>(2, 2)));
            Assert.AreEqual(1, tree.QueryNodes(new Range<int>(0, 0)));
            Assert.AreEqual(3, tree.QueryNodes(new Range<int>(1, 1)));
            Assert.AreEqual(16, tree.QueryNodes(new Range<int>(3, 4)));
            Assert.AreEqual(11, tree.QueryNodes(new Range<int>(5, 5)));
            Assert.AreEqual(7, tree.QueryNodes(new Range<int>(3, 3)));
            Assert.AreEqual(9, tree.QueryNodes(new Range<int>(4, 4)));
        }
    }
}
