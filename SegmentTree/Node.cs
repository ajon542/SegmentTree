using System;

namespace SegmentTree
{
    /// <summary>
    /// This represents a node.
    /// </summary>
    /// <typeparam name="T">The type of the value the node contains.</typeparam>
    public class Node<T>
    {
        /// <summary>
        /// The node identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The value of the node.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Presents the Node in readable format
        /// </summary>
        /// <returns>String representation of the Range</returns>
        public override string ToString() { return String.Format("[{0}]", Value); }
    }

    /// <summary>
    /// Internal node representation.
    /// </summary>
    public class RangeNode
    {
        /// <summary>
        /// The node.
        /// </summary>
        public Node<int> Node { get; set; }

        /// <summary>
        /// Each node in the tree contains a range which is used in a query.
        /// </summary>
        public Range<int> Range { get; set; }

        public RangeNode()
        {
            Node = new Node<int>();
            Range = new Range<int>(-1, -1);
        }

        /// <summary>
        /// Presents the Range in readable format
        /// </summary>
        /// <returns>String representation of the Range</returns>
        public override string ToString()
        {
            return String.Format("{0}: {1}",
                (Node == null) ? "null" : Node.ToString(),
                (Range == null) ? "null" : Range.ToString());
        }
    }
}
