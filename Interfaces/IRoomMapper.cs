using Entities;
using Entities.GA;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IRoomMapper
    {         
        void MapRoom(Room room, PathChromossome pathChromossome);
    }
}
