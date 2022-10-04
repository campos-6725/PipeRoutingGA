using Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace Interfaces
{
    public interface IMeshMaker
    {
        List<Node> Ler(List<Face> paredes);
    }
}
