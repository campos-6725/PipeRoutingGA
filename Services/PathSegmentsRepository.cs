using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class PathSegmentsRepository 
    {
        List<Edge> Edges { get; set; }
        List<Node> Nodes { get; set; }

        Dictionary<Node,List<Edge>> EdgesForEachNode { get; set; }

        PathSegmentsRepository()
        {
            Edges = new List<Edge>();   
            Nodes = new List<Node>();
            EdgesForEachNode = new Dictionary<Node,List<Edge>>();
        }

        public void AddEdge(Edge edge)
        {
            if (Edges.Contains(edge))
                return;
            Edges.Add(edge);
            AddNode(edge.Source);
            AddNode(edge.Target);
            AddToNodeDictionary(edge);
        }

        private void AddNode(Node node)
        {
            if (Nodes.Contains(node))
                return;
            Nodes.Add(node);
        }

        private void AddToNodeDictionary(Edge edge)
        {
            if(EdgesForEachNode.ContainsKey(edge.Source))
                EdgesForEachNode[edge.Source].Add(edge);
            else
                EdgesForEachNode[edge.Source] = new List<Edge>() { edge};

            if (EdgesForEachNode.ContainsKey(edge.Target))
                EdgesForEachNode[edge.Target].Add(edge);
            else
                EdgesForEachNode[edge.Target] = new List<Edge>() { edge };

        }

    }
}
