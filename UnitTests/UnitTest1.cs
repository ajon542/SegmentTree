using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            SegmentTree.SegmentTree tree = new SegmentTree.SegmentTree();
            tree.Build(new int[] { 1 });

            int[] expected = { -1, 1 };

            CollectionAssert.AreEqual(expected, tree.GetTree());
        }

        [TestMethod]
        public void TestMethod2()
        {
            SegmentTree.SegmentTree tree = new SegmentTree.SegmentTree();
            tree.Build(new int[] { 1, 2 });

            int[] expected = { -1, 3, 1, 2 };

            CollectionAssert.AreEqual(expected, tree.GetTree());
        }

        [TestMethod]
        public void TestMethod3()
        {
            SegmentTree.SegmentTree tree = new SegmentTree.SegmentTree();
            tree.Build(new int[] { 1, 2, 3 });

            int[] expected = { -1, 6, 3, 3, 1, 2, 0, 0 };

            CollectionAssert.AreEqual(expected, tree.GetTree());
        }

        [TestMethod]
        public void TestMethod4()
        {
            SegmentTree.SegmentTree tree = new SegmentTree.SegmentTree();
            tree.Build(new int[] { 1, 2, 3, 4 });

            int[] expected = { -1, 10, 3, 7, 1, 2, 3, 4 };

            CollectionAssert.AreEqual(expected, tree.GetTree());
        }
    }
}
