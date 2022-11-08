using System;
using System.Collections.Generic;
using System.Text;
using QuikGraph;

namespace Entities
{
    public class Node : IEquatable<Node>
    {

        public XYZ Coordinate { get; set; }
        public int Id { get; set; }

        public Node(XYZ xyz)
        {
            Coordinate = xyz;
            Id = this.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            return base.Equals(obj as Node);
        }
        public bool Equals(Node other)
        {
            if (this.Coordinate == other.Coordinate)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
           int hashCode= Coordinate.GetHashCode() + 123456;
            return hashCode;
        }
    }
}
