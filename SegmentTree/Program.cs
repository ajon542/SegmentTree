
namespace SegmentTree
{
    class Program
    {
        static void Main(string[] args)
        {
            SegmentTree tree = new SegmentTree();
            tree.Build(new int[] { 1, 3, 5, 1, 2, 3, 3, 5, 6 });
        }
    }
}
