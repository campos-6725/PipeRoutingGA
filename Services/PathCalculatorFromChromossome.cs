using Entities;
using Entities.GA;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class PathCalculatorFromChromossome
    {
        private PathChromossome _pathChromossome;

        public PathCalculatorFromChromossome(Room room)
        {
       
        }

        public List<Edge> GetFace(PathChromossome pathChromossome)
        {
            _pathChromossome = pathChromossome;
            ReadPathFromMainFace();

        }

     

        private void ReadPathFromMainFace()
        {
            throw new NotImplementedException();
        }

        private void ReadPathForOtherFaces()
        {

        }

        private void ReadPathForFloor() 
        {

        }


    }
}
