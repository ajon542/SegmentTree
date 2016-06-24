
namespace SegmentTree
{
    public class SegmentTree
    {
        private int[] leafNodes;
        private int[] tree;

        public void Build(int[] values)
        {
            leafNodes = values;

            // Calculate the space required to hold all the nodes in the tree.
            int nodeCount = 2 * NextPowerOfTwo(leafNodes.Length);
            tree = new int[nodeCount];

            int currentIndex = 1;
            tree[0] = -1;
            PlaceLeafNodes(0, leafNodes.Length - 1, currentIndex);

            // TODO: Build rest of the nodes.
        }

        private int NextPowerOfTwo(int n)
        {
            n -= 1;
            int shift = 1;
            while (((n + 1) & n) != 0) // n+1 is not a power of 2 yet
            {
                n |= n >> shift;
                shift <<= 1;
            }
            return n + 1;
        }

        private void PlaceLeafNodes(int l, int r, int childIndex)
        {
            if (l == r)
            {
                tree[childIndex] = leafNodes[l];
                return;
            }

            int m = (l + r) / 2;
            int lChildIndex = childIndex << 1;
            int rChildIndex = lChildIndex + 1;

            PlaceLeafNodes(l, m, lChildIndex);
            PlaceLeafNodes(m + 1, r, rChildIndex);
        }
    }
}
