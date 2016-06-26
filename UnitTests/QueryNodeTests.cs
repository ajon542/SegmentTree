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
    }
}
