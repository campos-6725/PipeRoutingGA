
using Definitions;
using Entities.Exceptions;
using Entities.GA;
using Entities.Genes;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.Exceptions
{
    public class RoomMapper : IRoomMapper
    {
        private Room _room;
        private PathChromossome _pathChromossome;


       
   



        public void MapRoom(Room room, PathChromossome pathChromossome)
        {
            _room = room;
            _pathChromossome = pathChromossome;

            IdentifyMainFace();
            IdentifyFaceAdjacency();

            IdentifyGenesRelatedToEachFace();
        }

        private void IdentifyGenesRelatedToEachFace()
        {
            Dictionary<Face, List<Gene>> genePerFace = new Dictionary<Face, List<Gene>>();
            foreach (Face face in _room.Faces)
            {
                List<Gene> genesRelatedToThisFace = _pathChromossome.Genes.Where(g => g.SourceFace == face).ToList();

                genePerFace.Add(face, genesRelatedToThisFace);
            }

            _room.GenesPerFace = genePerFace;
            throw new NotImplementedException();
        }



        private void IdentifyFaceAdjacency()
        {
            var thisRoomFaces = _room.Faces.ToList();
            Dictionary<Face, Dictionary<FaceDirection, Face>> faceAdjecentToThis = new Dictionary<Face, Dictionary<FaceDirection, Face>>();

            foreach (var thisFace in thisRoomFaces)
            {
                var facesThatShareASideWhithThis = thisRoomFaces.Where(f => thisFace.ShareSideWhith(f)).ToList();
                var faceAtDirection = new Dictionary<FaceDirection, Face>();

                foreach (var f in facesThatShareASideWhithThis)
                {

                    if (thisFace.Normal.CrossProduct(f.Normal).Equals(XYZ.BasisZ))
                    {
                        faceAtDirection.Add(FaceDirection.left, f);
                    }
                    else if (thisFace.Normal.CrossProduct(f.Normal).Equals(-XYZ.BasisZ))
                    {
                        faceAtDirection.Add(FaceDirection.right, f);
                    }
                    else if (thisFace.Normal.CrossProduct(f.Normal).Equals(XYZ.Origin))
                    {
                        continue;
                    }
                    faceAtDirection.Add(FaceDirection.down, f);
                }
                faceAdjecentToThis.Add(thisFace, faceAtDirection);

            }
            _room.FaceAdjecentToThis = faceAdjecentToThis;
        }

    
        private void IdentifyMainFace()
        {
            //pego faces possiveis de serem a face principal
            IEnumerable<Face> faceWithSourcePoint = _room.Faces.Where(f => f.TerminalPoints.Where(p => p.Type == PointType.Source).Count() == 1);
            //pega face principal validando se ha apenas um candidato
            _room.MainFace = faceWithSourcePoint.Count() == 1 ? faceWithSourcePoint.FirstOrDefault() : throw new ArgumentException();
        }

        

    }
}
