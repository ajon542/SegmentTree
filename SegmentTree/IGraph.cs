using System.Collections.Generic;

namespace SegmentTree
{
    /// <summary>
    /// Interface for a graph.
    /// </summary>
    /// <remarks>
    /// Nodes are referred to by identifiers. The contents of each node are of no interest.
    /// </remarks>
    public interface IGraph
    {
        /// <summary>
        /// Adds an edge between two nodes. The edge is directed from nodeId1 -> nodeId2.
        /// </summary>
        /// <param name="nodeId1">The edge start node.</param>
        /// <param name="nodeId2">The edge end node.</param>
        void AddEdge(int nodeId1, int nodeId2);

        /// <summary>
        /// Removes an edge between two nodes.
        /// </summary>
        /// <param name="nodeId1">The edge start node.</param>
        /// <param name="nodeId2">The edge end node.</param>
        void RemoveEdge(int nodeId1, int nodeId2);

        /// <summary>
        /// Checks if the given node is in the graph.
        /// </summary>
        /// <param name="nodeId">The node to check.</param>
        /// <returns>True if the node is in the graph, false otherwise.</returns>
        bool ContainsNode(int nodeId);

        /// <summary>
        /// Gets the neighbouring nodes.
        /// </summary>
        /// <param name="nodeId">The node for which to get the neighbours.</param>
        /// <returns>The list of neighbouring nodes, or null.</returns>
        List<int> GetNeighbours(int nodeId);
    }
}
