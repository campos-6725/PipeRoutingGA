using Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace Interfaces
{
    public interface ILeitorDeEspacos
    {
        List<Node> Ler(List<Face> paredes);
    }
}
