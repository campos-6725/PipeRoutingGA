using Definitions;
using Entities.Exceptions;
using Entities.Genes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Room
    {

        public List<Face> Faces { get; set; }
        public bool IsStructuralBuilding { get; set; }
        public Face MainFace { get; set; }
        public Dictionary<Face, List<Gene>> GenesPerFace { get; set; }
        public Dictionary<Face, Dictionary<FaceDirection, Face>> FaceAdjecentToThis { get; set; }




        public Room(List<Face> faces, bool isStructuralBuilding)
        {
            this.Faces = faces;
            IsStructuralBuilding = isStructuralBuilding;
        }


        public Face GetFacesAtDirection(FaceDirection direction, Face thisFace)
        {
            return FaceAdjecentToThis[thisFace][direction];
        }

        public List<Gene> GetGenesFrom(Face face)
        {
            try
            {
                return GenesPerFace[face];
            }
            catch
            {
                throw new PropertyNotMapped();
            }
        }

    }
}
