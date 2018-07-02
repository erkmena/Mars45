using System;
using MarsRoverApp.Helper;
using MarsRoverApp.Model;
using MarsRoverApp.Model.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverAppUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        static Plateau originalPlateau = new Plateau(5, 5);
        static RoboticRover robotic = new RoboticRover('N', originalPlateau);

        [TestMethod]
        public void Test1()
        {
            Plateau plateau = new Plateau(1, 1);
            RoboticRover robotic = new RoboticRover('N', plateau);

            var type = robotic.GetType();
            Console.ReadLine();
        }

        [TestMethod]
        public void TestMethodoryMethodTest()
        {

            IVehicle vehicle = VehicleFactory.MakeVehicle(robotic);
            var coordinates = vehicle.CurrentCoordinates();
            var directoin = vehicle.CurrentDirection();
        }

        [TestMethod]
        public void MoveTest()
        {
            Plateau plateau = new Plateau(1, 1);
            plateau.XAxis = 1;
            robotic.Move(plateau);
        }

        [TestMethod]
        public void TurnTest()
        {
            robotic.Turn('N');
            robotic.Turn('W');
            robotic.Turn('E');
            robotic.Turn('S');
        }


        [TestMethod]
        public void GetDirectionToTurnTest()
        {
            char direction = VehicleHelper.GetDirectionToTurn(robotic, 'L');
            robotic.Turn('W');
            direction = VehicleHelper.GetDirectionToTurn(robotic, 'L');
            robotic.Turn('S');
            direction = VehicleHelper.GetDirectionToTurn(robotic, 'L');
            robotic.Turn('E');
            direction = VehicleHelper.GetDirectionToTurn(robotic, 'L');
            robotic.Turn('N');
            direction = VehicleHelper.GetDirectionToTurn(robotic, 'R');
            robotic.Turn('E');
            direction = VehicleHelper.GetDirectionToTurn(robotic, 'R');
            robotic.Turn('S');
            direction = VehicleHelper.GetDirectionToTurn(robotic, 'R');
            robotic.Turn('W');
            direction = VehicleHelper.GetDirectionToTurn(robotic, 'R');
            robotic.Turn('N');
        }

        [TestMethod]
        public void TurnVehicleTest()
        {
            for (int i = 0; i < 4; i++) //One iteration for each side
            {
                VehicleHelper.TurnVehicle(robotic, 'L');
            }
            for (int i = 0; i < 4; i++)//One iteration for each side
            {
                VehicleHelper.TurnVehicle(robotic, 'R');
            }

        }

        [TestMethod]
        public void GetDirectionToMoveTest()
        {
            for (int i = 0; i < 4; i++) //One iteration for each side
            {
                Plateau plateau = VehicleHelper.GetDirectionToMove(robotic);
                VehicleHelper.TurnVehicle(robotic, 'L');
            }
        }

        [TestMethod]
        public void CheckForBoundaries()
        {
            RoboticRover roboticNew = new RoboticRover('N', new Plateau(5, 5) { XAxis = 1, YAxis = 1 });
            Plateau plateau = VehicleHelper.GetDirectionToMove(robotic);
            for (int i = 0; i < 4; i++)//One iteration for each side
            {
                VehicleHelper.CheckForBoundaries(roboticNew.CurrentCoordinates(), plateau, originalPlateau);
                plateau = TurnAndGetDirection(robotic);
            }

        }

        public Plateau TurnAndGetDirection(IVehicle vehicle)
        {
            VehicleHelper.TurnVehicle(robotic, 'L');
            return VehicleHelper.GetDirectionToMove(robotic);
        }

        [TestMethod]
        public void MoveVehicleTest()
        {
            RoboticRover roboticNew = new RoboticRover('N', new Plateau(5, 5) { XAxis = 1, YAxis = 1 });
            for (int i = 0; i < 4; i++)
            {
                VehicleHelper.MoveVehicle(roboticNew, originalPlateau);
                VehicleHelper.TurnVehicle(roboticNew, 'L');
            }
        }

        [TestMethod]
        public void ProcessDataTest()
        {
            RoboticRover roboticNew = new RoboticRover('N', new Plateau(5, 5) { XAxis = 1, YAxis = 2 }); //Standard documentation test
            VehicleHelper.ProcessData("LMLMLMLMM", roboticNew, originalPlateau);

            RoboticRover roboticNew2 = new RoboticRover('E', new Plateau(5, 5) { XAxis = 3, YAxis = 3 });//Standard documentation test
            VehicleHelper.ProcessData("MMRMMRMRRM", roboticNew2, originalPlateau);

            RoboticRover roboticNew3 = new RoboticRover('E', new Plateau(5, 5) { XAxis = 3, YAxis = 3 }); //Check for what happens if boundaries exceed
            VehicleHelper.ProcessData("MMMRMMRMRRM", roboticNew3, originalPlateau);

            RoboticRover roboticNew4 = new RoboticRover('E', new Plateau(5, 5) { XAxis = 3, YAxis = 3 }); //Check for if direction changes
            VehicleHelper.ProcessData("MMMRMMRMRRMR", roboticNew4, originalPlateau);

        }

    }
}

