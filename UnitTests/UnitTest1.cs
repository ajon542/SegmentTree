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

        [TestMethod]
        public void TestMethod5()
        {
            SegmentTree.SegmentTree tree = new SegmentTree.SegmentTree();
            tree.Build(new int[] { 1, 2, 3, 4, 5 });

            int[] expected = { -1, 15, 6, 9, 3, 3, 4, 5, 1, 2, 0, 0, 0, 0, 0, 0 };

            CollectionAssert.AreEqual(expected, tree.GetTree());
        }

        [TestMethod]
        public void TestMethod6()
        {
            SegmentTree.SegmentTree tree = new SegmentTree.SegmentTree();
            tree.Build(new int[] { 1, 2, 3, 4, 5, 6 });

            int[] expected = { -1, 21, 6, 15, 3, 3, 9, 6, 1, 2, 0, 0, 4, 5, 0, 0 };

            CollectionAssert.AreEqual(expected, tree.GetTree());
        }

        [TestMethod]
        public void TestMethod7()
        {
            SegmentTree.SegmentTree tree = new SegmentTree.SegmentTree();
            tree.Build(new int[] { 1, 2, 3, 4, 5, 6, 7 });

            int[] expected = { -1, 28, 10, 18, 3, 7, 11, 7, 1, 2, 3, 4, 5, 6, 0, 0 };

            CollectionAssert.AreEqual(expected, tree.GetTree());
        }
    }
}
