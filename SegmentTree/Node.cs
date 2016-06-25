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
        public override string ToString() { return String.Format("[{0}: {1}]", Id, Value); }
    }
}
