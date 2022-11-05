using Entities;
using QuikGraph;
using System;
using System.Collections.Generic;
using System.Text;


namespace Interfaces
{
    public interface IMeshMaker
    {
        BidirectionalGraph<Node,Edge> Make(List<Face> paredes);
    }
}
