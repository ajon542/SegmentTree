using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SegmentTree;

namespace UnitTests
{
    [TestClass]
    public class RangeTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Range<int> range = new Range<int> { Minimum = 0, Maximum = 1 };
            Assert.IsTrue(range.IsValid());
        }

        [TestMethod]
        public void TestMethod2()
        {
            Range<int> range = new Range<int> { Minimum = 0, Maximum = 0 };
            Assert.IsTrue(range.IsValid());
        }

        [TestMethod]
        public void TestMethod3()
        {
            Range<int> range = new Range<int> { Minimum = 1, Maximum = 0 };
            Assert.IsFalse(range.IsValid());
        }

        [TestMethod]
        public void TestMethod4()
        {
            Range<int> range1 = new Range<int> { Minimum = 0, Maximum = 1 };
            Range<int> range2 = new Range<int> { Minimum = 0, Maximum = 1 };
            Assert.IsTrue(range1.IsInsideRange(range2));
        }

        [TestMethod]
        public void TestMethod5()
        {
            Range<int> range1 = new Range<int> { Minimum = 0, Maximum = 1 };
            Range<int> range2 = new Range<int> { Minimum = 0, Maximum = 0 };
            Assert.IsFalse(range1.IsInsideRange(range2));
        }

        [TestMethod]
        public void TestMethod6()
        {
            Range<int> range1 = new Range<int> { Minimum = 0, Maximum = 1 };
            Range<int> range2 = new Range<int> { Minimum = 0, Maximum = 2 };
            Assert.IsTrue(range1.IsInsideRange(range2));
        }
    }
}
