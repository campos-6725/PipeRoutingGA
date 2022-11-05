using Entities;
using QuikGraph;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IBiderectionalGraphCreator
    {
        BidirectionalGraph<Node, Edge> Create(List<Node> nodes, List<Edge> edges);
    }
}
