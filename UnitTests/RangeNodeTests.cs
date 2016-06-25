using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SegmentTree;

namespace UnitTests
{
    [TestClass]
    public class RangeNodeTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            SegmentTree.SegmentTree tree = new SegmentTree.SegmentTree();
            List<Node<int>> nodes = Converter.Convert(new List<int> { 1 });
            tree.Build(nodes);

            Range<int>[] expected =
            {
                new Range<int>(0, 0), // -1
                new Range<int>(0, 0), //  1
            };

            Range<int>[] actual = tree.GetTreeNodeRanges();

            AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            SegmentTree.SegmentTree tree = new SegmentTree.SegmentTree();
            List<Node<int>> nodes = Converter.Convert(new List<int> { 1, 2 });
            tree.Build(nodes);

            Range<int>[] expected = 
            {
                new Range<int>(0, 0), // -1
                new Range<int>(0, 1), //  3
                new Range<int>(0, 0), //  1
                new Range<int>(1, 1), //  2
            };

            Range<int>[] actual = tree.GetTreeNodeRanges();

            AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            SegmentTree.SegmentTree tree = new SegmentTree.SegmentTree();
            List<Node<int>> nodes = Converter.Convert(new List<int> { 1, 2, 3 });
            tree.Build(nodes);

            Range<int>[] expected = 
            {
                new Range<int>(0, 0), // -1
                new Range<int>(0, 2), //  6
                new Range<int>(0, 1), //  3
                new Range<int>(2, 2), //  3
                new Range<int>(0, 0), //  1
                new Range<int>(1, 1), //  2
                new Range<int>(0, 0), //  0
                new Range<int>(0, 0), //  0
            };

            Range<int>[] actual = tree.GetTreeNodeRanges();

            AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod4()
        {
            SegmentTree.SegmentTree tree = new SegmentTree.SegmentTree();
            List<Node<int>> nodes = Converter.Convert(new List<int> { 1, 2, 3, 4 });
            tree.Build(nodes);

            Range<int>[] expected = 
            {
                new Range<int>(0, 0), // -1
                new Range<int>(0, 3), // 10
                new Range<int>(0, 1), //  3
                new Range<int>(2, 3), //  7
                new Range<int>(0, 0), //  1
                new Range<int>(1, 1), //  2
                new Range<int>(2, 2), //  3
                new Range<int>(3, 3), //  4
            };

            Range<int>[] actual = tree.GetTreeNodeRanges();

            AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod5()
        {
            SegmentTree.SegmentTree tree = new SegmentTree.SegmentTree();
            List<Node<int>> nodes = Converter.Convert(new List<int> { 1, 2, 3, 4, 5 });
            tree.Build(nodes);

            Range<int>[] expected = 
            {
                new Range<int>(0, 0), // -1
                new Range<int>(0, 4), // 15
                new Range<int>(0, 2), //  6
                new Range<int>(3, 4), //  9
                new Range<int>(0, 1), //  3
                new Range<int>(2, 2), //  3
                new Range<int>(3, 3), //  4
                new Range<int>(4, 4), //  5
                new Range<int>(0, 0), //  1
                new Range<int>(1, 1), //  2
                new Range<int>(0, 0),
                new Range<int>(0, 0),
                new Range<int>(0, 0),
                new Range<int>(0, 0),
                new Range<int>(0, 0),
                new Range<int>(0, 0),
            };

            Range<int>[] actual = tree.GetTreeNodeRanges();

            AreEqual(expected, actual);
        }

        private void AreEqual(Range<int>[] expected, Range<int>[] actual)
        {
            Assert.AreEqual(expected.Length, actual.Length);

            for (int i = 0; i < expected.Length; ++i)
            {
                Assert.AreEqual(expected[i].Minimum, actual[i].Minimum);
                Assert.AreEqual(expected[i].Maximum, actual[i].Maximum);
            }
        }
    }
}
