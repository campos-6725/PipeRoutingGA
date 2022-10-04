using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Interfaces;

namespace Services
{
    public class LeitorDeEspaco3D : ILeitorDeEspacos
    {
        private List<Node> _nodes;
        private INodeFactory _nodeFactory;
        LeitorDeEspaco3D(INodeFactory nodeFactory)
        {
            _nodeFactory = nodeFactory;
            _nodes = new List<Node>();
        }

        public List<Node> Ler(List<Face> faces)
        {                     


            foreach(Face face in faces)
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



        private void DecompoeParedeEmConjuntoDeNos(Face face)
        {

            for(int x= (int)face.Min.X; x<= (int)face.Max.X; x++)
            {
                for(int y = (int)face.Min.Y; y<= (int)face.Max.Y; y++)
                {
                    for (int z= (int)face.Min.Z; z< (int)face.Max.Z; z++)
                    {
                        _nodes.Add(_nodeFactory.Make(x, y, z));
                    }
                }
            }


        }


    }
}
