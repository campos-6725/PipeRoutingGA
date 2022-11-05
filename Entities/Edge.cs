using System;
using System.Collections.Generic;
using System.Text;
using QuikGraph;

namespace Entities
{
    public class Edge : IEdge<Node>
    {
        public Node Source { get; set; }
        public Node Target { get; set; }
        double Weight { get; set; }

        public Edge(Node source, Node target)
        {
            Source = source;
            Target = target;
            Weight = source.Coordinate.DistanceTo(target.Coordinate);
        }






    }
}
