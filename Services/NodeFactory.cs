using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Services
{
    internal class NodeFactory : INodeFactory
    {
        public Node Make(int x, int y, int z)
        {
            return new Node(new XYZ(x,y,z));
        }
    }
}
