using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using QuikGraph;

namespace Services
{
    public class GraphRepository : IRepository<BidirectionalGraph<Node, Edge>>
    {
        public BidirectionalGraph<Node, Edge> BidirectionalGraph { get; set; }

        public BidirectionalGraph<Node, Edge> Get()
        {
           return BidirectionalGraph;   
        }
        void IRepository<BidirectionalGraph<Node, Edge>>.Store(BidirectionalGraph<Node, Edge> graph)
        {
            BidirectionalGraph = graph;
        }
    }
}
