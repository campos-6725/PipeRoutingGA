using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Node
    {

        public XYZ Coordinate { get; set; }
        public int Id {get;set;}

        public Node(XYZ xyz)
        {
            Coordinate = xyz;
            Id = this.GetHashCode();
        }

    }
}
