using QuikGraph;
using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Services
{
    public class BiderectionalGraphCreator : IBiderectionalGraphCreator
    {
        public BidirectionalGraph<Node, Edge> Create(List<Node> nodes, List<Edge> edges)
        {
            var graph = new BidirectionalGraph<Node, Edge>();
            graph.AddVertexRange(nodes);
            graph.AddEdgeRange(edges);

            return graph;
        }
    }
}
