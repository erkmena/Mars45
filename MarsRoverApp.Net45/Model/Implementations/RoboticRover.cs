using MarsRoverApp.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverApp.Model.Implementations
{
    public class RoboticRover : IVehicle
    {
        internal char _direction;

        internal Plateau _coordinate;


        public RoboticRover(char direction, Plateau coordinate)
        {
            _direction = direction;
            _coordinate = coordinate;
        }

        public Plateau CurrentCoordinates()
        {
            return _coordinate;
        }

        public char CurrentDirection()
        {
            return _direction;
        }

        public void Move(Plateau directionToMove)
        {
            _coordinate.XAxis += directionToMove.XAxis;
            _coordinate.YAxis += directionToMove.YAxis;
        }

        public void Turn(char direction)
        {
            _direction = direction;
        }
    }
}
