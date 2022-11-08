using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Definitions;
using Entities;
using Entities.GA;
using Entities.Genes;
using EntitiesInterfaces;
using Interfaces;
using QuikGraph;
using Services;
using Services.Interfaces;

namespace Application
{
    public class Driver : IDriver
    {
        private IRepository<BidirectionalGraph<Node, Edge>> _graphRepo;
        private IMeshMaker _roomMeshMaker;
        private Room _room;
        private IRoomMapper _roomMapper;

        public Driver(
            IRepository<BidirectionalGraph<Node, Edge>> graphRepo,
            IMeshMaker roomMeshMaker,
            IRoomMapper roomMapper)
        {
            _graphRepo = graphRepo;
            _roomMeshMaker = roomMeshMaker;
            _roomMapper = roomMapper;
        }


        public Result Execute()
        {

            Console.WriteLine("vc vai fazer dar certo");


            List<PathChromossome> pathChromossomes = GetTwoIndividuals();

            _roomMapper.MapRoom(_room, pathChromossomes.FirstOrDefault());



            // faz leitura do espaco e obtem grafo

            //nos de pontos terminais

            // cria individuos iniciais 
            //cria pegando pontos aleatorios e interligando com o shortest path

            // obtem executa o algoritmo de acordo com os inputs


            //obtem melhor individuo

            //grava resultados


            return Result.Succeded;
        }

        private List<PathChromossome> GetTwoIndividuals()
        {
            //pontos na face do topo
            TerminalPoint sinkOnTopFace = new TerminalPoint(new XYZ(1, 2, 0.6), PointType.Terminal);
            TerminalPoint toiletOnTopFace = new TerminalPoint(new XYZ(2, 2, 0.2), PointType.Terminal);
            TerminalPoint showerOnTopFace = new TerminalPoint(new XYZ(3, 2, 1.1), PointType.Terminal);
            TerminalPoint mainValveOnTopFace = new TerminalPoint(new XYZ(3.2, 2, 1.8), PointType.Source);
            //pontos na face de baixo
            TerminalPoint showerOnBottomFace = new TerminalPoint(new XYZ(3, 0, 1.1), PointType.Terminal);
            TerminalPoint sinkOnBottomFace = new TerminalPoint(new XYZ(1.5, 0, 0.6), PointType.Terminal);
            //pontos na face direita
            TerminalPoint pointOnRightFace = new TerminalPoint(new XYZ(3.5, 1, 0.8), PointType.Terminal);

            List<TerminalPoint> pointsOnTopFace = new List<TerminalPoint>() { sinkOnTopFace, toiletOnTopFace, showerOnTopFace, mainValveOnTopFace };
            List<TerminalPoint> pointsOnBottomFace = new List<TerminalPoint>() { showerOnBottomFace, sinkOnBottomFace };
            List<TerminalPoint> pointsOnRightFace = new List<TerminalPoint>() { pointOnRightFace };

            var leftFace = new Face(new XYZ(0, 0, 0), new XYZ(0, 2, 2.5), XYZ.BasisX);
            var rightFace = new Face(new XYZ(3.5, 0, 0), new XYZ(3.5, 2, 2.5), -XYZ.BasisX, pointsOnRightFace);
            var botFace = new Face(new XYZ(0, 0, 0), new XYZ(3.5, 0, 2.5), XYZ.BasisY, pointsOnBottomFace);
            var topFace = new Face(new XYZ(0, 2, 0), new XYZ(3.5, 2, 2.5), -XYZ.BasisY, pointsOnTopFace);
            var floorFace = new Face(new XYZ(0, 0, 0), new XYZ(3.5, 2, 2.5), XYZ.BasisZ);

            List<Face> roomFaces = new List<Face>();
            roomFaces.Add(leftFace);
            roomFaces.Add(botFace);
            roomFaces.Add(topFace);
            roomFaces.Add(rightFace);
            roomFaces.Add(floorFace);

            bool isStructural = false;

            _room = new Room(roomFaces, isStructural);

            Gene heightGene = new DistributionHeight(0.6, topFace);
            Gene rightWallDirection = new DirectionToFollow(PathDirection.Down, rightFace);
            Gene topWallDistanceToDive = new DiveDistanceFromSource(0.7, topFace);
            Gene botWallDirectionDown = new DirectionToFollow(PathDirection.Down, botFace);
            Gene botWallDirectionLeft = new DirectionToFollow(PathDirection.Left, botFace);

            Gene botWallDistanceToDive = new DiveDistanceFromSource(0.5, botFace);


            List<Gene> genesCaseOne = new List<Gene>();
            genesCaseOne.Add(heightGene);
            genesCaseOne.Add(rightWallDirection);
            genesCaseOne.Add(topWallDistanceToDive);
            genesCaseOne.Add(botWallDirectionDown);

            List<Gene> genesCaseTwo = new List<Gene>();
            genesCaseOne.Add(heightGene);
            genesCaseOne.Add(rightWallDirection);
            genesCaseOne.Add(topWallDistanceToDive);
            genesCaseOne.Add(botWallDirectionLeft);

            PathChromossome caseOne = new PathChromossome(genesCaseOne);

            //PathChromossome caseTwo = new PathChromossome(genesCaseTwo);

            return new List<PathChromossome>() { caseOne };
        }

        private double GetFitnessValueFromChromossome(PathChromossome chromossome)
        {
            double distanceWeight = 1;
            double elbowBendWeight = 1.5;
            double wallToWallElbowBendWeight = 3;
            double tBendWeight = 1;

            double score = 0;

            score = distanceWeight * EvaluateDistance() +
                elbowBendWeight * CountElbowBends() +
                wallToWallElbowBendWeight * CountWallToWallElbowBends() +
                tBendWeight * CountTBends();





            throw new NotImplementedException();
        }


        

        private double EvaluateDistance()
        {

            throw new NotImplementedException();
        }


        private int CountElbowBends()
        {
            throw new NotImplementedException();
        }

        private int CountWallToWallElbowBends()
        {
            throw new NotImplementedException();
        }

        private int CountTBends()
        {
            throw new NotImplementedException();

        }
    }
}
