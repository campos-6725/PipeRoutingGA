using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface INodeFactory
    {
        Node Make(int x,int y, int z);
    }
}
