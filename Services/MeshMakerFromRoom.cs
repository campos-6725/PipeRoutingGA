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
        MeshMakerFromRoom(INodeFactory nodeFactory)
        {
            _nodeFactory = nodeFactory;
            _nodes = new List<Node>();
        }

        public List<Node> Ler(List<Face> faces)
        {


            foreach (Face face in faces)
            {
                // OBTER RETAS DE CONTORNO DA FACE

                foreach (var line in face.ContourLines)
                {
                    //obter lista de pontos de interesse para a linha (extremidades  )
                    //checar para cada reta se existem pontos terminais em outras faces adjacentes a ela


                }

            }


            throw new NotImplementedException();
        }



        private Line GetLateralLine()
        {

        }

        private List<XYZ> GetKeyPointsProjectedInLine(Line line, Face face)
        {
            List<XYZ> points = new List<XYZ>();
            points.Add(line.StartPoint);
            points.Add(line.EndPoint);

            points.AddRange(face.TerminalPoints.Select(p=>p.Coordinate));
            
                



            return new List<XYZ>();
        }

    }
}
