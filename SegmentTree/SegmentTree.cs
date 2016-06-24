using System;

namespace SegmentTree
{
    public class Node
    {
        public int value;
        public Range<int> range;
    }

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
            UpdateInternalNodes();
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

        /// <summary>
        /// Calculates the parent node value.
        /// The parent node value is the sum of the two child nodes.
        /// </summary>
        private void UpdateInternalNodes()
        {
            for (int i = tree.Length - 1; i > 0; --i)
            {
                if (tree[i] == 0)
                {
                    tree[i] += Left(i);
                    tree[i] += Right(i);
                }
            }
        }

        /// <summary>
        /// Get the value of the left child node.
        /// </summary>
        /// <param name="node">The parent node.</param>
        /// <returns>The value of the left child node, or zero if not in range.</returns>
        private int Left(int node)
        {
            int childIndex = node << 1;
            if (childIndex < tree.Length)
            {
                return tree[childIndex];
            }
            return 0;
        }

        /// <summary>
        /// Get the value of the right child node.
        /// </summary>
        /// <param name="node">The parent node.</param>
        /// <returns>The value of the right child node, or zero if not in range.</returns>
        private int Right(int node)
        {
            int childIndex = (node << 1) + 1;
            if (childIndex < tree.Length)
            {
                return tree[childIndex];
            }
            return 0;
        }

        /// <summary>
        /// Obtains the next closest power of 2.
        /// </summary>
        /// <remarks>
        /// If the input is 6, the next closest power of 2 will be 8.
        /// If the input is 8, the next closest power of 2 will be 8.
        /// </remarks>
        /// <param name="n">The input value.</param>
        /// <returns>The next closest power of 2.</returns>
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

        /// <summary>
        /// This method is for unit testing only.
        /// </summary>
        /// <returns>The internal tree structure.</returns>
        public int[] GetTree()
        {
            return tree;
        }
    }
}
