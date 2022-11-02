using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using Interfaces;

namespace Services
{
    public class MeshMakerFromRoom : IMeshMaker
    {
        private List<Node> _nodes;
        private INodeFactory _nodeFactory;
        private List<Face> _faces;
        MeshMakerFromRoom(INodeFactory nodeFactory)
        {
            _nodeFactory = nodeFactory;
            _nodes = new List<Node>();
        }

        public List<Node> Ler(List<Face> faces)
        {
            _faces = faces;

            foreach (Face face in faces)
            {                
                foreach (var line in face.ContourLines)
                {
                    //obter lista de pontos de interesse para a linha (extremidades)
                    //checar para cada reta se existem pontos terminais em outras faces adjacentes a ela


                }
                  
            }


            throw new NotImplementedException();
        }



        private Line GetLateralLine()
        {
            throw new NotImplementedException();
        }

        private List<XYZ> GetKeyPointsProjectedInLine(Line line, Face face)
        {
            List<XYZ> points = new List<XYZ>();
            List<XYZ> pointsProjected = new List<XYZ>();
            points.Add(line.StartPoint);
            points.Add(line.EndPoint);

            points.AddRange(face.TerminalPoints.Select(p=>p.Coordinate));
            
            points.AddRange(GetPointsInOtherFaces(_faces));    



            return points;
        }

        private List<XYZ> GetPointsInOtherFaces(List<Face> faces)
        {
            List<XYZ> terminalPoints = new List<XYZ>();
            foreach (Face f in faces)
            {
                terminalPoints.AddRange(f.TerminalPoints.Select(s => s.Coordinate));
            }      
            return terminalPoints;  
        }



    }
}
