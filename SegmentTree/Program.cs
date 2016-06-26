using System.Collections.Generic;

namespace SegmentTree
{
    class Program
    {
        static void Main(string[] args)
        {
            SegmentTree tree = new SegmentTree();

            tree.Build(new List<int> { 1, 3, 5, 7, 9, 11 });

            int sum;
            sum = tree.QueryNodes(new Range<int>(0, 6)); // 36
            sum = tree.QueryNodes(new Range<int>(0, 2)); // 9
            sum = tree.QueryNodes(new Range<int>(3, 5)); // 27
            sum = tree.QueryNodes(new Range<int>(0, 1)); // 4
            sum = tree.QueryNodes(new Range<int>(2, 2)); // 5
            sum = tree.QueryNodes(new Range<int>(0, 0)); // 1
            sum = tree.QueryNodes(new Range<int>(1, 1)); // 3
            sum = tree.QueryNodes(new Range<int>(3, 4)); // 16
            sum = tree.QueryNodes(new Range<int>(5, 5)); // 11
            sum = tree.QueryNodes(new Range<int>(3, 3)); // 7
            sum = tree.QueryNodes(new Range<int>(4, 4)); // 9
        }
    }
}
