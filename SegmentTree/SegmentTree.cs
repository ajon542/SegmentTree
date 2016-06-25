using System;

namespace SegmentTree
{
    /// <summary>
    /// This represents a node. The user will supply a list of nodes
    /// from which the segment tree is to be built.
    /// </summary>
    public class Node
    {
        /// <summary>
        /// The node identifier.
        /// </summary>
        /// <remarks>
        /// The user should ensure these values are unique.
        /// </remarks>
        public int Id { get; set; }

        /// <summary>
        /// The value of the node.
        /// </summary>
        public int Value { get; set; }
    }

    /// <summary>
    /// This segment tree implementation represents the sums of the child nodes.
    /// The leaf nodes are the original input values. This data structure allows
    /// for both update and query in O(logn) time.
    /// </summary>
    public class SegmentTree
    {
        /// <summary>
        /// Internal node representation.
        /// </summary>
        private class RangeNode
        {
            /// <summary>
            /// The node.
            /// </summary>
            public Node Node { get; set; }

            /// <summary>
            /// Each node in the tree contains a range which is used in a query.
            /// </summary>
            public Range<int> Range { get; set; }
        }

        private int[] leafNodes;
        private int[] tree;

        public void Build(int[] values)
        {
            // Requuirements:
            // 1. The user must provide an identifier for the node.
            // 2. The user must provide the identifier when doing an update or query for nodes.

            leafNodes = values;

            // Calculate the space required to hold all the nodes in the tree.
            int nodeCount = 2 * NextPowerOfTwo(leafNodes.Length);
            tree = new int[nodeCount];

            int currentIndex = 1;
            tree[0] = -1;
            PlaceLeafNodes(0, leafNodes.Length - 1, currentIndex);
            UpdateInternalNodes();
        }

        /// <summary>
        /// Updates the node with the given value.
        /// </summary>
        /// <param name="id">The id of the node to update.</param>
        /// <param name="value">The new value for the node.</param>
        public void UpdateNode(int id, int value)
        {
            // Requirements:
            // 1. The node must be accessible in constant time.
            // 2. Must be able to determine the parent of any given node.
            //
            // An interesting thing is the id given to the node. Externally,
            // the user knows nothing about the id as it only passes in the
            // different nodes. How can we propagate this information?
            // We could make the rule such that the calling class should create
            // the ids. If they don't do this, we must at least give them back
            // some sort of id for them to use.
            throw new NotImplementedException();
        }

        /// <summary>
        /// You are given an input array of values and the task
        /// is to find the sum of the values between any given indices.
        /// For example, the input array could be [1, 2, 3, 4, 5, 6, 7, 8]
        /// and you are asked to find the sum between the indices 1 and 5.
        /// The correct answer is (2 + 3 + 4 + 5 + 6) = 20. In the naive
        /// approach you can simply iterate through all the values and obtain
        /// the sum in O(n). However, the better approach is to use the
        /// segment tree data structure which can perform in O(logn) time.
        /// </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        public void QueryNodes(int node1, int node2)
        {
            throw new NotImplementedException();
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
