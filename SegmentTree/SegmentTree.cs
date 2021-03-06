﻿using System;
using System.Collections.Generic;

namespace SegmentTree
{
    /// <summary>
    /// This segment tree implementation represents the sums of the child nodes.
    /// The leaf nodes are the original input values. This data structure allows
    /// for both update and query in O(logn) time.
    /// </summary>
    public class SegmentTree
    {
        private List<int> leafNodes;
        private RangeNode[] tree;

        /// <summary>
        /// Build the segment tree from the given nodes.
        /// </summary>
        /// <param name="nodes">The list of nodes.</param>
        public void Build(List<int> nodes)
        {
            leafNodes = nodes;

            // Calculate the space required to hold all the nodes in the tree.
            int nodeCount = 2 * NextPowerOfTwo(leafNodes.Count);
            tree = new RangeNode[nodeCount];
            for (int i = 0; i < nodeCount; ++i)
            {
                tree[i] = new RangeNode();
            }

            int currentIndex = 1;
            tree[0].Node.Value = -1;
            PlaceLeafNodes(0, leafNodes.Count - 1, currentIndex);
            UpdateInternalNodes();
        }

        /// <summary>
        /// Updates the node with the given value.
        /// </summary>
        /// <param name="node">The id of the node to update.</param>
        /// <param name="value">The new value for the node.</param>
        public void UpdateNode(int node, int value)
        {
            int rootNode = 1;
            UpdateNode(node, rootNode, value);
        }

        private void UpdateNode(int node, int currentNode, int value)
        {
            // Nothing to do if the current node is not part of the tree.
            if (currentNode < 0 || currentNode >= tree.Length)
            {
                return;
            }

            // If the given node is within the current node's range, update the value.
            if (tree[currentNode].Range.ContainsValue(node))
            {
                int diff = leafNodes[node] - value;
                tree[currentNode].Node.Value -= diff;
            }

            // Update the values of the child nodes.
            UpdateNode(node, Left(currentNode), value);
            UpdateNode(node, Right(currentNode), value);
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
        /// <param name="range">The range for the query.</param>
        public int QueryNodes(Range<int> range)
        {
            int rootNode = 1;
            return QueryNodes(rootNode, range);
        }

        private int QueryNodes(int node, Range<int> range)
        {
            // If the current node is inside the given range.
            if (tree[node].Range.IsInsideRange(range))
            {
                return tree[node].Node.Value;
            }
            // Else If the current node is completely outside the given range.
            else if (range.Maximum < tree[node].Range.Minimum || range.Minimum > tree[node].Range.Maximum)
            {
                return 0;
            }

            // Visit the left and right children.
            return QueryNodes(Left(node), range) + QueryNodes(Right(node), range);
        }

        private void PlaceLeafNodes(int l, int r, int node)
        {
            if (l == r)
            {
                // Add the leaf node into the tree.
                tree[node].Node.Value = leafNodes[l];
                tree[node].Range.Minimum = l;
                tree[node].Range.Maximum = r;
                return;
            }

            int m = (l + r) / 2;
            PlaceLeafNodes(l, m, Left(node));
            PlaceLeafNodes(m + 1, r, Right(node));
        }

        /// <summary>
        /// Updates all the internal nodes based on the leaf nodes.
        /// </summary>
        /// <remarks>
        /// Interesting thing about this method is that it will only work once.
        /// Initially, the internal nodes all have value 0. This is the identifier
        /// for being able to update those nodes to their correct value based on
        /// the leaf nodes.
        /// TODO:
        /// It would be nice to have a different indicator so this method
        /// can be more general and can be called at any time to recalculate the
        /// values in the segment tree.
        /// </remarks>
        private void UpdateInternalNodes()
        {
            for (int i = tree.Length - 1; i > 0; --i)
            {
                // Intially, the internal nodes have value zero.
                if (tree[i].Node.Value == 0)
                {
                    // Obtain the children nodes.
                    RangeNode lNode = LeftNode(i);
                    RangeNode rNode = RightNode(i);

                    // Update the current node based on the values of the children.
                    // The current node has a value which is the sum of the two children.
                    // The range of the parent node is the minimum of the left child and
                    // the maximum of the right child.
                    if (lNode != null)
                    {
                        tree[i].Node.Value += lNode.Node.Value;
                        tree[i].Range.Minimum = lNode.Range.Minimum;
                    }

                    if (rNode != null)
                    {
                        tree[i].Node.Value += rNode.Node.Value;
                        tree[i].Range.Maximum = rNode.Range.Maximum;
                    }
                }
            }
        }

        private int Parent(int node)
        {
            return node >> 1;
        }

        private int Left(int node)
        {
            return node << 1;
        }

        private int Right(int node)
        {
            return (node << 1) + 1;
        }

        /// <summary>
        /// Get the value of the left child node.
        /// </summary>
        /// <param name="node">The parent node.</param>
        /// <returns>The value of the left child node, or null if not in range.</returns>
        private RangeNode LeftNode(int node)
        {
            int childIndex = Left(node);
            if (childIndex < tree.Length)
            {
                return tree[childIndex];
            }
            return null;
        }

        /// <summary>
        /// Get the value of the right child node.
        /// </summary>
        /// <param name="node">The parent node.</param>
        /// <returns>The value of the right child node, or null if not in range.</returns>
        private RangeNode RightNode(int node)
        {
            int childIndex = Right(node);
            if (childIndex < tree.Length)
            {
                return tree[childIndex];
            }
            return null;
        }

        /// <summary>
        /// Obtains the next closest power of 2.
        /// </summary>
        /// <remarks>
        /// If the input is 6, the next closest power of 2 will be 8.
        /// If the input is 8, the next closest power of 2 will be 8.
        /// If the input is 8, the next closest power of 9 will be 16.
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
        /// <returns>The internal tree node values.</returns>
        public int[] GetTreeNodeValues()
        {
            int[] nodeValues = new int[tree.Length];
            for (int i = 0; i < tree.Length; ++i)
            {
                nodeValues[i] = tree[i].Node.Value;
            }
            return nodeValues;
        }

        /// <summary>
        /// This method is for unit testing only.
        /// </summary>
        /// <returns>The internal tree node ranges.</returns>
        public Range<int>[] GetTreeNodeRanges()
        {
            Range<int>[] nodeRanges = new Range<int>[tree.Length];
            for (int i = 0; i < tree.Length; ++i)
            {
                nodeRanges[i] = tree[i].Range;
            }
            return nodeRanges;
        }
    }
}
