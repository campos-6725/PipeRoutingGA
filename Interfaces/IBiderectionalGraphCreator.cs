using Entities;
using QuikGraph;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IBiderectionalGraphCreator
    {
        BidirectionalGraph<Node, Edge> Create(List<Node> nodes, List<Edge> edges);
    }
}
