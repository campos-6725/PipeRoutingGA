using Definitions;
using Entities;
using Entities.GA;
using Entities.Genes;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading;

namespace Services
{
    public class PathCalculatorFromChromossome
    {
        private PathChromossome _pathChromossome;
        private Room _room;
        private double _distributionHeight;


        public PathCalculatorFromChromossome(Room room)
        {
            _room = room;
        }

        public void GetFace(PathChromossome pathChromossome)
        {
            _pathChromossome = pathChromossome;
            ReadPathFromMainFace();
            ReadPathForOtherFaces();
            ReadPathForFloor();
        }



        private void ReadPathFromMainFace()
        {
            ReadHorizontalLineHeight();

            List<XYZ> pointsInFace = IdentifyPointsInFace(_room.MainFace);
            XYZ firstPoint = pointsInFace.OrderBy(p => p.DotProduct(_room.MainFace.SideDirection)).FirstOrDefault();
            XYZ lastPoint = pointsInFace.OrderBy(p => p.DotProduct(_room.MainFace.SideDirection)).LastOrDefault();

            Line horizontalLine = new Line(firstPoint, lastPoint);

            

            //pega pontos de extremidade dentre os pontos da parede
            //cria reta a partir dos pontos e altura de distribuição
            //pega reta criada e cria segmentos partindo dos pontos na face ate suas projeções na reta
            //cria cada segmento de reta com cada ponto projetado na reta

            //adiciona nós e segmentos na estrutura de grafo



            throw new NotImplementedException();
        }

      

        private List<XYZ> IdentifyPointsInFace(Face face)
        {
            List<XYZ> pointsInFace = new List<XYZ>();
            pointsInFace.AddRange(face.TerminalPoints.Select(p => p.Coordinate));
            pointsInFace.AddRange(ReadDivePointsInFace(face));
            pointsInFace.AddRange(ReadSidePointsInFAce(face));

            throw new NotImplementedException();
        }

        private List<XYZ> ReadSidePointsInFAce(Face face)
        {
            //identifica se a parede tem alguma parede a esquerda tem cromossomo de pathDirection para a direita
            //ou a direita que tem cromossomo de pathdirection indicando a esquerda
            //caso tiver adicionar o ponto que a parede divide com a outra aos pontos de interesse e retornar
            


            throw new NotImplementedException();
        }

        private List<XYZ> ReadDivePointsInFace(Face face)
        {
            List<DiveDistanceFromSource> diveDistances;
            List<XYZ> divePointsInFace = new List<XYZ>();

            if (face == _room.MainFace)
            {
                diveDistances = GetDiveGenesFromThisAndOposingFace(face);
            }
            else
            {
                diveDistances = GetDiveGenesFromThisFace(face);
            }
            var points = diveDistances.Select(d => d.GetDivePointOnFloor());

            foreach (var point in points)
            {
                var pt = ProjectPointOnFaceAtFloorHeight(point, face);
                if (pt != null)
                    divePointsInFace.Add(pt);
            }
            return divePointsInFace;
        }

        private List<DiveDistanceFromSource> GetDiveGenesFromThisAndOposingFace(Face face)
        {
            return _pathChromossome.Genes
                 .Where(g =>
                 g.Type == GeneType.DistanceToDive &&
                 (g.SourceFace.Normal.IsSameDirection(face.Normal) || g.SourceFace.Normal.IsSameDirection(face.Normal)))
                 .Cast<DiveDistanceFromSource>().ToList();
        }

        private List<DiveDistanceFromSource> GetDiveGenesFromThisFace(Face face)
        {
            return _pathChromossome.Genes
                 .Where(g =>
                 g.Type == GeneType.DistanceToDive && g.SourceFace == face)
                 .Cast<DiveDistanceFromSource>().ToList();
        }

        private void ReadHorizontalLineHeight()
        {
            DistributionHeight distributionHeightGene = GetDistributionHeightGene();
            _distributionHeight = distributionHeightGene.Height;

        }

        private XYZ ProjectPointOnFaceAtFloorHeight(XYZ point, Face face)
        {
            Line lineAtHeight = new Line(face.Min.setZ(0), face.Max.setZ(0));

            return point.GetProjectedPointOnLine(lineAtHeight);
        }


        private void ReadPathForOtherFaces()
        {
            //pega face da direita da face principal
            //checa se tem gene relacionado a face
            //se sim, pega gene de direcao
            //verifica se direcao esta valida 


        }

        private void ReadPathForFloor()
        {

        }



        private DistributionHeight GetDistributionHeightGene()
        {
            return _pathChromossome.Genes.Where(g => g.Type == GeneType.Height).FirstOrDefault() as DistributionHeight;
        }

    }
}
