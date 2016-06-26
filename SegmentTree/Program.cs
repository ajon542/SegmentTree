using System.Collections.Generic;

namespace SegmentTree
{
    class Program
    {
        static void Main(string[] args)
        {
            SegmentTree tree = new SegmentTree();

            List<Node<int>> nodes = Converter.Convert(new List<int> { 1, 3, 5, 7, 9, 11 });

            tree.Build(nodes);

            int sum;
            sum = tree.QueryNodes(1, 0, 6); // 36
            sum = tree.QueryNodes(1, 0, 2); // 9
            sum = tree.QueryNodes(1, 3, 5); // 27
            sum = tree.QueryNodes(1, 0, 1); // 4
            sum = tree.QueryNodes(1, 2, 2); // 5
            sum = tree.QueryNodes(1, 0, 0); // 1
            sum = tree.QueryNodes(1, 1, 1); // 3
            sum = tree.QueryNodes(1, 3, 4); // 16
            sum = tree.QueryNodes(1, 5, 5); // 11
            sum = tree.QueryNodes(1, 3, 3); // 7
            sum = tree.QueryNodes(1, 4, 4); // 9
        }
    }
}
